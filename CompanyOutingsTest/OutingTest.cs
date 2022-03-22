using CompanyOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CompanyOutingsTest
{
    [TestClass]
    public class OutingTest
    {
        OutingRepo outRepo = new OutingRepo();
        Outings golf = new Outings(EventType.Golf, 20, new DateTime(2003, 9, 12));
        Outings concert = new Outings(EventType.Concert, 20, new DateTime(2003, 10, 5));
        Outings bowling = new Outings(EventType.Bowling, 10, new DateTime(2003, 5, 10));
        Outings aPark = new Outings(EventType.AmusementPark, 5, new DateTime(2003, 2, 10));
        Outings bPark = new Outings(EventType.AmusementPark, 10, new DateTime(2004, 4, 20));
        Outings cPark = new Outings(EventType.AmusementPark, 10, new DateTime(2003, 1, 4));

        [TestMethod]
        public void TestingAddAllEventCosts_ShouldBeEqual()
        {
            outRepo.AddOuting(concert);
            outRepo.AddOuting(golf);
            outRepo.AddOuting(bowling);
            outRepo.AddOuting(aPark);
            decimal totalTotal = golf.TotalCostForEvent + concert.TotalCostForEvent + bowling.TotalCostForEvent +aPark.TotalCostForEvent;

           

            Console.WriteLine(outRepo.AddAllEventCosts());
            Console.WriteLine(totalTotal);
            Assert.AreEqual(totalTotal, outRepo.AddAllEventCosts());

        }



        [TestMethod]
        public void TestAddOutingsAndGetAllOutings_ShouldReturnTrue()
        {
            outRepo.AddOuting(concert);
            outRepo.AddOuting(golf);
            outRepo.AddOuting(bowling);
            outRepo.AddOuting(aPark);
            

            Assert.IsTrue(outRepo.GetAllOutings().Contains(concert));


        }

        [TestMethod]
        public void GetOutingByType_ShouldReturnList()
        {
            outRepo.AddOuting(concert);
            outRepo.AddOuting(golf);
            outRepo.AddOuting(bowling);
            outRepo.AddOuting(aPark);

            List<Outings> list = outRepo.GetOutingByType(EventType.Golf);

            Assert.IsTrue(list.Contains(golf));

        }

        [TestMethod]
        public void AddAllCostsForType_ShouldReturnDecimal()
        {
            outRepo.AddOuting(aPark);
            outRepo.AddOuting(bPark);
            outRepo.AddOuting(cPark);

            decimal expected = aPark.TotalCostForEvent + bPark.TotalCostForEvent + cPark.TotalCostForEvent;
            decimal actual = outRepo.AddAllCostsForType(EventType.AmusementPark);

            Console.WriteLine(actual);
            Console.WriteLine(expected);
            
            Assert.AreEqual(expected, actual);

        }

    }
}
