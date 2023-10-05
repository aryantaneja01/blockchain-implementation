using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MyBlockChain
{
    public class P2PServer: WebSocketBehavior
    {
        bool SeqSync = false;
        WebSocketServer wss = null;

        public void Start()
        {
            wss = new WebSocketServer($"ws://127.0.0.1:{Program.Port}");
            wss.AddWebSocketService<P2PServer>("/Blockchain");
            wss.Start();
            Console.WriteLine($"Started server at ws://127.0.0.1:{Program.Port}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.Data == "Hi Server")
            {
                Console.WriteLine(e.Data);
                Send("Hi Client");
            }
            else
            {
                MyBlockchain Seq_new = JsonConvert.DeserializeObject<MyBlockchain>(e.Data);

                if (Seq_new.Auth() && Seq_new.Seq.Count > Program.Token.Seq.Count)
                {
                    List<Booking> newBooking = new List<Booking>();
                    newBooking.AddRange(Seq_new.LeftUnits);
                    newBooking.AddRange(Program.Token.LeftUnits);

                    Seq_new.LeftUnits = newBooking;
                    Program.Token = Seq_new;
                }

                if (!SeqSync)
                {
                    Send(JsonConvert.SerializeObject(Program.Token));
                    SeqSync = true;
                }
            }
        }
    }
}