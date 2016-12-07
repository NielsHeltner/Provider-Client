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
    /// Interaction logic for ViewProductGBPage.xaml
    /// </summary>
    public partial class ViewProductGBPage : Page
    {
        public ViewProductGBPage(Product product, SupplierInformation supplierInformationPage)
        {
            InitializeComponent();
            groupBox.Header = "Produkt Information";
            frame.Content = new ViewProductPage(product, supplierInformationPage);
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        public ViewProductGBPage(SupplierInformation supplierPage)
        {
            InitializeComponent();
            groupBox.Header = "Opret nyt produkt";
            frame.Content = new CreateNewProductPage(supplierPage);
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
