using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class OutingRepo
    {
        private List<Outings> _outings = new List<Outings>();

        //C
        public bool AddOuting(Outings outing)
        {
            int startingCount = _outings.Count();
            _outings.Add(outing);

            bool wasAdded = (_outings.Count() > startingCount) ? true: false;
            return wasAdded;
        }

        //R
        
        public List<Outings> GetAllOutings()
        {
            return _outings;
        }

        

        public decimal AddAllEventCosts()
        {
            //foreach(Outings outing in _outings)
            //{
            decimal total = _outings.Select(i => i.TotalCostForEvent).Sum();

            return total;
            //}
            //return default;
        }

        //R
        //Getall outings
        //Calculate

    }
}
