using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class CafeProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedContent();

            WindoMenu();

        }

        private void WindoMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

            Console.Write("What would you like to do? \n" +
                "1. See Menu \n" +
                "2. Add item to Menu \n" +
                "3. Remove item from Menu \n" +
                "4. Exit \n");

                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "1":
                    default:
                        DisplayMenu();
                        break;
                    case "2":
                        AddItemsToMenue();
                        break;
                    case "3":
                        RemoveItemsFromMenu();
                        break;
                    case "4":
                    case "e":
                    case "exit":
                        keepRunning = false;
                        break;


                }

            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            List<Menu> menus = _menuRepo.GetMenu();
            foreach(MenuItems items in menus)
            {
                Console.WriteLine($"Meal Number: {items.MealNumber} \n" +
                    $"Price: ${items.Price} \n" +
                    $"Meal Name: {items.MealName} \n" +
                    $"Description: {items.Description}\n" +
                    $"Ingredients: " );
                foreach(var ingrdient in items.Ingredients)
                {
                    
                    if (ingrdient == Ingredients.Fries)
                    {
                        Console.WriteLine("Fries");
                    }
                    else if (ingrdient == Ingredients.Veggies)
                    {
                        Console.WriteLine("Veggies");
                    }
                    else if (ingrdient == Ingredients.Bacon)
                    {
                        Console.WriteLine("Bacon");
                    }
                    else if (ingrdient == Ingredients.Cheese)
                    {
                        Console.WriteLine("Cheese");
                    }
                    else if (ingrdient == Ingredients.Bread)
                    {
                        Console.WriteLine("Bread");
                    }
                    
                }
                Console.WriteLine();


            }
            AnyKey();
        }

        


        private void AddItemsToMenue()
        {
            Console.Clear();

            MenuItems items = new MenuItems();



            Console.Write("Describe the new meal. ");
            string describe = Console.ReadLine();
            items.Description = describe;


            Console.Write("How much does it cost? $");
            string cost = Console.ReadLine();
            items.Price = decimal.Parse(cost);

            Console.Write("What is the name of the meal? ");
                string name = Console.ReadLine();
            items.MealName = name;

            bool runMini = true;
                List<Ingredients> newItemIngredents = new List<Ingredients>();
            while (runMini)
            {

            Console.Write("What is in the meal? \n" +
                "1. Bread \n" +
                "2. Cheese \n" +
                "3. Bacon \n" +
                "4. Fries \n" +
                "5. Chicken \n" +
                "6. Veggies \n" +
                "7. Done Adding \n");

                string ingredientAnswer = Console.ReadLine();

                
                switch (ingredientAnswer.ToLower())
                {
                    case "1":
                    case "bread":
                    default:
                        newItemIngredents.Add(Ingredients.Bread);
                        break;
                    case "2":
                    case "cheese":
                        newItemIngredents.Add(Ingredients.Cheese);
                        break;
                    case "3":
                    case "bacon":
                        newItemIngredents.Add(Ingredients.Bacon);
                        break;
                    case "4":
                    case "fries":
                        newItemIngredents.Add(Ingredients.Fries);
                        break;
                    case "5":
                    case "chicken":
                        newItemIngredents.Add(Ingredients.Chicken);
                        break;
                    case "6":
                    case "veggies":
                        newItemIngredents.Add(Ingredients.Veggies);
                        break;
                    case "7":
                    case "done":
                    case "d":
                    case "exit":
                    case "e":
                        runMini = false;
                        break;

                }
                items.Ingredients = newItemIngredents;          

            }
            _menuRepo.AddToMenu(items);
            AnyKey();
        }

        public void RemoveItemsFromMenu()
        {
            Console.Clear();
            DisplayMenu();

            Console.Write("What meal number would you like to remove? ");
            string answer = Console.ReadLine();
            int mealNumber = int.Parse(answer);

            if (_menuRepo.RemoveItemByNumber(mealNumber))
            {
                Console.WriteLine("Meal has been removed!");
            }
            else
            {
                Console.WriteLine("No Meal found by that number!");
            }

            AnyKey();
            


        }


        private void SeedContent()
        {
            MenuItems sandyWitch = new MenuItems();
            List<Ingredients> bigOne = new List<Ingredients> { Ingredients.Bacon, Ingredients.Cheese };

            sandyWitch.Price = 3;
            sandyWitch.MealName = "The Big One";
            sandyWitch.Ingredients = bigOne;
            sandyWitch.Description = "This is a classic Bacon and Cheese dish that will light up your mouth. ";

            MenuItems chicken = new MenuItems();
            List<Ingredients> theSlapper = new List<Ingredients> { Ingredients.Chicken, Ingredients.Bacon, Ingredients.Bread, Ingredients.Fries };
            chicken.Price = 34.44m;
            chicken.MealName = "The Slapper";
            chicken.Ingredients = theSlapper;
            chicken.Description = "A gut busting, toe tapping, rollercoaster ride of your life in a meal";

            _menuRepo.AddToMenu(chicken);

            _menuRepo.AddToMenu(sandyWitch);

        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue..........");
            Console.ReadKey();
        }

    }
}
