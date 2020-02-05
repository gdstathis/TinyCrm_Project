using System.Collections.Generic;

namespace TinyCRM
{
    public class AddOrderOption
    {   
        /// <summary>
        /// The deliveryAddress of new order
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// The productList of new order
        /// </summary>
        public List<Product> OrderProductList { get; set; }

        /// <summary>
        /// The customerId of new order
        /// </summary>
        public string Order_CustomerId { get; set; }
    }
}
