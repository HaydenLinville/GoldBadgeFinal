using GoldBadgeFinal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GreenPlanTest
{
    [TestClass]
    public class CarRepoTest
    {
        CarRepo car = new CarRepo();
        GasCars gas = new GasCars();
        ElectricCars electric = new ElectricCars();
        HybridCars hybrid = new HybridCars();

        [TestMethod]
        public void TestingAddGasCar_ShouldReturnTrue()
        {

            gas.Make = "Ford";
            gas.Model = "Focus";
            gas.Cost = 54668.56m;
            car.AddGasCar(gas);
            Assert.IsTrue(car.AddGasCar(gas));
        }

        [TestMethod]
        public void TestingAddElectricCar_ShouldReturnTrue()
        {

            electric.Make = "Chevy";
            electric.Model = "Ecar";
            electric.Cost = 5648.25m;
            car.AddElectricCar(electric);
            Assert.IsTrue(car.AddElectricCar(electric));
        }

        [TestMethod]
        public void TestingAddHybridCar_ShouldReturnTrue()
        {
            hybrid.Make = "Fake Make";
            hybrid.Model = "Fake Model";
            hybrid.Cost = 12345.67m;
            hybrid.IsItFast = true;
            car.AddHybridCar(hybrid);
            Assert.IsTrue(car.AddHybridCar(hybrid));
        }

        [TestMethod]
        public void TestingGetAllGasCars_ShouldReturnList()
        {
            gas.Make = "Fake Make";
            gas.Model = "Fake Model";
            gas.Cost = 12345.67m;
            car.AddGasCar(gas);
            Assert.IsTrue(car.GetAllGasCars().Contains(gas));    

        }

        [TestMethod]
        public void TestingGetAllElectricCars_ShouldReturnList()
        {
            electric.Make = "EFake Make";
            electric.Model = "EFake Model";
            electric.Cost = 345234.56m;
            car.AddElectricCar(electric);
            Assert.IsTrue(car.GetAllElectricCars().Contains(electric));

        }

        [TestMethod]
        public void TestingGetAllHybridCars_ShouldReturnList()
        {
            hybrid.Make = "HFake Make";
            hybrid.Model = "HFake Model";
            hybrid.Cost = 56846.25m;
            hybrid.IsItFast = false;
            car.AddHybridCar(hybrid);
            Assert.IsTrue(car.GetAllHybridCars().Contains(hybrid));

        }

        [TestMethod]
        public void TestingGetECarByModel_ShouldReturnElectricCar()
        {
            electric.Make = "EFake Make";
            electric.Model = "EFake Model";
            electric.Cost = 345234.56m;
            car.AddElectricCar(electric);
            ElectricCars eCar = new ElectricCars();
            car.GetECarByModel("EFake Model");
            Assert.IsTrue(car.GetECarByModel("EFake Model") == electric);
        }

        [TestMethod]
        public void GetGCarByModelTest_ShouldReturnGasCar()
        {
            gas.Make = "Fake Make";
            gas.Model = "Fake Model";
            gas.Cost = 12345.67m;
            car.AddGasCar(gas);
            Assert.IsTrue(car.GetGCarByModel("Fake Model") == gas);

        }

        [TestMethod]
        public void GetHCarByModelTest_ShouldReturnHCar()
        {
            hybrid.Make = "HFake Make";
            hybrid.Model = "HFake Model";
            hybrid.Cost = 56846.25m;
            hybrid.IsItFast = false;
            car.AddHybridCar(hybrid);
            Assert.IsTrue(car.GetHCarByModel("HFake Model") == hybrid);

        }

        [TestMethod]
        public void UpdateExistingGCar_ShouldReturnTrue()
        {
            gas.Make = "Fake Make";
            gas.Model = "Fake Model";
            gas.Cost = 12345.67m;
            car.AddGasCar(gas);
            GasCars newGas = new GasCars();
            newGas.Make = "New Make";
            newGas.Model = "New Model";
            newGas.Cost = 555m;
            car.UpdateExistingGCar(newGas, "Fake Model");
            Assert.IsTrue(gas.Make == "New Make");
        }

        [TestMethod]
        public void UpdateExistingHCar_ShouldReturnTrue()
        {
            hybrid.Make = "HFake Make";
            hybrid.Model = "HFake Model";
            hybrid.Cost = 56846.25m;
            hybrid.IsItFast = false;
            car.AddHybridCar(hybrid);
            HybridCars newHybrid = new HybridCars();
            newHybrid.Make = "New Make";
            newHybrid.Model = "New Model";
            newHybrid.Cost = 555m;
            newHybrid.IsItFast = true;
            car.UpdateExistingHCar(newHybrid, "HFake Model");
            Assert.IsTrue(hybrid.Model == "New Model");

        }

        [TestMethod]
        public void UpdateExistingECar_ShouldReturnTrue()
        {
            electric.Make = "EFake Make";
            electric.Model = "EFake Model";
            electric.Cost = 345234.56m;
            car.AddElectricCar(electric);
            ElectricCars eCar = new ElectricCars();
            eCar.Make = "NewMake";
            eCar.Model = "NewModel";
            car.UpdateExistingECar(eCar, "EFake Model");
            Assert.IsTrue(electric.Model == "NewModel");
        }


        [TestMethod]
        public void RemoveHCarByModel_ShouldReturnTrue()
        {
            hybrid.Make = "HFake Make";
            hybrid.Model = "HFake Model";
            hybrid.Cost = 56846.25m;
            hybrid.IsItFast = false;
            car.AddHybridCar(hybrid);
            car.RemoveHCarByModel("HFake Model");
            Assert.IsFalse(car.GetAllHybridCars().Contains(hybrid));
        }

        [TestMethod]
        public void RemoveGCarByModel_ShouldReturnTrue()
        {
            gas.Make = "Fake Make";
            gas.Model = "Fake Model";
            gas.Cost = 12345.67m;
            car.AddGasCar(gas);
            car.RemoveGCarByModel("fake model");
            Assert.IsFalse(car.GetAllGasCars().Contains(gas));
        }

        [TestMethod]
        public void RemoveECarByModel_ShouldReturnTrue()
        {
            electric.Make = "EFake Make";
            electric.Model = "EFake Model";
            electric.Cost = 345234.56m;
            car.AddElectricCar(electric);
            car.RemoveECarByModel("EFake Model");
            Assert.IsFalse(car.GetAllElectricCars().Contains(electric));
        }

    }
}
