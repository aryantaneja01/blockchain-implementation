using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlockChain
{
    public class Booking
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int Duration { get; set; }

        public Booking(string fromAddress, string toAddress, int duration)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Duration = duration;
        }
    }
}

