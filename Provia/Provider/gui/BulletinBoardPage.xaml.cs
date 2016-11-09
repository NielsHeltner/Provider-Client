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
        private int whatsOnTheList = 0; // 0 = det er alle post, 1 = mine post
        public BulletinBoardPage()
        {
            InitializeComponent();
            listView.ItemsSource = Controller.instance.ViewBulletinBoard(0);
        }

        private void ViewPostInformation(object sender, MouseButtonEventArgs e)
        {
            groupBox.Header = "Opslag Information";
            frame.Content = new BulletinBoardProductPage((domain.bulletinboard.Post) listView.SelectedItem, this);
        }

        private void CreateNewPost(object sender, RoutedEventArgs e)
        {
            groupBox.Header = "Opret nyt opslag";
            frame.Content = new CreateNewPostPage(this);
        }

        public void RefreshPage()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewBulletinBoard(0);
            frame.Content = null;
            groupBox.Header = "Opslag Information";
        }

        public void RefreshList()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewBulletinBoard(0);
            groupBox.Header = "Opslag Information";
        }

        private void ListMyPosts(object sender, RoutedEventArgs e)
        {

            List<Provider.domain.bulletinboard.Post> posts = new List<domain.bulletinboard.Post>();
            List<Provider.domain.bulletinboard.Post> myPosts = new List<domain.bulletinboard.Post>();
            posts = Controller.instance.ViewBulletinBoard(0);
            foreach(domain.bulletinboard.Post post in posts)
            {
                if (post.owner.Equals(Controller.instance.GetLoggedInUserName()))
                {
                    myPosts.Add(post);
                }
            }
            if (whatsOnTheList == 0)
            {
                listView.ItemsSource = null;
                listView.ItemsSource = myPosts;
                myPostButton.Content = "Alle Opslag";
                whatsOnTheList = 1;
            } else if (whatsOnTheList == 1)
            {
                listView.ItemsSource = null;
                listView.ItemsSource = posts;
                myPostButton.Content = "Mine opslag";
                whatsOnTheList = 0;
            }

        }
    }
}
