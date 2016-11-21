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
    public partial class Frontpage : Page
    {
        private Frame frame;
        private BulletinBoardPage bulletinBoard;
        public Frontpage(Frame frame, BulletinBoardPage bulletinBoard)
        {
            InitializeComponent();
            this.frame = frame;
            this.bulletinBoard = bulletinBoard;
            WarningListView.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            WarningListView.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            RefreshFrontPage();
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
            WarningListView.ItemsSource = null;
            WarningListView.ItemsSource = domain.Controller.instance.ViewWarningPosts();
            numberOfWarningPostLabel.Content = domain.Controller.instance.ViewWarningPosts().Count;
        }

        private void ViewWarningPost(object sender, MouseButtonEventArgs e)
        {
            bulletinBoard.SetPostInformation((IO.Swagger.Model.Post)WarningListView.SelectedItem);
            bulletinBoard.SetListToWarning();
            frame.Content = bulletinBoard;
        }
    }
}
