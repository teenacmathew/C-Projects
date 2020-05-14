using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmFinalExam
{
    public class Wiper : Item, IShipItem
    {
        private int length;
        public Wiper() : base(3, 15, 1, "")
        {
        }
        public Wiper(int length, bool ship, string itemName) : base(3, 15, 1, itemName)
        {
            this.length = length;
            this.Ship = ship;
        }
        public int Length { get => length; set => length = value; }
        public bool Ship { get; set;}

        public int ShipItem()
        {
            return 10;
        }
    }
}