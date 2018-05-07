using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryConsoleApp.PaymentFactory
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public interface IPaymentGateway
    {
        void MakePayment(Product product);
        // TODO: Should at some point also include user information
    }

    public class BankOne : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            // The bank specific API call to make the payment
            Console.WriteLine("Using bank1 to pay for {0}, amount {1}", product.Name, product.Price);
        }
    }

    public class BankTwo : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            // The bank specific API call to make the payment
            Console.WriteLine("Using bank2 to pay for {0}, amount {1}", product.Name, product.Price);
        }
    }

    public class PayPal : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            //The api call for PayPal
            Console.WriteLine("Using PayPal to pay for {0}, amount ${1}", product.Name, product.Price);
        }
    }

    public class BillDesk : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            // The api call for BillDesk
            Console.WriteLine("Using Bill Desk to pay for {0},  amount ${1}", product.Name, product.Price);
        }
    }

    public enum PaymentMethod
    {
        BANK_ONE,
        BANK_TWO,
        BEST_FOR_ME,

        PAYPAL,
        BILL_DESK
    }

    public class PaymentGatewayFactory
    {
        public virtual IPaymentGateway CreatePaymentGateway(PaymentMethod method, Product product)
        {
            IPaymentGateway gateway = null;

            switch (method)
            {
                case PaymentMethod.BANK_ONE:
                    gateway = new BankOne();
                    break;
                case PaymentMethod.BANK_TWO:
                    gateway = new BankTwo();
                    break;
                case PaymentMethod.BEST_FOR_ME:
                    if (product.Price < 50)
                    {
                        gateway = new BankTwo();
                    }
                    else
                    {
                        gateway = new BankOne();
                    }
                    break;
            }

            return gateway;
        }
    }

    public class PaymentProcessor
    {
        IPaymentGateway gateway = null;

        public void MakePayment(PaymentMethod method, Product product)
        {
            PaymentGatewayFactory factory = new PaymentGatewayFactory();
            this.gateway = factory.CreatePaymentGateway(method, product);
            this.gateway.MakePayment(product);
        }
    }

    public class PaymentGatewayFactory2 : PaymentGatewayFactory
    {
        public virtual IPaymentGateway CreatePaymentGateway(PaymentMethod method, Product product)
        {
            IPaymentGateway gateway = null;

            switch (method)
            {
                case PaymentMethod.PAYPAL:
                    gateway = new PayPal();
                    break;
                case PaymentMethod.BILL_DESK:
                    gateway = new BillDesk();
                    break;
                default:
                    base.CreatePaymentGateway(method, product);
                    break;
            }

            return gateway;
        }
    }

    public class PaymentProcessor2
    {
        IPaymentGateway gateway = null;

        public void MakePayment(PaymentMethod method, Product product)
        {
            PaymentGatewayFactory2 factory = new PaymentGatewayFactory2();
            this.gateway = factory.CreatePaymentGateway(method, product);

            this.gateway.MakePayment(product);
        }
    }
}
