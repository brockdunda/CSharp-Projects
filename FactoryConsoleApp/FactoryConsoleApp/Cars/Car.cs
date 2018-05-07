using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryConsoleApp.Cars
{
    public abstract class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string EngineSize { get; set; }
        public string Color { get; set; }
    }

    public class FordFiesta : Car
    {
        public FordFiesta()
        {
            Make = "Ford";
            Model = "Fiesta";
            EngineSize = "1.1";
        }
    }

    public class BMWX5 : Car
    {
        public BMWX5()
        {
            Make = "BMW";
            Model = "X5";
            EngineSize = "2.1";
        }
    }

    public interface ICreateCars
    {
        Car CreateCar(string color);
    }

    class FordFiestaFactory : ICreateCars
    {
        public Car CreateCar(string color)
        {
            return new FordFiesta() { Color = color };
        }
    }

    class BMWX5Factory : ICreateCars
    {
        public Car CreateCar(string color)
        {
            return new BMWX5() { Color = color };
        }
    }
}
