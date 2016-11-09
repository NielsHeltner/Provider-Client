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
            WarningListView.ItemsSource = domain.Controller.instance.ViewWarningPosts();
            numberOfWarningPostLabel.Content = domain.Controller.instance.ViewWarningPosts().Count;
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

        private void viewAllPost(object sender, RoutedEventArgs e)
        {
            frame.Content = bulletinBoard;
        }

    }
}
