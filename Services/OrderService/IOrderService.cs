using TinyCRM.Services.OrderService;

namespace TinyCRM
{
    interface IOrderService 
    {   
        /// <summary>
        /// Add order to the system and customer 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="addOrder"></param>
        /// <returns></returns>
        bool AddOrder(string customerId, AddOrderOption addOrder);

        /// <summary>
        /// Change the details of an order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        bool UpdateOrder(string orderId, UpdateOrderOption order);

        /// <summary>
        /// Return the details of an order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOrderById(string orderId);
    }
}
