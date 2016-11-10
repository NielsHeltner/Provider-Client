using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.page
{
    public class Product
    {
        private int id;
        public string productName { get; private set; }
        public string description { get; private set; }
        public double price { get; private set; }
        public string packaging { get; private set; }
        public string chemicalName { get; private set; }
        public double density { get; private set; }
        public DateTime deliveryTime { get; private set; }

        /// <summary>
        /// The constructor to a product
        /// Make sure that the price isnt negativ
        /// </summary>
        /// <param name="ID">ID for this product</param>
        /// <param name="price">Price for this</param>
        /// <param name="productinfomation">Information about product</param>
        /// <param name="productname">The name of the product</param>
        /// <param name="delverytime">The estimated time for a delvery</param>
        public Product(int id, string productName, string description, double price, string packaging, string chemicalName, double density, DateTime deliveryTime)
        {
            this.id = id;
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.packaging = packaging;
            this.chemicalName = chemicalName;
            this.density = density;
            this.deliveryTime = deliveryTime;
        }
  
        /// <summary>
        /// The constructor to a product 
        /// Make sure that the price isnt negativ
        /// </summary>
        /// <param name="ID">ID for this product</param>
        /// <param name="price">Price for this</param>
        /// <param name="productinfomation">Information about product</param>
        /// <param name="productname">The name of the product</param>
        public Product(int id, string productName, string description, double price, string packaging, string chemicalName, double density) : 
            this(id, productName, description, price, packaging, chemicalName, density, default(DateTime)) { }
    }
}
