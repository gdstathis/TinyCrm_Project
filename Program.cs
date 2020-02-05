using System;
using System.Collections.Generic;
using System.Linq;
namespace TinyCRM
{
    class Program
    {   //In this list, saved all the products of the system
        public static List<Product> listOfProducts = new List<Product>();

        public static void Main(string[] args)
        {
            //Create 2 new customers
            Console.WriteLine("Create 2 customers\n");

            var CustomerService = new CustomerService();
            CustomerService.CreateNewCustomer(new AddCustomerOptions
            {
                FirstName = "George",
                LastName = "Stathis",
                EmailAddress = "georgestathis1996@gmail.com",
                VatNumber = "039660333",
                Phone="6983078378"
            });
            CustomerService.CreateNewCustomer(new AddCustomerOptions
            {
                FirstName = "Alexandros",
                LastName = "Papadopoulos",
                EmailAddress = "alexpapadopoulos@gmail.com",
                VatNumber = "152629060",
                Phone="6988883088",
               
            });
            Console.WriteLine("The new Customers are:");
            CustomerService.PrintList();
            
            //Update the name of a customer
            Console.WriteLine("\nUpdate the data of a customer (firstname)\n" +
                "Update the firstname of George to Georgios\n Insert George Stathis CustomerId");
            var k = Console.ReadLine();
            CustomerService.UpdateCustomerData(k, new TinyCR.UpdateCustomer()
            {
                FirstName = "Georgios",
                
            });
            CustomerService.PrintList();

            //Search active customers , with email georgestathis1996@gmail.com 
            Console.WriteLine("Search active customer with email of George");
            CustomerService.SearchCustomerData(new Services.CustomerService.SearchCustomerDatas{
                email="georgestathis1996@gmail.com"
            });

            //Create 3 new products and add them to the product list
            var product1 = new Product()
            {
                Id = "0001",
                Description = "A Lenovo laptop i3",
                Name = "LENOVO LAPTOP",
                Price=550
            };
            var product2 = new Product()
            {
                Id = "0002",
                Description = "A Lenovo laptop i5",
                Name = "LENOVO I5 LAPTOP",
                Price=650
            };
            var product3 = new Product()
            {
                Id = "0003",
                Description = "A Lenovo laptop i7",
                Name = "LENOVO I7 LAPTOP",
                Price=750
            };

            //Create a new order contains the 3 new products, and then update the DeliveryAddress
            Console.WriteLine("Create an order");
            var OrderService = new OrderService();
            var productlist = new List<Product>();
            listOfProducts.Add(product1); 
            listOfProducts.Add(product2); 
            listOfProducts.Add(product3);

            OrderService.AddOrder(k, new AddOrderOption
            {
                DeliveryAddress = "Stavroxwri,Kilkis",
                OrderProductList = listOfProducts,

            }) ;
         
            Console.WriteLine("Select an order by id\n");
            var pi = Console.ReadLine();
            OrderService.GetOrderById(pi);

            //Update selected order, then Cancel this order
            OrderService.UpdateOrder(pi, new Services.OrderService.UpdateOrderOption
            {
                DeliveryAddress="Nea Santa, Kilkis"
            });
            OrderService.GetOrderById(pi);

            Console.WriteLine("Cancel the order and then search if this order exists to the system");
            //Cancel updated order
            OrderService.UpdateOrder(pi, new Services.OrderService.UpdateOrderOption
            {
                TobeCancel = true
            }) ;

            OrderService.GetOrderById(pi);
        }
    }
}
