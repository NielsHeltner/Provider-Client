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
    public partial class Frontpage : Page
    {
        private Frame frame;
        private BulletinBoardPage bulletinBoard;
        public Frontpage(Frame frame, BulletinBoardPage bulletinBoard)
        {
            InitializeComponent();
            this.frame = frame;
            this.bulletinBoard = bulletinBoard;
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
