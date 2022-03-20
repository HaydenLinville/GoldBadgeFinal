using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinal
{
    public class HybridCars : Car
    {

        public HybridCars() { }

        public HybridCars(string make, string model, decimal cost, bool isfast)
        {
            Make = make;
            Model = model;
            Cost = cost;
            IsItFast = isfast;
        }


        public string Make { get; set; }

        public string Type => "Hybrid";

        public string Model { get; set; }

        public decimal Cost { get; set; }

        public bool IsItFast { get; set; }
    }
}
