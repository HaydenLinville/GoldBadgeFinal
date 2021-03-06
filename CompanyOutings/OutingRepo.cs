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

        public bool AddOuting(Outings outing)
        {
            int startingCount = _outings.Count();
            _outings.Add(outing);

            bool wasAdded = (_outings.Count() > startingCount) ? true: false;
            return wasAdded;
        }

        public List<Outings> GetAllOutings()
        {
            return _outings;
        }

        public List<Outings> GetOutingByType(EventType type)
        {
           List<Outings> listByType = new List<Outings>();
            foreach(Outings outing in _outings)
            {
                if(outing.Type == type)
                {
                    listByType.Add(outing);
                }
            }
            return listByType;
            
        }
        
        public decimal AddAllCostsForType(EventType type)
        {
            List<Outings> listByType = GetOutingByType(type);
            decimal total = listByType.Select(i => i.TotalCostForEvent).Sum();
            return total;
            
        }


        public decimal AddAllEventCosts()
        {
            decimal total = _outings.Select(i => i.TotalCostForEvent).Sum();
            return total;
            
        }


    }
}
