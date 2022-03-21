using CompanyOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void TestingAddAllEventCosts_ShouldReturnDecimal()
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
    }
}
