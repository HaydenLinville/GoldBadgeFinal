using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepository
    {

        private List<Menu> _menu = new List<Menu>();
        protected int _mealId = 1;


        //C,
        public bool AddToMenu(MenuItems menuItem)
        {
            int startingCount = _menu.Count();
            menuItem.MealNumber = _mealId;
            _menu.Add(menuItem);
            _mealId++;
            bool wasAdded = (_menu.Count() > startingCount) ? true : false;
            return wasAdded;

        }


        public MenuItems GetItemByNumber(int mealNumber)
        {
            foreach(MenuItems items in _menu)
            {
                if(mealNumber == items.MealNumber)
                {
                    return items;
                }
            }
            return null;
        }

        //R
        public List<Menu> GetMenu()
        {
            return _menu;
        }

       

        public bool RemoveItemByNumber(int id)
        {
            MenuItems removeItem = GetItemByNumber(id);

            if (removeItem != null)
            {
                bool itemGone = _menu.Remove(removeItem);
                return itemGone;
            }
            else
                return false;
        }

    }
}
