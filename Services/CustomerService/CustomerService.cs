using System;
using System.Collections.Generic;
using System.Linq;
using TinyCRM.Services.CustomerService;

namespace TinyCRM
{
    public class CustomerService : ICustomerService
    {   //A list that contains all existed customers
        public static List<Customer> CustomerList = new List<Customer>();
        /*For the creation of a newUser must submit a not null Firstname, Lastname, Email
         *and VatNumber. Then, create the new customer and add him in customer list
         *Then, created a new Customer with submited data and add this into CustomerList.
         */
        public bool CreateNewCustomer(AddCustomerOptions customer)
        {
            if (customer == null) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.FirstName)) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.LastName)) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.EmailAddress)) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.Phone)) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.VatNumber) || CustomerList.Where(s => s.VatNumber.Equals(customer.VatNumber)) == null) {
                return false;
            }

            var newCustomer = new Customer()
            {
                EmailAddress = customer.EmailAddress,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                VatNumber = customer.VatNumber,
                Phone = customer.Phone,
                status = true,
                dateCreated = DateTimeOffset.UtcNow
            };

            if (CustomerList.Contains(newCustomer)) {
                return false;
            }
            CustomerList.Add(newCustomer);
            return true;
        }

        /*Takes as argument customerId and the data that will be changed (LastName,FirstName
        *Email and VatNumber). Check if the customer with this Id is already exist and then 
        *change the data.     
        */
        public bool UpdateCustomerData(string CustomerId, TinyCR.UpdateCustomer UpCustomer)
        {
            if (UpCustomer == null) { 
                return false; 
            }
            try {
                if (CustomerList.Find(c => c.CustomerId.Equals(CustomerId)) == null) {
                    return false;
                }
            }catch {
                throw new Exception("Empty customer list");
            }
            var customer = CustomerList.Find(p => p.CustomerId.Equals(CustomerId));

            CustomerList.Remove(customer);

            if (!string.IsNullOrWhiteSpace(UpCustomer.FirstName)) {
                customer.FirstName = UpCustomer.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(UpCustomer.LastName)) {
                customer.LastName = UpCustomer.LastName;
            }
            if ((UpCustomer.status == false)) {
                customer.status = UpCustomer.status;
            }
            if (!string.IsNullOrWhiteSpace(UpCustomer.EmailAddress)) {
                customer.EmailAddress = UpCustomer.EmailAddress;
            }
            if (!string.IsNullOrWhiteSpace(UpCustomer.Phone)) {
                customer.Phone = UpCustomer.Phone;
            }
            if (UpCustomer.VatNumber != null) {
                customer.VatNumber = UpCustomer.VatNumber;
            }
            
            CustomerList.Add(customer);
            
            return true;
        }

        /*Return a list of active customers, filtered with a number of criteria such as
         *DateCreated, VatNumber and email.
         */
        public List<Customer> SearchCustomerData(SearchCustomerDatas search)
        {
            var ActiveCustomerList = CustomerService.CustomerList.Where(c => c.status==false).ToList();
            Console.WriteLine("CustomerId\tEmailAddress\tFirstName\tLastName\tVatNumber");
            
            foreach(Customer i in ActiveCustomerList) {
                Console.WriteLine($"{i.CustomerId}  {i.EmailAddress}  {i.FirstName}  {i.LastName}  {i.VatNumber}    {i.dateCreated}");
            }

            if (search.dateFrom != null) {
                ActiveCustomerList.Where(d => d.dateCreated > search.dateFrom);
            }
            if (search.dateTo != null) {
                ActiveCustomerList.Where(d => d.dateCreated < search.dateTo);
            }
            if (!string.IsNullOrWhiteSpace(search.email)){
                ActiveCustomerList.Where(d => d.EmailAddress.Equals(search.email)); 
            }
            if (!string.IsNullOrWhiteSpace(search.email)) {
                ActiveCustomerList.Where(d => d.EmailAddress.Equals(search.email));
            }
            if (!string.IsNullOrWhiteSpace(search.Vatnumber)) {
                ActiveCustomerList.Where(d => d.VatNumber.Equals(search.Vatnumber));
            }
            if (ActiveCustomerList == null) {
                Console.WriteLine("Does not exist order with this details");
                //return null;
            }
            return ActiveCustomerList;
        }

        //Take as arguments a customerId and return customer's data
        public static Customer GetCustomerById(string customId)
        {
            Customer customer = CustomerList.Where(s => s.CustomerId.Equals(customId)).FirstOrDefault();
            return customer;
        }

        //Print the data's of CustomerList
        public void PrintList()
        {
            Console.WriteLine("CustomerId\tEmailAddress\tFirstName\tLastName\tVatNumber");
            foreach (Customer i in CustomerList) {
                Console.WriteLine($"{i.CustomerId} {i.EmailAddress}     {i.FirstName}  " +
                    $"{i.LastName}  {i.VatNumber}    {i.dateCreated}");
            }
        }

        //Generate a customer Id
        public static string RandomGeneratorCustomerId()
        {
            Random r = new Random();
            var randomNum = r.Next(1, 1000);
            var rrandomId = randomNum.ToString("#A" + r.Next(1, 50) + "Z#");
            if (CustomerService.CustomerList.Where(s => s.CustomerId == rrandomId) == null) {
                RandomGeneratorCustomerId();
            }
            return rrandomId;
        }

    }
}
