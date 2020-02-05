using System.Collections.Generic;
using TinyCR;
using TinyCRM.Services.CustomerService;

namespace TinyCRM
{
    interface ICustomerService
    {
        //Add a new customer in system
         bool CreateNewCustomer(AddCustomerOptions newCustomer);

        //Update data of a customer
         bool UpdateCustomerData(string CustomerId, UpdateCustomer UpCustomer);

        //Search for customers 
         List<Customer> SearchCustomerData (SearchCustomerDatas search);
    }
}
