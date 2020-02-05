using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    public class Customer
    {
        /// <summary>
        ///Id of customer
        /// </summary>
        public string CustomerId{ get; private set; }

        /// <summary>
        /// Date that customer created in system
        /// </summary>
        public DateTimeOffset dateCreated { get;set;}

        /// <summary>
        /// Firstname of customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName of customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The order list of customer
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// VatNumber of customer
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// Email of customer
        /// </summary>
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// Phone number of customer
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// //ACTIVE -> TRUE
        /// </summary>
        public bool status = true;

        /// <summary>
        /// Total money that customer spends
        /// </summary>
        public decimal TotalMoney { get; set; }

        public Customer()
        {
            CustomerId = RandomGeneratorCustomerId();
        }

        //Generate a customer Id
        private static string RandomGeneratorCustomerId()
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
