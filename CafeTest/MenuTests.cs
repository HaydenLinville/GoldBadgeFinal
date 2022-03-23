using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeTest
{
    [TestClass]
    public class MenuTests
    {
        


        [TestMethod]
        public void TestingAddingMenuItem_ShouldReturnTrue()
        {
            MenuRepository ogMenu = new MenuRepository();
            MenuRepository menu = new MenuRepository();
            MenuItems menuItems = new MenuItems();
            
            List<Ingredients> chickenSandWitch = new List<Ingredients>();

            chickenSandWitch.Add(Ingredients.Chicken);
            chickenSandWitch.Add(Ingredients.Bread);

            menuItems.Price = 3.23m;
            menuItems.MealName = "Steve";
            menuItems.Description = "What a great Steve";
            menuItems.Ingredients = chickenSandWitch;

            menu.AddToMenu(menuItems);

            Assert.IsTrue(menu != ogMenu);

        }

        [TestMethod]
        public void TestingGettingItemByNumber_ShouldReturnTrue()
        {

            MenuRepository menu = new MenuRepository();
            MenuItems menuItems = new MenuItems();

            List<Ingredients> chickenSandWitch = new List<Ingredients>();

            chickenSandWitch.Add(Ingredients.Chicken);
            chickenSandWitch.Add(Ingredients.Bread);

            menuItems.Price = 3.23m;
            menuItems.MealName = "Steve";
            menuItems.Description = "What a great Steve";
            menuItems.Ingredients = chickenSandWitch;
            menu.AddToMenu(menuItems);

            menu.GetItemByNumber(1);

            Assert.IsTrue(menu.GetItemByNumber(1) == menuItems);

        }

        [TestMethod]
        public void TestingGetMenu_ShouldReturnTrue()
        {
            MenuRepository menu = new MenuRepository();
            MenuItems menuItems = new MenuItems();

            List<Ingredients> chickenSandWitch = new List<Ingredients>();

            chickenSandWitch.Add(Ingredients.Chicken);
            chickenSandWitch.Add(Ingredients.Bread);

            menuItems.Price = 3.23m;
            menuItems.MealName = "Steve";
            menuItems.Description = "What a great Steve";
            menuItems.Ingredients = chickenSandWitch;
            menu.AddToMenu(menuItems);

            menu.GetMenu();

            Assert.IsTrue(menu.GetMenu().Contains(menuItems));

        }

        [TestMethod]
        public void TestingRemoveItemsByNumer_ShouldReturnTrue()
        {
            MenuRepository ogMenu = new MenuRepository();
            MenuRepository menu = new MenuRepository();
            MenuItems menuItems = new MenuItems();

            List<Ingredients> chickenSandWitch = new List<Ingredients>();

            chickenSandWitch.Add(Ingredients.Chicken);
            chickenSandWitch.Add(Ingredients.Bread);

            menuItems.Price = 3.23m;
            menuItems.MealName = "Steve";
            menuItems.Description = "What a great Steve";
            menuItems.Ingredients = chickenSandWitch;
            menu.AddToMenu(menuItems);

            menu.RemoveItemByNumber(1);

            Assert.IsFalse(menu.GetMenu().Contains(menuItems));

        }



    }
}

