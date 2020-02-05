using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRM
{
    public class AddProductOptions
    {   /// <summary>
        /// Product Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product category enumeration
        /// </summary>
        public ProductCategory ProductCategory { get; set; }
    }
}
