using System.Threading;
using IO.Swagger.Model;
using Provider.domain;
using Provider.domain.bulletinboard;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for Frontpage.xaml
    /// </summary>
    /// TODO instantiere de 2 andre lister(tilbud og request), hvis de skal det.
    public partial class SupplierFrontpage : System.Windows.Controls.Page
    {
        private Frame frame;
        private BulletinBoardPage bulletinBoard;
        public SupplierFrontpage(Frame frame, BulletinBoardPage bulletinBoard)
        {
            InitializeComponent();
            this.frame = frame;
            this.bulletinBoard = bulletinBoard;
            WarningListView.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            WarningListView.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            RefreshFrontPage();
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
                        RefreshFrontPage();
                    }
                }
            }).Start();
        }

        private void GoToBulletinBoardPageNews(object sender, MouseButtonEventArgs e)
        {
            frame.Content = bulletinBoard;
            bulletinBoard.SetListToRequest();
        }

        private void GoToBulletinBoardPageWarning(object sender, MouseButtonEventArgs e)
        {
            frame.Content = bulletinBoard;
            bulletinBoard.SetListToWarning();
        }

        private void GoToBulletinBoardPageOffer(object sender, MouseButtonEventArgs e)
        {
            frame.Content = bulletinBoard;
            bulletinBoard.SetListToOffer();
        }

        private void ViewAllPost(object sender, RoutedEventArgs e)
        {
            frame.Content = bulletinBoard;
            bulletinBoard.RefreshPage(true);
        }
        public void RefreshFrontPage()
        {
            Dispatcher.Invoke((ThreadStart) delegate
            {
                WarningListView.ItemsSource = null;
                WarningListView.ItemsSource = domain.Controller.instance.ViewWarningPosts();
                numberOfWarningPostLabel.Content = domain.Controller.instance.ViewWarningPosts().Count;

                OfferListView.ItemsSource = null;
                OfferListView.ItemsSource =
                    domain.Controller.instance.ViewOfferPosts(Controller.instance.GetLoggedInUser().Username);
                NumberOfOfferPosts.Content =
                    domain.Controller.instance.ViewOfferPosts(Controller.instance.GetLoggedInUser().Username).Count;

                RequestListView.ItemsSource = null;
                RequestListView.ItemsSource = domain.Controller.instance.ViewRequestPosts();
                NumberOfRequestPosts.Content = domain.Controller.instance.ViewRequestPosts().Count;
            });
        }

        private void ViewWarningPost(object sender, MouseButtonEventArgs e)
        {
            bulletinBoard.SetPostInformation((Post) WarningListView.SelectedItem);
            bulletinBoard.SetListToWarning();
            frame.Content = bulletinBoard;
        }

        private void ViewOfferPost(object sender, MouseButtonEventArgs e)
        {
            bulletinBoard.SetPostInformation((Post) OfferListView.SelectedItem);
            bulletinBoard.SetListToOffer();
            frame.Content = bulletinBoard;
        }

        private void ViewRequestPost(object sender, MouseButtonEventArgs e)
        {
            bulletinBoard.SetPostInformation((Post) RequestListView.SelectedItem);
            bulletinBoard.SetListToRequest();
            frame.Content = bulletinBoard;
        }
    }
}
