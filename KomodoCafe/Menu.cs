using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{

    public enum Ingredients { Bread, Cheese, Bacon, Fries, Chicken, Veggies }
    public class Menu
    {

        //POCO


        public Menu() { }

        public Menu(List<MenuItems> fullMenu)
        {
            FullMenu = fullMenu;

        }

        public List<MenuItems> FullMenu { get; set; }



    }
}
