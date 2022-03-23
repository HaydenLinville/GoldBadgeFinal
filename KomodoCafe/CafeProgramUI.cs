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
            foreach (MenuItems items in menus)
            {
                Console.WriteLine($"Meal Number: {items.MealNumber} \n" +
                    $"Price: ${items.Price} \n" +
                    $"Meal Name: {items.MealName} \n" +
                    $"Description: {items.Description}\n" +
                    $"Ingredients: ");
                foreach (var ingrdient in items.Ingredients)
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

            Console.Write("What is the name of the meal? ");
            string name = Console.ReadLine();
            items.MealName = name;

            Console.Write("Describe the new meal. ");
            string describe = Console.ReadLine();
            items.Description = describe;

            Console.Write("How much does it cost? $");
            string cost = Console.ReadLine();
            if (cost != "")
            {
                items.Price = decimal.Parse(cost);
            }


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
                        Console.Clear(); newItemIngredents.Add(Ingredients.Bread); Console.WriteLine($"Bread added to {items.MealName}. Would you like to add anything else?");
                        break;
                    case "2":
                    case "cheese":
                        Console.Clear(); newItemIngredents.Add(Ingredients.Cheese); Console.WriteLine($"Cheese added to {items.MealName}. Would you like to add anything else?");
                        break;
                    case "3":
                    case "bacon":
                        Console.Clear(); newItemIngredents.Add(Ingredients.Bacon); Console.WriteLine($"Bacon added to {items.MealName}. Would you like to add anything else?");
                        break;
                    case "4":
                    case "fries":
                        Console.Clear(); newItemIngredents.Add(Ingredients.Fries); Console.WriteLine($"Fries added to {items.MealName}. Would you like to add anything else?");
                        break;
                    case "5":
                    case "chicken":
                        Console.Clear(); newItemIngredents.Add(Ingredients.Chicken); Console.WriteLine($"Chicken added to {items.MealName}. Would you like to add anything else?");
                        break;
                    case "6":
                    case "veggies":
                        Console.Clear(); newItemIngredents.Add(Ingredients.Veggies); Console.WriteLine($"Veggies added to {items.MealName}. Would you like to add anything else?");
                        break;
                    case "7":
                    case "done":
                    case "d":
                    case "exit":
                    case "e":
                        if (newItemIngredents.Count > 0) { runMini = false; }
                        else Console.WriteLine("You must add at least one item");
                        break;

                }
                items.Ingredients = newItemIngredents;

            }

            if (_menuRepo.AddToMenu(items))
            {
                Console.WriteLine($"{items.MealName} added to the Menu");
            }
            else { Console.WriteLine("Item not added try again"); }
            AnyKey();
        }

        public void RemoveItemsFromMenu()
        {
            Console.Clear();
            DisplayMenuDelete();

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


        private void DisplayMenuDelete()
        {
            Console.Clear();
            List<Menu> menus = _menuRepo.GetMenu();
            foreach (MenuItems items in menus)
            {
                Console.WriteLine($"Meal Number: {items.MealNumber} \n" +
                    $"Price: ${items.Price} \n" +
                    $"Meal Name: {items.MealName} \n" +
                    $"Description: {items.Description}\n" +
                    $"Ingredients: ");
                foreach (var ingrdient in items.Ingredients)
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

        }




        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue..........");
            Console.ReadKey();
        }

    }
}
