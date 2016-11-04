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
using Provider.domain;

namespace Provider.gui
{

    public partial class SupplierList : Page
    {
        private Frame mainWindow;
        private List<Provider.domain.page.Page> suppliers;
        private ICollectionView dataView;
        private GridViewColumnHeader lastHeaderClicked = null;
        private ListSortDirection lastDirection = ListSortDirection.Descending;

        public SupplierList(Frame mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            suppliers = Controller.instance.GetPages();
            listView.ItemsSource = suppliers;
            dataView = CollectionViewSource.GetDefaultView(listView.ItemsSource);
        }

        private void ViewSupplierInformation(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Content = new SupplierInformation((Provider.domain.page.Page) listView.SelectedItem);
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
                    string header = (string)headerClicked.Content;
                    Sort(header, direction);
                    if(direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate = (DataTemplate)Resources["HeaderTemplateArrowDown"];
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate = (DataTemplate)Resources["HeaderTemplateArrowUp"];
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
            dataView.SortDescriptions.Clear();
            if(sortBy.Equals("Navn"))
            {
                sortBy = "name";
            }
            else if(sortBy.Equals("Note"))
            {
                sortBy = "noteText";
            }
            SortDescription sortDesc = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sortDesc);
            dataView.Refresh();
        }
    }
}
