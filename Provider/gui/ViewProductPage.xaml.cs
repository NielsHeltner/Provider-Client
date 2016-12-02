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

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for ViewProductPage.xaml
    /// </summary>
    public partial class ViewProductPage : Page
    {
        private SupplierInformation supplierInformationPage;
        public ViewProductPage(Product p, SupplierInformation supplierInformationPage)
        {
            InitializeComponent();
            productNameTextBox.Text = p.ProductName;
            chemicalNameTextBox.Text = p.ChemicalName;
            MolValueTextBox.Text = p.MolWeight;
            PriceTextBox.Text = p.Price;
            PacketingTextBox.Text = p.Packaging;
            discriptionTextBox.Text = p.Description;
            this.supplierInformationPage = supplierInformationPage;
        }

        private void BackToListView(object sender, RoutedEventArgs e)
        {
            supplierInformationPage.Reloadpage();
        }

        private void OpenPDFBotton(object sender, RoutedEventArgs e)
        {
            //TODO finde ud af hvordan vi hånter pdf...
            try
            {
                System.Diagnostics.Process.Start(@"c:\egen fil\test1.pdf");
            }
            catch (Exception exception)
            {
                   
            }
        }
    }
}
