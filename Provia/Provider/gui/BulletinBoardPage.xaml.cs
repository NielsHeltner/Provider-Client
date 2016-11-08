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

        private List<domain.bulletinboard.Post> posts;
        public BulletinBoardPage()
        {
            InitializeComponent();
            posts = new List<domain.bulletinboard.Post>();
            posts = Controller.instance.ViewBulletinBoard(0);
            listView.ItemsSource = posts;

        }
        private void ViewPostInformation(object sender, MouseButtonEventArgs e)
        {
            groupBox.Header = "Opslag Information";
            frame.Content = new BulletinBoardProductPage((domain.bulletinboard.Post) listView.SelectedItem);
        }

        private void CreateNewPost(object sender, RoutedEventArgs e)
        {
            groupBox.Header = "Opret nyt opslag";
            frame.Content = new CreateNewPostPage(this);
        }

        public void RefreshPage()
        {
            posts = Controller.instance.ViewBulletinBoard(0);
            listView.ItemsSource = posts;
            frame.Content = null;
        }
    }
}
