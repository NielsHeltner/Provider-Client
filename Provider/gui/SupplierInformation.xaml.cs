using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using IO.Swagger.Model;
using Provider.domain.page;
using Page = System.Windows.Controls.Page;

namespace Provider.gui
{
    public partial class SupplierInformation : Page
    {
        private GridViewColumnHeader lastHeaderClicked;
        private ListSortDirection lastDirection = ListSortDirection.Descending;
        private List<Product> products;

        public SupplierInformation(IO.Swagger.Model.Page page)
        {
            InitializeComponent();
            products = new List<Product>();
            groupBox.Header = page.Owner;
            frame.Content = new SupplierGroupBox(page);
            products = page.Products;
            ProductsListView.ItemsSource = products;
            productFrame.Visibility = Visibility.Collapsed;
        }

        private void SortProductInformation(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = (GridViewColumnHeader)e.OriginalSource;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }
                    string header = (string)headerClicked.Content;
                    Sort(header, direction);
                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate = (DataTemplate)Resources["HeaderTemplateArrowDown"];
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate = (DataTemplate)Resources["HeaderTemplateArrowUp"];
                    }
                    if (lastHeaderClicked != null && lastHeaderClicked != headerClicked)
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
            ICollectionView dataView = CollectionViewSource.GetDefaultView(ProductsListView.ItemsSource);
            dataView.SortDescriptions.Clear();
            if (sortBy.Equals("Produkt"))
            {
                sortBy = "productName";
            }
            else if (sortBy.Equals("Leveringstid"))
            {
                sortBy = "deliveryTime";
            }
            else if (sortBy.Equals("Emballage"))
            {
                sortBy = "packaging";
            }
            SortDescription sortDesc = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sortDesc);
            dataView.Refresh();
        }

        private void GoToProduct(object sender, MouseButtonEventArgs e)
        {
            productFrame.Visibility = Visibility.Visible;
            productFrame.Content = new ViewProductGBPage((Product)ProductsListView.SelectedItem, this);
        }

        public void Reloadpage()
        {
            productFrame.Visibility = Visibility.Collapsed;
        }

        public void RefreshPage(bool refreshFrameToo)
        {
            /*listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewAllPosts();
            groupBox.Header = "Opslag information";
            typeOfList.Text = "Alle opslag";
            if (refreshFrameToo)
                frame.Content = null;
                */
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            productFrame.Content = new ViewProductGBPage(this);
        }
    }
}