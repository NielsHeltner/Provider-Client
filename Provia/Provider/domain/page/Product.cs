using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.page
{
    public class Product
    {
        private int ID;
        public double price { get; private set; }
        public DateTime deliveryTime { get; private set; }
        public string productInfomation { get; private set; }
        public string productName { get; private set; }
        /// <summary>
        /// The constructor to a product
        /// Make sure that the price isnt negativ
        /// </summary>
        /// <param name="ID">ID for this product</param>
        /// <param name="price">Price for this</param>
        /// <param name="productinfomation">Information about product</param>
        /// <param name="productname">The name of the product</param>
        /// <param name="delverytime">The estimated time for a delvery</param>
        public Product(int ID, double price, string productInfomation, string productName, DateTime deliveryTime)
        {
            this.ID = ID;
            this.price = price;
            this.productInfomation = productInfomation;
            this.productName = productName;
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
        public Product(int ID, double price, string productInfomation, string productName) : 
            this(ID, price, productInfomation, productName, default(DateTime)){ }
    }
}
