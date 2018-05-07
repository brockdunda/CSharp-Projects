using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryConsoleApp.PaymentFactory;

namespace FactoryConsoleApp
{
    abstract class Computer
    {
        public abstract int Mhz { get; }
    }//Computer

    abstract class ComputerFactory
    {
        public abstract Computer GetComputer();
    }//ComputerFactorys

    class ConcreteComputer : Computer
    {
        int _mhz = 500;
        public override int Mhz
        {
            get { return _mhz; }
        }//Mhz
    }//ConcreteComputer

    class ConcreteComputerFactory : ComputerFactory
    {
        public override Computer GetComputer()
        {
            return new ConcreteComputer();
        }//GetComputer
    }//ConcreteComputerFactory

    class ComputerAssembler
    {
        public void AssembleComputer(ComputerFactory factory)
        {
            Computer computer = factory.GetComputer();
            Console.WriteLine("assembled a {0} running at {1} MHz",
               computer.GetType().FullName, computer.Mhz);
        }//AssembleComputer
    }//ComputerAssembler

    class BrandXComputer : Computer
    {
        int _mhz = 1500;
        public override int Mhz
        {
            get { return _mhz; }
        }//Mhz
    }//BrandXComputer

    class BrandXFactory : ComputerFactory
    {
        public override Computer GetComputer()
        {
            return new BrandXComputer();
        }//GetComputer
    }//BrandXFactory

    class MainClass
    {
        static void Main(string[] args)
        {
            ComputerFactory factory = null;

            if (args.Length > 0 && args[0] == "BrandX")
                factory = new BrandXFactory();
            else
                factory = new ConcreteComputerFactory();

            new ComputerAssembler().AssembleComputer(factory);


            // Add in Product Factory
            var product = new Product();
            Console.WriteLine("Enter a product name: ");
            product.Name = Console.ReadLine();
            product.Description = "A New Product";
            Console.WriteLine("Enter a price: ");
            product.Price = Convert.ToInt32(Console.ReadLine());

            // With Bank using BestForMe
            PaymentProcessor payment = new PaymentProcessor();
            payment.MakePayment(PaymentMethod.BEST_FOR_ME, product);

            // Try with PayPal has access to all the payment methods
            PaymentProcessor2 paypal = new PaymentProcessor2();
            paypal.MakePayment(PaymentMethod.PAYPAL, product);

            // Added BillDesk Payment
            PaymentProcessor2 payment2 = new PaymentProcessor2();
            payment2.MakePayment(PaymentMethod.BILL_DESK, product);

            Console.WriteLine(product.Name + ' ' + product.Price);

            Console.Read();
        }//Main
    }//MainClass

}
