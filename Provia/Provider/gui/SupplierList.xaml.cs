using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Provider.gui
{

    public partial class SupplierList : Page
    {
        private Frame mainWindow;
        private List<TestSupplier> suppliers = new List<TestSupplier>();

        public SupplierList(Frame mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            
            suppliers.Add(new TestSupplier() { Name = "Niels", Credibility = "High", Note = "Meh" });
            suppliers.Add(new TestSupplier() { Name = "Antonio", Credibility = "Low", Note = "Pretty Meh" });
            suppliers.Add(new TestSupplier() { Name = "Niclas", Credibility = "Very High", Note = "Pretty Nice!" });

            listView.ItemsSource = suppliers;
        }

        private void ViewSupplierInformation(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Content = new SupplierInformation(suppliers.ElementAt(listView.SelectedIndex));
        }
    }
}
