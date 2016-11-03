using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.page
{
    public class Page
    {
        public Supplier owner { get; private set; }
        public string name
        {
            get
            {
                return owner.userName;
            }
        }
        public List<Product> products { get; private set; }
        public string note { get; set; }

        public Page(Supplier owner)
        {
            this.owner = owner;
            products = new List<Product>();
        }

        /// <summary>
        /// Returns the specifik product with this product ID
        /// </summary>
        /// <param name="ID">ID of the requestede product</param>
        /// <returns>Product</returns>
        public Product GetProduct(int ID)
        {
            ///TODO: to be implementede
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
