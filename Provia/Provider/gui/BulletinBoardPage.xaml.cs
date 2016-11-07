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
using Provider.domain;


namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for BulletinBoardPage.xaml
    /// </summary>
    public partial class BulletinBoardPage : Page
    {

        private List<Provider.domain.bulletinboard.Post> posts;
        public BulletinBoardPage()
        {
            InitializeComponent();
            posts = new List<domain.bulletinboard.Post>();
            frame.Content = new BulletinBoardProductPage();
            posts = Controller.instance.ViewBulletinBoard(0);
            listView.ItemsSource = posts;

        }
        private void ViewPostInformation(object sender, MouseButtonEventArgs e)
        {
            frame.Content = new BulletinBoardProductPage((Provider.domain.bulletinboard.Post) listView.SelectedItem);
        }
    }
}
