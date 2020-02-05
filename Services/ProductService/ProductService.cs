using System.Collections.Generic;
using System.Linq;
namespace TinyCRM
{
    public class ProductService : IProductService
    {
        public List<Product> ProductsList = new List<Product>();

        /// <summary>
        /// Add product to the system
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool AddProduct(AddProductOptions options)
        {
            if (options == null) {
                return false;
            }

            var product = GetProductById(options.Id);

            if (product != null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return false;
            }

            if (options.Price <= 0) {
                return false;
            }

            if (options.ProductCategory ==
              ProductCategory.Invalid) {
                return false;
            }

            product = new Product()
            {
                Id = options.Id,
                Name = options.Name,
                Price = options.Price,
                Category = options.ProductCategory
            };

            product.Id = options.Id;
            product.Name = options.Name;
            product.Price = options.Price;
            product.Category = options.ProductCategory;

            ProductsList.Add(product);

            return true;
        }

        /// <summary>
        /// Update product details
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool UpdateProduct(string productId,
            UpdateProductOptions options)
        {
            if (options == null) {
                return false;
            }

            var product = GetProductById(productId);
            if (product == null) {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(options.Description)) {
                product.Description = options.Description;
            }

            if (options.Price != null &&
              options.Price <= 0) {
                return false;
            }
            if (options.Price != null) {
                if (options.Price <= 0) {
                    return false;
                } else {
                    product.Price = options.Price.Value;
                }
            }

            if (options.Discount != null &&
              options.Discount < 0) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Return a product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                return null;
            }

            return ProductsList.
                SingleOrDefault(s => s.Id.Equals(id));
        }
    }
}