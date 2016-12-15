using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Provider.domain.page
{
    public class PageManager : IPageManager
    {
        public List<Page> pages { get; set; }
        private PagemanagerApi pagemanagerApi;

        public PageManager()
        {
            pagemanagerApi = new PagemanagerApi("http://tek-sb3-glo0a.tek.sdu.dk:16832");
        }

        /// <summary>
        /// Searches through all suppliers and products with a given search term. 
        /// </summary>
        /// <param name="searchTerm">The term which is being searched on</param>
        /// <returns> A list with searchresults </returns>
        public List<Page> Search(string searchTerm)
        {
            searchTerm = searchTerm.ToUpper();
            ConcurrentDictionary<Page, byte> results = new ConcurrentDictionary<Page, byte>();
            pages.AsParallel().ForAll(page =>
            {
                if (page.Owner.ToUpper().Contains(searchTerm))
                {
                    results.GetOrAdd(page, new byte());
                }
                page.Products.AsParallel().ForAll(product =>
                {
                    if (product.ProductName.ToUpper().Contains(searchTerm))
                    {
                        results.GetOrAdd(page, new byte());
                    }
                });
            });
            return results.Keys.ToList();
        }

        /// <summary>
        /// Sets all the suppliers to the supplier list.
        /// </summary>
        public void GetSuppliers()
        {
            pages = pagemanagerApi.GetSuppliers();
        }

        /// <summary>
        /// Edits the information on a supplierpage. 
        /// </summary>
        /// <param name="page">The page which is being edited</param>
        public void ManageSupplierPage(Page page)
        {
            pagemanagerApi.UpdatePage(page.Owner, page.Description, page.Location, page.ContactInformation);
        }

        /// <summary>
        /// Adds a note to a supplie.
        /// </summary>
        /// <param name="supplierName">Name of the supplier</param>
        /// <param name="editor">Name of the person which is creating the note.</param>
        /// <param name="text">The note which is being added to the supplier</param>
        public void AddNoteToSupplier(string supplierName, string editor, string text)
        {
            pagemanagerApi.AddNoteToSupplier(supplierName, editor, text);
        }

        /// <summary>
        /// Edits an existing product.  It checks whether the logged in user has the rights to edit
        /// the product by checking if the user is the producer of the product or an administrator.
        /// </summary>
        /// <param name="product">The product which is being edited </param>
        /// <param name="newProductName">The new name of the product</param>
        /// <param name="newChemicalName">The new chemical name of the product</param>
        /// <param name="newMolWeight">The new mol weight of the product</param>
        /// <param name="newDescription">The new description of the product</param>
        /// <param name="newPrice">The new price of the product</param>
        /// <param name="newPackaging">The new packaging of the product</param>
        /// <param name="newDeliveryTime">The new deliverytime of the product</param>
        public void EditProduct(Product product, string newProductName, string newChemicalName, Double newMolWeight,
            string newDescription, Double newPrice, string newPackaging, string newDeliveryTime)
        {
            pagemanagerApi.EditProduct(product, newProductName, newChemicalName, newMolWeight, newDescription, newPrice, newPackaging, newDeliveryTime);
        }

        /// <summary>
        /// Creates a product with the given parameters. 
        /// </summary>
        /// <param name="productName">The name of the product</param>
        /// <param name="chemicalName">The chemical name of the product</param>
        /// <param name="molWeight">The mol weight of the product</param>
        /// <param name="description">The description of the product</param>
        /// <param name="price">The price of the product</param>
        /// <param name="packaging">The packaging of the product</param>
        /// <param name="deliveryTime">The deliverytime of the product</param>
        /// <param name="producer">The producer of the product</param>
        public void CreateProduct(string productName, string chemicalName, Double molWeight, string description, Double price, string packaging, string deliveryTime, string producer)
        {
            pagemanagerApi.CreateProduct(productName, chemicalName, molWeight, description, price, packaging, deliveryTime, producer);
        }

        /// <summary>
        /// This method deletes a product. It checks whether the logged in user has the rights to delete
        /// the product by checking if the user is the producer of the product or an administrator.
        /// If the logged in user has the rights the product gets deleted.
        /// </summary>
        /// <param name="product">The product which is being deleted</param>
        public void DeleteProduct(Product product)
        {
            pagemanagerApi.DeleteProduct(product);
        }

    }
}
