using System;
using System.Collections.Generic;

namespace TinyCRM
{
    public class Order
    {
        /// <summary>
        /// CustomerName of an order
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// The status of order
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Id of an order
        /// </summary>
        public string OrderId {get; private set;}

        /// <summary>
        /// CustomerId of an order
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// DeliveryAddress of an order
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// TotalMount of an order
        /// </summary>
        public decimal TotalMount { get; set; }

        /// <summary>
        /// ProductList of an order
        /// </summary>
        public List<Product> OrderProductList;

        public Order()
        {
            OrderId = RandomGeneratorOrderId();
        }
       
        //Generate order ID
        public string RandomGeneratorOrderId()
        {
            Random r = new Random();
            var randomNum = r.Next(1, 1000);
            var rrandomId = randomNum.ToString("#A#" + r.Next(1, 50) + "#Z#");
            return rrandomId;
        }
    }
}

