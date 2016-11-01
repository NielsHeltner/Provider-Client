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
using System.ComponentModel;

namespace Provider.gui
{

    public partial class SupplierList : Page
    {
        private Frame mainWindow;
        private List<TestSupplier> suppliers = new List<TestSupplier>();
        private GridViewColumnHeader lastHeaderClicked = null;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;

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

        private void SortSupplierInformation(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = (GridViewColumnHeader)e.OriginalSource;
            ListSortDirection direction;

            if(headerClicked != null)
            {
                if(headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if(headerClicked != lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if(lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else {
                            direction = ListSortDirection.Ascending;
                        }
                    }
                    string header = (string)headerClicked.Column.Header;
                    Sort(header, direction);
                    if(direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate = (DataTemplate)Resources["HeaderTemplateArrowUp"];
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate = (DataTemplate)Resources["HeaderTemplateArrowDown"];
                    }
                    if(lastHeaderClicked != null && lastHeaderClicked != headerClicked)
                    {
                        lastHeaderClicked.Column.HeaderTemplate = null;
                    }
                    lastHeaderClicked = headerClicked;
                    lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(listView.ItemsSource);
            dataView.SortDescriptions.Clear();
            if(sortBy.Equals("Navn"))
            {
                sortBy = "Name";
            }
            else if(sortBy.Equals("Troværdighed"))
            {
                sortBy = "Credibility";
            }
            else if(sortBy.Equals("Note"))
            {
                sortBy = "Note";
            }
            SortDescription sortDesc = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sortDesc);
            dataView.Refresh();
        }
    }
}
