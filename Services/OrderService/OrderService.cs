using System;
using System.Collections.Generic;
using System.Linq;
using TinyCR;
using TinyCRM.Services.CustomerService;
using TinyCRM.Services.OrderService;


namespace TinyCRM
{
    public class OrderService : IOrderService 
    {
        private List<Order> OrdersList = new List<Order>();
        //List that contains active orders

        public static List<Order> ProcessingOrders = new List<Order>();
        //Create a new order and add in the system
        public bool AddOrder(string customerId, AddOrderOption addOrder)
        {
            if (addOrder == null) {
                return false;
            }
            if (CustomerService.CustomerList.Where(p => p.CustomerId == customerId) == null) {
                return false;
            }
            if (addOrder.OrderProductList == null) {
                Console.WriteLine("The list of products must not be null");
                return false;
            }
            var customer1 = CustomerService.GetCustomerById(customerId);
            if (customer1 == null) {
                Console.WriteLine("Invalid customer's data");
                return false;
            }
            var neworder = new Order()
            {
                CustomerName = CustomerService.CustomerList.Find(p => p.CustomerId == customerId).LastName,
                OrderStatus =0,
                DeliveryAddress = addOrder.DeliveryAddress,
                OrderProductList = isExistedProduct(addOrder.OrderProductList),
                TotalMount = CalculateOrderCost(isExistedProduct(addOrder.OrderProductList)),
                CustomerId = customerId
            };
            Console.WriteLine("The order id is" + neworder.OrderId);
          
            ProcessingOrders.Add(neworder);
            OrdersList.Add(neworder);
            return true;
        }

        public string RandomGeneratorOrderId()
        {
            Random r = new Random();
            var randomNum = r.Next(1, 1000);
            var rrandomId = randomNum.ToString("#A#" + r.Next(1, 50) + "#Z#");
            return rrandomId;
        }

        //Update the details of a not-executed order
        public bool UpdateOrder(string orderId, UpdateOrderOption orderForUpdate)
        {
            if (OrdersList.Find(o => o.OrderId.Equals(orderId)) == null) {
                return false;
            }
            var order = OrdersList.Find(o => o.OrderId.Equals(orderId));
            var id = OrdersList.Find(o => o.OrderId.Equals(orderId)).CustomerId;
            if (OrdersList.Find(o => o.OrderId.Equals(orderId)).OrderStatus!=0) {
                return false;
            }
            if (orderForUpdate.TobeCancel == true) {
                OrdersList.Remove(OrdersList.Find(o => o.OrderId.Equals(orderId)));
                if (CustomerService.CustomerList.Find(p => p.CustomerId == id).Orders != null) {
                    CustomerService.CustomerList.Find(p => p.CustomerId == id).Orders.Remove(order);
                    return true;
                }
            }
            if (!string.IsNullOrWhiteSpace(orderForUpdate.DeliveryAddress)) {
                OrdersList.Find(o => o.OrderId.Equals(orderId)).DeliveryAddress = orderForUpdate.DeliveryAddress;
            }
            return true;

        }

        //Search an order by id
        public Order GetOrderById(string orderid)
        {
            if (string.IsNullOrWhiteSpace(orderid)) {
                throw new ArgumentNullException("OrderId must not be null");
                return null;
            }
            Order detailsOrder = OrdersList.Find(s => s.OrderId.Equals(orderid));
            if (detailsOrder == null) {
                Console.WriteLine("Does not exist order with this orderid");
                return null;
            }
            Console.WriteLine(detailsOrder.OrderId + " " +detailsOrder.DeliveryAddress+ " " +detailsOrder.CustomerName
                +detailsOrder.OrderStatus+" " );
            return detailsOrder;

        }



        //Check if a product exists
        public List<Product> isExistedProduct(List<Product> orderproductlist)
        {
            List<Product> validlist = new List<Product>();
            foreach (Product i in orderproductlist) {
                if (Program.listOfProducts.Contains(i)) {
                    validlist.Add(i);
                }

            }
            return validlist;
        }

        //Calculate the cost of an order
        public decimal CalculateOrderCost(List<Product> productlist)
        {
            var totalcost = 0.00M;
            foreach (Product i in productlist) {
                totalcost += i.Price;
            }
            return totalcost;
        }
    }
}
