using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinal
{
    public class GasCars : Car
    {


        public GasCars() { }

        public GasCars(string make, string model, decimal cost)
        {
            Make = make;
            Model = model;
            Cost = cost;
        }

        public string Make { get; set; }

        public string Type => "Gas";

        public string Model { get; set; }

        public decimal Cost { get; set; }

        public bool IsItFast => true;
    }
}
