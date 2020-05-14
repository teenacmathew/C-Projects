using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmFinalExam
{
    public class Battery : Item, IShipItem
    {
        private int voltage;
        public Battery() : base(2, 100, 10, "")
        {
        }

        public Battery(int voltage, bool ship, string itemName) : base(2, 100, 10, itemName)
        {
            this.voltage = voltage;
            this.Ship = ship;
        }
        public int Voltage { get => voltage; set => voltage = value; }
        public bool Ship { get; set; }

        public int ShipItem()
        {
            return 30;
        }

    }
}
