using System;
using System.Windows;
using IO.Swagger.Model;
using Provider.domain;
using Provider.domain.bulletinboard;
using Page = System.Windows.Controls.Page;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for CreateNewPost.xaml
    /// </summary>
    public partial class CreateNewProductPage : Page
    {
        SupplierInformation viewSupplierInformation;
        public CreateNewProductPage(SupplierInformation viewSupplierInformation)
        {
            InitializeComponent();
            OwnerTextBlock.Text = Controller.instance.GetLoggedInUser().Username;
            CreationDateTextBlock.Text = DateTime.Now.ToString();
            this.viewSupplierInformation = viewSupplierInformation;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool passedParseCheck = true;
            try
            {
                double density = Double.Parse(ProductDensity.Text);
                int price = Int32.Parse(ProductPrice.Text);
            } catch (FormatException exception)
            {
                passedParseCheck = false;
                MessageBox.Show("Fejl i molvægt og/eller pris");
            }
            if (passedParseCheck)
            {
                Controller.instance.CreateProduct(ProductName.Text,ProductChemName.Text,ProductDensity.Text,ProductDescription.Text,ProductPrice.Text,ProductPackaging.Text,ProductDeliveryTime.Text,OwnerTextBlock.Text);
                viewSupplierInformation.Reloadpage(true);
            }
        }

        private void ProductName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
