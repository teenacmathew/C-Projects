using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tmFinalExam
{
    [XmlInclude(typeof(Tire))]
    [XmlInclude(typeof(Battery))]
    [XmlInclude(typeof(Wiper))]
    public class Item
    {
        private int number;
        private int cost;
        private int weight;
        private string itemName;

        public Item()
        {
            this.number = 0;
            this.cost = 0;
            this.weight = 0;
            this.itemName = "";
        }

        public Item(int number, int cost, int weight, string itemName)
        {
            this.number = number;
            this.cost = cost;
            this.weight = weight;
            this.itemName = itemName;
        }

        public int Number { get => number; set => number = value; }
        public int Cost { get => cost; set => cost = value; }
        public int Weight { get => weight; set => weight = value; }
        public string ItemName { get => itemName; set => itemName = value; }

    }
}
