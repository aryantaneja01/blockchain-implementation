using Newtonsoft.Json;
using System;

namespace MyBlockChain
{
    class Program
    {
        public static int Port = 0;
        public static P2PServer Server = null;
        public static Client_P2P Client = new Client_P2P();
        public static MyBlockchain Token = new MyBlockchain();
        public static string name = "Unknown";

        static void Main(string[] args)
        {
            Token.Start_init();

            if (args.Length >= 1)
                Port = int.Parse(args[0]);
            if (args.Length >= 2)
                name = args[1];

            if (Port > 0)
            {
                Server = new P2PServer();
                Server.Start();
            }
            if (name != "Unkown")
            {
                Console.WriteLine($"Pickup location is {name}");
            }

            Console.WriteLine("=========================");
            Console.WriteLine("1. Join to a server");
            Console.WriteLine("2. Make a Booking");
            Console.WriteLine("3. Display Blockchain");
            Console.WriteLine("4. Exit");
            Console.WriteLine("=========================");

            int Select = 0;
            while (Select != 4)
            {
                switch (Select)
                {
                    case 1:
                        Console.WriteLine("Please enter the server URL");
                        string serverURL = Console.ReadLine();
                        Client.Connect($"{serverURL}/Blockchain");
                        break;
                    case 2:
                        Console.WriteLine("Destination:");
                        string nameOfReceiver = Console.ReadLine();
                        Console.WriteLine("Please enter the duration of booking(in mins):");
                        string amount = Console.ReadLine();
                        Token.MakeBooking(new Booking(name, nameOfReceiver, int.Parse(amount)));
                        Token.ProcessLeftUnits(name);
                        Client.Broadcast(JsonConvert.SerializeObject(Token));
                        break;
                    case 3:
                        Console.WriteLine("Blockchain");
                        Console.WriteLine(JsonConvert.SerializeObject(Token, Formatting.Indented));
                        break;

                }

                Console.WriteLine("Please select an option");
                string action = Console.ReadLine();
                Select = int.Parse(action);
            }

            Client.Close();
        }
    }
}

