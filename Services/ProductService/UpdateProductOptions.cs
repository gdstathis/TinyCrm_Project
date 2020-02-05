using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRM
{
        public class UpdateProductOptions
        {
            /// <summary>
            /// Cost of product
            /// </summary>
            public decimal? Price { get; set; }

            /// <summary>
            /// Discount of price
            /// </summary>
            public decimal? Discount { get; set; }

            /// <summary>
            /// Description of product
            /// </summary>
            public string Description { get; set; }
        }
    }
