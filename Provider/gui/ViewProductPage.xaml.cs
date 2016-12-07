using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IO.Swagger.Model;
using Page = System.Windows.Controls.Page;
using Provider.domain;
using System.IO;
using System.Windows.Media.Animation;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for ViewProductPage.xaml
    /// </summary>
    public partial class ViewProductPage : Page
    {
        private SupplierInformation supplierInformationPage;
        private Product product;

        public ViewProductPage(Product product, SupplierInformation supplierInformationPage)
        {
            InitializeComponent();
            this.supplierInformationPage = supplierInformationPage;
            this.product = product;
            productNameTextBox.Text = product.ProductName;
            chemicalNameTextBox.Text = product.ChemicalName;
            molValueTextBox.Text = product.MolWeight.Value.ToString();
            priceTextBox.Text = product.Price.Value.ToString();
            packetingTextBox.Text = product.Packaging;
            deliveryTimeTextBox.Text = product.DeliveryTime;
            descriptionTextBox.Text = product.Description;
            producerNameTextBox.Text = product.Producer;
            HideButtons();
        }

        private void BackToListView(object sender, RoutedEventArgs e)
        {
            supplierInformationPage.Reloadpage(false);
        }

        private void OpenPDFBotton(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.instance.GetPDF(product.Id);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fejl ved indlæsning af PDF", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            if (productNameTextBox.IsReadOnly)
            {
                deleteProduct.Visibility = Visibility.Visible;
                productNameTextBox.Background = null;
                productNameTextBox.IsReadOnly = false;
                productNameTextBox.AcceptsReturn = true;
                productNameTextBox.IsUndoEnabled = true;
                productNameTextBox.Cursor = Cursors.IBeam;
                productNameTextBox.ToolTip = "Write the name of your product";
                chemicalNameTextBox.Background = null;
                chemicalNameTextBox.IsReadOnly = false;
                chemicalNameTextBox.AcceptsReturn = true;
                chemicalNameTextBox.IsUndoEnabled = true;
                chemicalNameTextBox.Cursor = Cursors.IBeam;
                chemicalNameTextBox.ToolTip = "Write the chemicalname of your product";
                molValueTextBox.Background = null;
                molValueTextBox.IsReadOnly = false;
                molValueTextBox.AcceptsReturn = true;
                molValueTextBox.IsUndoEnabled = true;
                molValueTextBox.Cursor = Cursors.IBeam;
                molValueTextBox.ToolTip = "Write the MOL value of your product";
                priceTextBox.Background = null;
                priceTextBox.IsReadOnly = false;
                priceTextBox.AcceptsReturn = true;
                priceTextBox.IsUndoEnabled = true;
                priceTextBox.Cursor = Cursors.IBeam;
                priceTextBox.ToolTip = "Write the price of your product";
                packetingTextBox.Background = null;
                packetingTextBox.IsReadOnly = false;
                packetingTextBox.AcceptsReturn = true;
                packetingTextBox.IsUndoEnabled = true;
                packetingTextBox.Cursor = Cursors.IBeam;
                packetingTextBox.ToolTip = "Write the chemicalname of your product";
                descriptionTextBox.Background = null;
                descriptionTextBox.IsReadOnly = false;
                descriptionTextBox.AcceptsReturn = true;
                descriptionTextBox.IsUndoEnabled = true;
                descriptionTextBox.Cursor = Cursors.IBeam;
                chemicalNameTextBox.ToolTip = "Write the chemicalname of your product";
                deliveryTimeTextBox.Background = null;
                deliveryTimeTextBox.IsReadOnly = false;
                deliveryTimeTextBox.AcceptsReturn = true;
                deliveryTimeTextBox.IsUndoEnabled = true;
                deliveryTimeTextBox.Cursor = Cursors.IBeam;
                chemicalNameTextBox.ToolTip = "Write the chemicalname of your product";
                editProduct.Content = "Gem";
            }
            else
            {
                bool passedChecked = true;
                try
                {
                    int price = Int32.Parse(priceTextBox.Text);
                    double molWeight = Double.Parse(molValueTextBox.Text);
                }
                catch (FormatException exeception)
                {
                    wrongInput.Visibility = Visibility.Visible;
                    passedChecked = false;
                }
                if (passedChecked)
                {
                    wrongInput.Visibility = Visibility.Hidden;
                    Controller.instance.EditProduct(product, productNameTextBox.Text, chemicalNameTextBox.Text,
                        Double.Parse(molValueTextBox.Text), descriptionTextBox.Text, Double.Parse(priceTextBox.Text), packetingTextBox.Text,
                        deliveryTimeTextBox.Text);
                    product.ProductName = productNameTextBox.Text;
                    product.ChemicalName = chemicalNameTextBox.Text;
                    product.MolWeight = Double.Parse(molValueTextBox.Text);
                    product.Description = descriptionTextBox.Text;
                    product.Price = Double.Parse(priceTextBox.Text);
                    product.Packaging = packetingTextBox.Text;
                    product.DeliveryTime = deliveryTimeTextBox.Text;
                    HideButtons();
                    editProduct.Content = "Redigér";

                    savedPostTextBlock.Visibility = Visibility.Visible;
                    savedPostTextBlock.BeginAnimation(OpacityProperty,
                        new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 0, 1000), FillBehavior.HoldEnd));
                }
            }
        }

        public void HideButtons()
        {
            deleteProduct.Visibility = Visibility.Hidden;
            productNameTextBox.IsReadOnly = true;
            productNameTextBox.Cursor = Cursors.Arrow;
            chemicalNameTextBox.IsReadOnly = true;
            chemicalNameTextBox.Cursor = Cursors.Arrow;
            molValueTextBox.IsReadOnly = true;
            molValueTextBox.Cursor = Cursors.Arrow;
            priceTextBox.IsReadOnly = true;
            priceTextBox.Cursor = Cursors.Arrow;
            packetingTextBox.IsReadOnly = true;
            packetingTextBox.Cursor = Cursors.Arrow;
            deliveryTimeTextBox.IsReadOnly = true;
            deliveryTimeTextBox.Cursor = Cursors.Arrow;
            descriptionTextBox.IsReadOnly = true;
            descriptionTextBox.Cursor = Cursors.Arrow;
            editProduct.Visibility = Visibility.Hidden;
            descriptionTextBox.Background = Brushes.GhostWhite;
            if (Controller.instance.GetLoggedInUser().Username.Equals(product.Producer) ||
                Controller.instance.GetLoggedInUser().Rights == User.RightsEnum.Admin)
            {
                editProduct.Visibility = Visibility.Visible;
            }
            /*else if (Controller.instance.GetLoggedInUser().Rights == User.RightsEnum.Admin)
            {
                editProduct.Visibility = Visibility.Visible;
            }*/

        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmation = MessageBox.Show("Are you sure you want to delete this Product",
                "Confirm action?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (confirmation)
            {
                case MessageBoxResult.Yes:
                    Controller.instance.DeleteProduct(product);
                    supplierInformationPage.Reloadpage(true);
                    break;
            }
        }

    }
}
