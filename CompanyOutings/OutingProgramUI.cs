using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class OutingProgramUI
    {
        OutingRepo outRepo = new OutingRepo();
        public void Run()
        {
            Menu();
            Seed();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.Write("What would you like to do? \n" +
                    "1. \n" +
                    "2. \n" +
                    "3. \n" +
                    "4. \n" +
                    "5. \n");
                string answer = Console.ReadLine();
                switch (answer.ToLower())
                {
                    case "1":
                        //
                        break;
                    case "2":
                        //
                        break;
                    case "3":
                        //
                        break;
                    case "4":
                        //
                        break;
                    case "5":
                        //
                        break;



                }

            }

        }

        public void ShowAllOutings()
        {

        }

        public void Seed()
        {
            Outings o1 = new Outings(EventType.Golf, 10, new DateTime(2020, 1, 14));
            Outings o2 = new Outings(EventType.Concert, 5, new DateTime(2020, 2, 20));
            Outings o3 = new Outings(EventType.AmusementPark, 10, new DateTime(2020, 5, 14));
            Outings o4 = new Outings(EventType.Bowling, 15, new DateTime(2020,10,4));
            Outings o5 = new Outings(EventType.Golf, 5, new DateTime(2020, 9, 20));
            Outings o6 = new Outings(EventType.Bowling, 2, new DateTime(2020, 7, 8));

            outRepo.AddOuting(o1);
            outRepo.AddOuting(o2);
            outRepo.AddOuting(o3);
            outRepo.AddOuting(o4);
            outRepo.AddOuting(o5);
            outRepo.AddOuting(o6);

        }


    }
}
