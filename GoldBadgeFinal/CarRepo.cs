using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinal
{
    public class CarRepo
    {
        private List<GasCars> _gas = new List<GasCars>();
        private List<ElectricCars> _electric = new List<ElectricCars>();
        private List<HybridCars> _hybrids = new List<HybridCars>();
       private List<Car> _allCars = new List<Car>();


        //c

        public bool AddGasCar(GasCars gasCar)
        {
            int startingCount = _gas.Count();
            _gas.Add(gasCar);

            _allCars.Add(gasCar);

            bool wasAdded = (_gas.Count() > startingCount) ? true : false;
            return wasAdded;

        }
        public bool AddElectricCar(ElectricCars eCar)
        {
            int startingCount = _electric.Count();
            _electric.Add(eCar);

            _allCars.Add(eCar);

            bool wasAdded = (_electric.Count() > startingCount) ? true : false;
            return wasAdded;

        }
        public bool AddHybridCar(HybridCars hybridCar)
        {
            int startingCount = _hybrids.Count();
            _hybrids.Add(hybridCar);
            _allCars.Add(hybridCar);

            bool wasAdded = (_hybrids.Count() > startingCount) ? true : false;
            return wasAdded;

        }


        //r

        public List<Car> GetAllCars()
        {
            return _allCars;
        }

        public List<GasCars> GetAllGasCars()
        {
            return _gas;
        }

        public List<ElectricCars> GetAllElectricCars()
        {
            return _electric;
        }
        public List<HybridCars> GetAllHybridCars()
        {
            return _hybrids;
        }

       /* public Car GetCarByModel(string model)
        {
            foreach(Car car in _allCars)
            {
                if (car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }*/

        public ElectricCars GetECarByModel(string model)
        {
            foreach (ElectricCars car in _electric)
            {
                if (car.Model.ToLower() == model.ToLower())
                {
                    return car;
                }
            }
            return null;
        }
        public GasCars GetGCarByModel(string model)
        {
            foreach (GasCars car in _gas)
            {
                if (car.Model.ToLower() == model.ToLower())
                {
                    return car;
                }
            }
            return null;
        }
        public HybridCars GetHCarByModel(string model)
        {
            foreach (HybridCars car in _hybrids)
            {
                if (car.Model.ToLower() == model.ToLower())
                {
                    return car;
                }
            }
            return null;
        }




        //u maybe do a serial number? 
        public bool UpdateExistingHCar(HybridCars newCar, string model)
        {
            HybridCars oldCar = GetHCarByModel(model);
            if (oldCar != null)
            {
                oldCar.Model = newCar.Model;
                oldCar.Make = newCar.Make;
                oldCar.Cost = newCar.Cost;
                oldCar.IsItFast = newCar.IsItFast;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateExistingGCar(GasCars newCar, string model)
        {
            GasCars oldCar = GetGCarByModel(model);
            if (oldCar != null)
            {
                oldCar.Model = newCar.Model;
                oldCar.Make = newCar.Make;
                oldCar.Cost = newCar.Cost;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateExistingECar(ElectricCars newCar, string model)
        {
            ElectricCars oldCar = GetECarByModel(model);
            if (oldCar != null)
            {
                oldCar.Model = newCar.Model;
                oldCar.Make = newCar.Make;
                oldCar.Cost = newCar.Cost;
                return true;
            }
            else
            {
                return false;
            }

        }



        //d
        public bool RemoveHCarByModel(string model)
        {
            HybridCars car = GetHCarByModel(model);
            if (car != null)
            {
                bool deleteCar = _hybrids.Remove(car);
                return deleteCar;
            }
            else
                return false;
        }
        public bool RemoveGCarByModel(string model)
        {
            GasCars car = GetGCarByModel(model);
            if (car != null)
            {
                bool deleteCar = _gas.Remove(car);
                return deleteCar;
            }
            else
                return false;
        }
        public bool RemoveECarByModel(string model)
        {
            ElectricCars car = GetECarByModel(model);
            if (car != null)
            {
                bool deleteCar = _electric.Remove(car);
                return deleteCar;
            }
            else
                return false;
        }


    }
}
