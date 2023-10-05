using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlockChain
{
    public class MyBlockchain
    {
        public IList<Booking> LeftUnits = new List<Booking>();
        public IList<MyBlock> Seq { set;  get; }
        public int Complexity { set; get; } = 2;
        public int reward = 1; 

        public MyBlockchain()
        {
            
        }


        public void Start_init()
        {
            Seq = new List<MyBlock>();
            IncUnit();
        }

        public MyBlock InitUnit()
        {
            MyBlock block = new MyBlock(DateTime.Now, null, LeftUnits);
            block.My(Complexity);
            LeftUnits = new List<Booking>();
            return block;
        }

        public void IncUnit()
        {
            Seq.Add(InitUnit());
        }
        
        public MyBlock RetUnit()
        {
            return Seq[Seq.Count - 1];
        }

        public void MakeBooking(Booking booking)
        {
            LeftUnits.Add(booking);
        }
        public void ProcessLeftUnits(string MyrAddress)
        {
            MyBlock block = new MyBlock(DateTime.Now, RetUnit().CurrentHash, LeftUnits);
            UnitInc(block);

            LeftUnits = new List<Booking>();
            MakeBooking(new Booking(null, MyrAddress, reward));
        }

        public void UnitInc(MyBlock block)
        {
            MyBlock LastBlockUsed = RetUnit();
            block.Id = LastBlockUsed.Id + 1;
            block.LastHash = LastBlockUsed.CurrentHash;
            //block.Hash = block.HashCompute();
            block.My(this.Complexity);
            Seq.Add(block);
        }

        public bool Auth()
        {
            for (int i = 1; i < Seq.Count; i++)
            {
                MyBlock ThisUnit = Seq[i];
                MyBlock LastUnit = Seq[i - 1];

                if (ThisUnit.CurrentHash != ThisUnit.HashCompute())
                {
                    return false;
                }

                if (ThisUnit.LastHash != LastUnit.CurrentHash)
                {
                    return false;
                }
            }
            return true;
        }

        public int Statement(string address)
        {
            int balance = 0;

            for (int i = 0; i < Seq.Count; i++)
            {
                for (int j = 0; j < Seq[i].Bookings.Count; j++)
                {
                    var booking = Seq[i].Bookings[j];

                    if (booking.FromAddress == address)
                    {
                        balance -= booking.Duration;
                    }

                    if (booking.ToAddress == address)
                    {
                        balance += booking.Duration;
                    }
                }
            }

            return balance;
        }
    }
}

