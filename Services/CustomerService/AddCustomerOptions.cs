using System;
using System.Linq;
namespace TinyCRM
{
    public class AddCustomerOptions
    {
        /// <summary>
        /// Firstname of newCustomer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname of newCustomr
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// VatNumber of newCustomer
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// Email of newCustomer
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number of newcustomer
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Status of newCustomer
        /// active->true   inactive->false
        /// </summary>
        private bool st;
        public bool Status { 
            get=> st;
            private set => st = true; 
        }
    }
}
