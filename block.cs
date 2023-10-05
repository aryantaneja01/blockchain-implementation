using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyBlockChain
{
    public class MyBlock
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LastHash { get; set; }
        public string CurrentHash { get; set; }
        public IList<Booking> Bookings { get; set; }
        public int Nonce { get; set; } = 0;

        public MyBlock(DateTime timeStamp, string lastHash, IList<Booking> bookings)
        {
            Id = 0;
            TimeStamp = timeStamp;
            LastHash = lastHash;
            Bookings = bookings;
        }

        public string HashCompute()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{LastHash ?? ""}-{JsonConvert.SerializeObject(Bookings)}-{Nonce}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        public void My(int complexity)
        {
            var leadingZeros = new string('0', complexity);
            while (this.CurrentHash == null || this.CurrentHash.Substring(0, complexity) != leadingZeros)
            {
                this.Nonce++;
                this.CurrentHash = this.HashCompute();
            }
        }
    }
}
