using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public enum EventType { AmusementPark, Bowling, Concert, Golf}
    public class Outings
    {

        public Outings(EventType type, int numberOfPeople, DateTime eventDate)
        {
            Type = type;
            NumberOfPeople = numberOfPeople;
            DateOfEvent = eventDate;

        }

        public EventType Type { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson
        {
            get
            {
                if (Type == EventType.AmusementPark)
                { return 70m; }
                else if (Type == EventType.Golf)
                { return 20m; }
                else if (Type == EventType.Bowling)
                { return 10m; }
                else return 100m;
            }
        }
        public decimal TotalCostForEvent
        {
            get
            { return CostPerPerson * NumberOfPeople; }
            set { }
        }


    }
}
