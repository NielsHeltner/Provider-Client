using System;
using System.Collections.Generic;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Provider.domain.page
{
    public interface IPageManager
    {

        List<Page> pages { get; set; }

        List<Page> Search(string searchTerm);

        void GetSuppliers();

        void ManageSupplierPage(Page page);

        void AddNoteToSupplier(string supplierName, string editor, string text);

        void EditProduct(Product product, string newProductName, string newChemicalName, Double newMolWeight,
            string newDescription, Double newPrice, string newPackaging, string newDeliveryTime);

        void CreateProduct(string productName, string chemicalName, Double molWeight, string description, Double price,
            string packaging, string deliveryTime, string producer);

        void DeleteProduct(Product product);

    }
}