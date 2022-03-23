using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class OutingProgramUI
    {
        private OutingRepo _outRepo = new OutingRepo();
        public void Run()
        {
            Seed();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.Write("What would you like to do? \n" +
                    "1. See total spent on all events. \n" +
                    "2. See all events. \n" +
                    "3. See cost by events. \n" +
                    "4. Create new outing. \n" +
                    "5. Exit. \n");
                string answer = Console.ReadLine();
                switch (answer.ToLower())
                {
                    case "1":
                        ShowTotalTotal();
                        break;
                    case "2":
                        ShowAllOutings();
                        break;
                    case "3":
                        ShowTotalForAllOfTheSameTypes();
                        break;
                    case "4":
                        CreateOuting();
                        break;
                    case "5":
                    case "e":
                    case "exit":
                        keepRunning = false;
                        break;



                }

            }

        }
        //might need to come back for a different defualt
        public void CreateOuting()
        {
            Console.Clear();
            Outings newOuting = new Outings();

            Console.Clear();
            Console.Write("What Type of Event would you like to make?(if none is selected default will be bowling) \n" +
            "1. Amusement Park \n" +
            "2. Bowling \n" +
            "3. Concert \n" +
            "4. Golf \n");

            string eventAnswer = Console.ReadLine();

            switch (eventAnswer.ToLower())
            {
                case "1":
                case "amusement park":
                case "park":
                case "a":
                case "p":
                    newOuting.Type = EventType.AmusementPark; Console.WriteLine("Amusement Park... Keep in mind that is $70 per person.");
                    break;
                case "2":
                case "b":
                case "bowling":
                default:
                    newOuting.Type = EventType.Bowling; Console.WriteLine("Bowling is only $10 per person. Great choice.");
                    break;
                case "3":
                case "c":
                case "concert":
                    newOuting.Type = EventType.Concert; Console.WriteLine("A concert is $100 per person.");
                    break;
                case "4":
                case "g":
                case "golf":
                    newOuting.Type = EventType.Golf; Console.WriteLine("Golf is a fair $20 per person.");
                    break;
            }
            bool peopleMenu = true;
            while (peopleMenu)
            {

                Console.Write("How many people are going? ");
                string peopleAnswer = Console.ReadLine();
                if (peopleAnswer != "")
                {
                    newOuting.NumberOfPeople = int.Parse(peopleAnswer);
                    peopleMenu = false;
                }
                else
                { Console.WriteLine("You must provide a number."); }

            }
            Console.WriteLine("What is the date of this event?");
            Console.Write("Year(XXXX) ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Month(XX) ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Day(XX) ");
            int day = int.Parse(Console.ReadLine());

            newOuting.DateOfEvent = new DateTime(year, month, day);

            if(_outRepo.AddOuting(newOuting))
            {
                Console.WriteLine($"New {newOuting.Type.ToString()} outing was created!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Something went wrong sorry!");
                AnyKey();
            }


        }

        public void ShowTotalForAllOfTheSameTypes()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.Clear();
                Console.Write("What Type of Event would you like to see? \n" +
                "1. Amusement Park \n" +
                "2. Bowling \n" +
                "3. Concert \n" +
                "4. Golf \n" +
                "5. Exit \n");

                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "1":
                    case "amusement park":
                    case "park":
                    case "a":
                    case "p":
                        Console.Clear(); Console.WriteLine($"Total money spent on amusement parks events was ${_outRepo.AddAllCostsForType(EventType.AmusementPark)}"); AnyKey();
                        break;
                    case "2":
                    case "b":
                    case "bowling":
                        Console.Clear(); Console.WriteLine($"Total money spent on bowling events was ${_outRepo.AddAllCostsForType(EventType.Bowling)}"); AnyKey();
                        break;
                    case "3":
                    case "c":
                    case "concert":
                        Console.Clear(); Console.WriteLine($"Total money spent on concerts was ${_outRepo.AddAllCostsForType(EventType.Concert)}"); AnyKey();
                        break;
                    case "4":
                    case "g":
                    case "golf":
                        Console.Clear(); Console.WriteLine($"Total money spent on golf events was ${_outRepo.AddAllCostsForType(EventType.Golf)}"); AnyKey();
                        break;
                    case "5":
                    case "e":
                    case "exit":
                    default:
                        keepRunning = false;
                        break;

                }

            }

        }

        public void ShowTotalTotal()
        {
            Console.Clear();
            decimal total = _outRepo.AddAllEventCosts();
            Console.WriteLine($"The total cost of all events is ${total} \n" +
                $"Wow that is a lot of money!");
            AnyKey();
        }


        public void ShowAllOutings()
        {
            Console.Clear();
            List<Outings> listOuting = _outRepo.GetAllOutings();
            foreach (Outings outing in listOuting)
            {
                ShowOutings(outing);
            }
            AnyKey();
        }

        public void ShowOutings(Outings outing)
        {
            Console.WriteLine($"Type of Event: {outing.Type} \n" +
                $"Number of people that attended: {outing.NumberOfPeople} \n" +
                $"When the event took place: {outing.DateOfEvent.ToString("MM-dd-yyyy")} \n" +
                $"How much {outing.Type} cost per person: ${outing.CostPerPerson} \n" +
                $"How much {outing.Type} cost total: ${outing.TotalCostForEvent} \n");

        }

        public void Seed()
        {
            Outings o1 = new Outings(EventType.Golf, 10, new DateTime(2020, 1, 14));
            Outings o2 = new Outings(EventType.Concert, 5, new DateTime(2020, 2, 20));
            Outings o3 = new Outings(EventType.AmusementPark, 10, new DateTime(2020, 5, 14));
            Outings o4 = new Outings(EventType.Bowling, 15, new DateTime(2020, 10, 4));
            Outings o5 = new Outings(EventType.Golf, 5, new DateTime(2020, 9, 20));
            Outings o6 = new Outings(EventType.Bowling, 2, new DateTime(2020, 7, 8));

            _outRepo.AddOuting(o1);
            _outRepo.AddOuting(o2);
            _outRepo.AddOuting(o3);
            _outRepo.AddOuting(o4);
            _outRepo.AddOuting(o5);
            _outRepo.AddOuting(o6);

        }

        public void AnyKey()
        {
            Console.WriteLine("Press a freaking button to keep going....");
            Console.ReadKey();
        }


    }
}
