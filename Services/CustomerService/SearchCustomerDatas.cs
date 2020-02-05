using System;

namespace TinyCRM.Services.CustomerService
{
    public class SearchCustomerDatas 
    {
        /// <summary>
        /// DateCreated criteria
        /// </summary>
        public DateTime dateTo { get; set; }

        /// <summary>
        /// DateCreated criteria
        /// </summary>
        public DateTime dateFrom { get; set; }

        /// <summary>
        /// searching Vatnumber
        /// </summary>
        public string Vatnumber { get; set; }

        /// <summary>
        /// searching email
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// searching phone number
        /// </summary>
        public string phone { get; set; }
    }
}
