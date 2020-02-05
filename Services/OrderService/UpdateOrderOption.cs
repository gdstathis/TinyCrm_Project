namespace TinyCRM.Services.OrderService
{
    public class UpdateOrderOption
    {
        /// <summary>
        /// The deliveryaddress that will be changed in order
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// The CustomerId of the order 
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// A bool variable for cancel an order
        /// </summary>
        public bool TobeCancel { get; set; }

    }
}
