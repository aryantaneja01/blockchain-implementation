using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;

namespace MyBlockChain
{
    public class Client_P2P
    {
        IDictionary<string, WebSocket> Dict_w = new Dictionary<string, WebSocket>();

        public void Connect(string url)
        {
            if (!Dict_w.ContainsKey(url))
            {
                WebSocket ws = new WebSocket(url);
                ws.OnMessage += (sender, e) => 
                {
                    if (e.Data == "Hi Client")
                    {
                        Console.WriteLine(e.Data);
                    }
                    else
                    {
                        MyBlockchain Seq_new = JsonConvert.DeserializeObject<MyBlockchain>(e.Data);
                        if (Seq_new.Auth() && Seq_new.Seq.Count > Program.Token.Seq.Count)
                        {
                            List<Booking> newBookings = new List<Booking>();
                            newBookings.AddRange(Seq_new.LeftUnits);
                            newBookings.AddRange(Program.Token.LeftUnits);

                            Seq_new.LeftUnits = newBookings;
                            Program.Token = Seq_new;
                        }
                    }
                };
                ws.Connect();
                ws.Send("Hi Server");
                ws.Send(JsonConvert.SerializeObject(Program.Token));
                Dict_w.Add(url, ws);
            }
        }

        public void Send(string url, string data)
        {
            foreach (var item in Dict_w)
            {
                if (item.Key == url)
                {
                    item.Value.Send(data);
                }
            }
        }

        public void Broadcast(string data)
        {
            foreach (var item in Dict_w)
            {
                item.Value.Send(data);
            }
        }

        public IList<string> GetServers()
        {
            IList<string> servers = new List<string>();
            foreach (var item in Dict_w)
            {
                servers.Add(item.Key);
            }
            return servers;
        }

        public void Close()
        {
            foreach (var item in Dict_w)
            {
                item.Value.Close();
            }
        }
    }
}
