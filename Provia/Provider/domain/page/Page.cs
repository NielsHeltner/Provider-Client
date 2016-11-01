using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.page
{
    class Page
    {
        public Supplier owner { get; }
        private List<Product> product;


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
    }
}
