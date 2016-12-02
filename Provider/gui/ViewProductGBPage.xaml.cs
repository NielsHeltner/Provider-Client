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
            frame.Content = new ViewProductPage(product, supplierInformationPage);
        }
    }
}
