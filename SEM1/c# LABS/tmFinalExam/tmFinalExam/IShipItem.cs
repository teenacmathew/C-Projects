using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmFinalExam
{
    interface IShipItem
    {
        bool Ship
        {
            get;
            set;
        }
        int ShipItem();
    }
}
