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
        public string owner { get; private set; }
        public List<Product> products { get; private set; }
        public Note note { get; set; }
        public string noteText
        {
            get
            {
                if (note == null)
                {
                    return "";
                }
                else
                {
                    return note.text;
                }
            }
        }

        public Page(string owner)
        {
            this.owner = owner;
            products = new List<Product>();
        }

        public Page(string owner, Note note)
        {
            this.owner = owner;
            this.note = note;
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

        public void AddProduct(List<Product> productList)
        {
            products.AddRange(productList);
        }
    }
}
