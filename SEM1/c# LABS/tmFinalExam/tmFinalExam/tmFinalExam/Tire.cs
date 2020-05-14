using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmFinalExam
{
    public class Tire : Item
    {
        private string modelName;
        private int diameter;
        public Tire() : base(1, 200, 30, "")
        {
        }
        public Tire(string modelName, int diameter, string itemName) : base(1, 200, 30, itemName)
        {
            this.modelName = modelName;
            this.diameter = diameter;
        }
        public string ModelName { get => modelName; set => modelName = value; }

        public int Diameter { get => diameter; set => diameter = value; }

    }
}

