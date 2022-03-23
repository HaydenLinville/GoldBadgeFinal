using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{

    
    public class MenuItems : Menu
    { 
        public MenuItems() { }

        public MenuItems(string name, string description, List<Ingredients> ingredients, decimal price)
        {
            MealName = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;

        }

        public string MealName { get; set; }

        public string Description { get; set; }

        public List<Ingredients> Ingredients { get; set; }

        public decimal Price { get; set; }

        public int MealNumber { get; set; }


    }
}
