using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinal
{
    public class GreenPlanProgramUI
    {
        private CarRepo _car = new CarRepo();
        public void Run()
        {
            Seed();
            Menu();

        }



        public void Menu()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("What would you like to do? \n" +
                    "1. See All Cars. \n" +
                    "2. Electric Car Menu. \n" +
                    "3. Gas Car Menu. \n" +
                    "4. Hybrid Car Menu. \n" +
                    "5. Exit \n");

                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "1":
                        ShowAllCars();
                        break;
                    case "2":
                        ElectricMenu();
                        break;
                    case "3":
                        GasMenu();
                        break;
                    case "4":
                        HybridMenu();
                        break;
                    case "5":
                    case "e":
                    case "exit":
                        keepGoing = false;
                        break;

                }
            }
        }


        public void ElectricMenu()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("ELECTRIC MENU \n" +
                    "Please select from below: \n" +
                    "1. See All Electric Cars. \n" +
                    "2. Add Electric Car. \n" +
                    "3. Update Electric Car \n" +
                    "4. Delete Electric Car \n" +
                    "5. Exit. \n");

                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "1":
                        ShowAllElectricCarsMenu();
                        break;
                    case "2":
                        CreateNewECar();
                        break;
                    case "3":
                        UpdateECar();
                        break;
                    case "4":
                        DeleteECar();
                        break;
                    case "e":
                    case "exit":
                    default:
                        keepGoing = false;
                        break;
                }

            }

        }

        public void GasMenu()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("GAS MENU \n" +
                    "Please select from below: \n" +
                    "1. See All Gas Cars. \n" +
                    "2. Add Gas Car. \n" +
                    "3. Update Gas Car. \n" +
                    "4. Delete Gas Car. \n" +
                    "5. Exit. \n");

                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "1":
                        ShowAllGasCarsMenu();
                        break;
                    case "2":
                        CreateNewGCar();
                        break;
                    case "3":
                        UpdateGCar();
                        break;
                    case "4":
                        DeleteGCar();
                        break;
                    case "5":
                    case "e":
                    case "exit":
                    default:
                        keepGoing = false;
                        break;
                }

            }

        }

        public void HybridMenu()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("HYBRID MENU \n" +
                    "Please select from below: \n" +
                    "1. See All Hybrid Cars. \n" +
                    "2. Add Hybrid Car. \n" +
                    "3. Update Hybrid Car. \n" +
                    "4. Delete Hybrid Car. \n" +
                    "5. Exit. \n");

                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "1":
                        ShowAllHybridCarsMenu();
                        break;
                    case "2":
                        CreateNewHCar();
                        break;
                    case "3":
                        UpdateHCar();
                        break;
                    case "4":
                        DeleteHCar();
                        break;
                    case "5":
                    case "e":
                    case "exit":
                    default:
                        keepGoing = false;
                        break;
                }

            }

        }

        public void CreateNewGCar()
        {
            Console.Clear();

            GasCars gas = new GasCars();

            Console.Write("What is the Make of the new car? ");
            gas.Make = Console.ReadLine();

            Console.Write("What is the Model of the new car? ");
            gas.Model = Console.ReadLine();

            Console.Write("How much does the car cost? $");
            gas.Cost = decimal.Parse(Console.ReadLine());

            if(_car.AddGasCar(gas))
            {
                Console.WriteLine($"You added a {gas.Make} {gas.Model} car! As we all know those are fast!");
            }
            else
            {
                Console.WriteLine("Something went wrong :(");
            }
            AnyKey();

        }

        public void CreateNewECar()
        {
            Console.Clear();

            ElectricCars e = new ElectricCars();

            Console.Write("What is the Make of the new car? ");
            e.Make = Console.ReadLine();

            Console.Write("What is the Model of the new car? ");
            e.Model = Console.ReadLine();

            Console.Write("How much does the car cost? $");
            e.Cost = decimal.Parse(Console.ReadLine());

            if (_car.AddElectricCar(e))
            {
                Console.WriteLine($"You added a {e.Make} {e.Model}! As we all know those are not fast.... but you are saving the enviroment!");
            }
            else
            {
                Console.WriteLine("Something went wrong :(");
            }
            AnyKey();

        }

        public void CreateNewHCar()
        {
            Console.Clear();

            HybridCars h = new HybridCars();

            Console.Write("What is the Make of the new car? ");
            h.Make = Console.ReadLine();

            Console.Write("What is the Model of the new car? ");
            h.Model = Console.ReadLine();

            Console.Write("How much does the car cost? $");
            h.Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Is car fast?(Y/N) ");
            string fast = Console.ReadLine();

            if(fast.ToLower().Contains("yes") || fast.ToLower().Contains("y"))
            {
                h.IsItFast = true;
            }
            else
            {
                h.IsItFast = false;
            }

            if (_car.AddHybridCar(h))
            {
                Console.WriteLine($"You added a {h.Make} {h.Model}!");
            }
            else
            {
                Console.WriteLine("Something went wrong :(");
            }
            AnyKey();

        }

        public void UpdateGCar()
        {
            Console.Clear();
            ShowAllGasCars();
            Console.Write("What is the Model you would like to update? ");
            string gasModel = Console.ReadLine();

            GasCars oldGas = _car.GetGCarByModel(gasModel);
            if(oldGas != null)
            {
                Console.Write("What is the updated model of this car? ");
                string newModel = Console.ReadLine();
                if(newModel != "")
                {
                    oldGas.Model = newModel;
                }

                Console.Write("What is the updated make of this car? ");
                string newMake = Console.ReadLine();
                if(newMake != "")
                {
                    oldGas.Make = newMake;
                }

                Console.Write("What is the updated cost of this car? $");
                string newCost = Console.ReadLine();
                if(newCost != "")
                {
                    oldGas.Cost = decimal.Parse(newCost);
                }
                Console.WriteLine($"{oldGas.Make} {oldGas.Model} is updated and it is FAST!");
            }
            else { Console.WriteLine("Car not found."); }
            AnyKey();

        }

        public void UpdateHCar()
        {
            Console.Clear();
            ShowAllHybridCars();
            Console.Write("What is the Model you would like to update? ");
            string hybridCar = Console.ReadLine();

            HybridCars oldHybrid = _car.GetHCarByModel(hybridCar);
            if (oldHybrid != null)
            {
                Console.Write("What is the updated model of this car? ");
                string newModel = Console.ReadLine();
                if (newModel != "")
                {
                    oldHybrid.Model = newModel;
                }

                Console.Write("What is the updated make of this car? ");
                string newMake = Console.ReadLine();
                if (newMake != "")
                {
                    oldHybrid.Make = newMake;
                }

                Console.Write("What is the updated cost of this car? $");
                string newCost = Console.ReadLine();
                if (newCost != "")
                {
                    oldHybrid.Cost = decimal.Parse(newCost);
                }
                Console.Write("Is this hybrid fast?(Y/N) ");
                string fast = Console.ReadLine();
                if (fast.ToLower().Contains("y") || fast.ToLower().Contains("yes"))
                {
                    oldHybrid.IsItFast = true;
                }
                else
                {
                    oldHybrid.IsItFast = false;
                }

                Console.WriteLine($"{oldHybrid.Make} {oldHybrid.Model} is updated and it's.... meh. ");
            }
            else { Console.WriteLine("Car not found."); }
            AnyKey();

        }

        public void UpdateECar()
        {
            Console.Clear();
            ShowAllElectricCars();
            Console.Write("What is the Model you would like to update? ");
            string electricModel = Console.ReadLine();

            ElectricCars oldElectric = _car.GetECarByModel(electricModel);
            if (oldElectric != null)
            {
                Console.Write("What is the updated model of this car? ");
                string newModel = Console.ReadLine();
                if (newModel != "")
                {
                    oldElectric.Model = newModel;
                }

                Console.Write("What is the updated make of this car? ");
                string newMake = Console.ReadLine();
                if (newMake != "")
                {
                    oldElectric.Make = newMake;
                }

                Console.Write("What is the updated cost of this car? $");
                string newCost = Console.ReadLine();
                if (newCost != "")
                {
                    oldElectric.Cost = decimal.Parse(newCost);
                }
                Console.WriteLine($"{oldElectric.Make} {oldElectric.Model} is updated and it is slow but its good for the planet!");
            }
            else { Console.WriteLine("Car not found."); }
            AnyKey();

        }



        public void ShowAllCars()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            ShowAllHybridCars();
            Console.ForegroundColor = ConsoleColor.Blue;
            ShowAllElectricCars();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            ShowAllGasCars();

            AnyKey();

        }

        public void ShowAllElectricCars()
        {
            
            List<ElectricCars> eCarList = _car.GetAllElectricCars();
            foreach (ElectricCars car in eCarList)
            {
                ShowECar(car);
            }
         
        }

        public void ShowAllGasCars()
        {
           
            List<GasCars> gasCarList = _car.GetAllGasCars();
            foreach (GasCars car in gasCarList)
            {
                ShowGCar(car);
            }
           
        }
        public void ShowAllHybridCars()
        {
            
            List<HybridCars> hCarList = _car.GetAllHybridCars();
            foreach (HybridCars car in hCarList)
            {
                ShowHCar(car);
            }
           

        }

        public void ShowAllHybridCarsMenu()
        {
            Console.Clear();
            List<HybridCars> hCarList = _car.GetAllHybridCars();
            foreach (HybridCars car in hCarList)
            {
                ShowHCar(car);
            }
            AnyKey();

        }
        
        public void ShowAllGasCarsMenu()
        {
            Console.Clear();
            List<GasCars> gasCarList = _car.GetAllGasCars();
            foreach (GasCars car in gasCarList)
            {
                ShowGCar(car);
            }
            AnyKey();
        }

        public void ShowAllElectricCarsMenu()
        {
            Console.Clear();
            List<ElectricCars> eCarList = _car.GetAllElectricCars();
            foreach (ElectricCars car in eCarList)
            {
                ShowECar(car);
            }
            AnyKey();
        }

        public void DeleteECar()
        {
            Console.Clear();
            ShowAllElectricCars();
            Console.Write("What model would you like to delete? ");
            string eModel = Console.ReadLine();
            if(eModel != "")
            {
                if(_car.RemoveECarByModel(eModel))
                { 
                    Console.WriteLine("Car successfully deleted. If this was a mistake too bad it's gone forever.");
                    AnyKey();
                }
                else
                { 
                    Console.WriteLine("No car found by that model.");
                    AnyKey();
                }
            }
        }

        public void DeleteGCar()
        {
            Console.Clear();
            ShowAllGasCars();
            Console.Write("What model would you like to delete? ");
            string gModel = Console.ReadLine();
            if (gModel != "")
            {
                if (_car.RemoveGCarByModel(gModel))
                {
                    Console.WriteLine("Car successfully deleted. If this was a mistake too bad it's gone forever.");
                    AnyKey();
                }
                else
                {
                    Console.WriteLine("No car found by that model.");
                    AnyKey();
                }
            }
        }
        public void DeleteHCar()
        {
            Console.Clear();
            ShowAllHybridCars();
            Console.Write("What model would you like to delete? ");
            string hModel = Console.ReadLine();
            if (hModel != "")
            {
                if (_car.RemoveHCarByModel(hModel))
                {
                    Console.WriteLine("Car successfully deleted. If this was a mistake too bad it's gone forever.");
                    AnyKey();
                }
                else
                {
                    Console.WriteLine("No car found by that model.");
                    AnyKey();
                }
            }

        }




        public void Seed()
        {
            ElectricCars lighting = new ElectricCars();
            ElectricCars modelX = new ElectricCars();
            GasCars mustang = new GasCars();
            GasCars sonic = new GasCars();
            HybridCars fusion = new HybridCars();
            HybridCars prius = new HybridCars();

            lighting.Make = "Ford";
            lighting.Model = "F-150 Lightning";
            lighting.Cost = 3000m;
            modelX.Make = "Tesla";
            modelX.Model = "Model X";
            modelX.Cost = 30049.99m;
            _car.AddElectricCar(modelX);
            _car.AddElectricCar(lighting);

            mustang.Make = "Ford";
            mustang.Model = "Mustang";
            mustang.Cost = 3999.99m;
            sonic.Make = "Chevy";
            sonic.Model = "Sonic";
            sonic.Cost = 1500.56m;

            _car.AddGasCar(sonic);
            _car.AddGasCar(mustang);

            fusion.Make = "Ford";
            fusion.Model = "Fusion";
            fusion.Cost = 4400.40m;
            prius.Make = "Toyota";
            prius.Model = "Prius";
            prius.Cost = 55549.35m;
            _car.AddHybridCar(prius);
            _car.AddHybridCar(fusion);


        }



        private void ShowECar(ElectricCars car)
        {
            Console.WriteLine($"Make: {car.Make} \n" +
                $"Model: {car.Model} \n" +
                $"Cost: ${car.Cost} \n" +
                $"Is it fast: {(car.IsItFast ? "Yes" : "No")} \n" +
                $"Type: {car.Type} \n");

        }

        private void ShowGCar(GasCars car)
        {
            Console.WriteLine($"Make: {car.Make} \n" +
                $"Model: {car.Model} \n" +
                $"Cost: ${car.Cost} \n" +
                $"Is it fast: {(car.IsItFast ? "Yes" : "No")} \n" +
                $"Type: {car.Type} \n");


        }

        private void ShowHCar(HybridCars car)
        {
            Console.WriteLine($"Make: {car.Make} \n" +
                $"Model: {car.Model} \n" +
                $"Cost: ${car.Cost} \n" +
                $"Is it fast: {(car.IsItFast ? "Yes" : "No")} \n" +
                $"Type: {car.Type} \n");
        }

        public void AnyKey()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press Any key to Continue.....");
            Console.ReadKey();
        }

    }
}
