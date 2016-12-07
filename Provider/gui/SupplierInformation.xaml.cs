using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using IO.Swagger.Model;
using Provider.domain;
using Provider.domain.page;
using Page = System.Windows.Controls.Page;

namespace Provider.gui
{
    public partial class SupplierInformation : Page
    {
        private GridViewColumnHeader lastHeaderClicked;
        private ListSortDirection lastDirection = ListSortDirection.Descending;
        private List<IO.Swagger.Model.Product> products;
        private IO.Swagger.Model.Page page;
        public SupplierInformation(IO.Swagger.Model.Page page)
        {
            InitializeComponent();
            //this.page = page;
            this.page = Controller.instance.GetPages().Find(p => p.Equals(page));
            products = new List<Product>();
            groupBox.Header = page.Owner;
            frame.Content = new SupplierGroupBox(page);
            products = page.Products;
            ProductsListView.ItemsSource = products;
            productFrame.Visibility = Visibility.Collapsed;
            Update();
        }

        private void Update()
        {
            new Thread(() =>
            {
                while (true)
                {
                    lock (Controller.instance.GetUpdateLock())
                    {
                        Monitor.Wait(Controller.instance.GetUpdateLock());
                        Reloadpage(true);
                    }
                }
            }).Start();
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

        public void Reloadpage(bool loadProductsToo)
        {
            Dispatcher.BeginInvoke((ThreadStart) delegate
            {
                if (loadProductsToo)
                {
                    ProductsListView.ItemsSource = null;
                    ProductsListView.ItemsSource = Controller.instance.GetPages().Find(p => p.Owner.Equals(page.Owner)).Products;
                }
                productFrame.Visibility = Visibility.Collapsed;
                button.Visibility = Visibility.Visible;
            });
        }

        private void CreateProduct(object sender, RoutedEventArgs e)
        {
            productFrame.Visibility = Visibility.Visible;
            productFrame.Content = new ViewProductGBPage(this);
            button.Visibility = Visibility.Hidden;
        }
    }
}