using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryConsoleApp.Cars
{
    public interface ICarSupplier
    {
        string CarColor
        {
            get;
        }
        void GetCarModel();
    }

    class Honda : ICarSupplier
    {
        public string CarColor
        {
            get { return "Red"; }
        }
        public void GetCarModel()
        {
            Console.WriteLine("Honda Car Model is Honda 2014");
        }
    }

    class BMW : ICarSupplier
    {
        public string CarColor
        {
            get { return "White"; }
        }
        public void GetCarModel()
        {
            Console.Write("BMW Car Model is BMW 2000");
        }
    }

    class Nano : ICarSupplier
    {
        public string CarColor
        {
            get { return "Yellow"; }
        }
        public void GetCarModel()
        {
            Console.Write("Nano Car Model is Nano 2016");
        }
    }

    static class CarFactory
    {
        public static ICarSupplier GetCarInstance(int Id)
        {
            switch (Id)
            {
                case 0:
                    return new Honda();
                case 1:
                    return new BMW();
                case 2:
                    return new Nano();
                default:
                    return null;
            }
        }
    }
}
