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
using Provider.domain.bulletinboard;


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
            listView.ItemsSource = Controller.instance.ViewAllPosts();
        }

        private void ViewPostInformation(object sender, MouseButtonEventArgs e)
        {
            groupBox.Header = "Opslag Information";
            frame.Content = new BulletinBoardProductPage((Post) listView.SelectedItem, this);
        }

        private void CreateNewPost(object sender, RoutedEventArgs e)
        {
            groupBox.Header = "Opret nyt opslag";
            frame.Content = new CreateNewPostPage(this);
        }

        public void RefreshPage()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewAllPosts();
            frame.Content = null;
            groupBox.Header = "Opslag Information";
        }

        public void RefreshList()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewAllPosts();
            groupBox.Header = "Opslag Information";
        }

        private void ListMyPosts(object sender, RoutedEventArgs e)
        {
            List<Post> myPosts = new List<Post>();
            foreach(Post post in Controller.instance.ViewAllPosts())
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
            }
            else
            {
                listView.ItemsSource = null;
                listView.ItemsSource = Controller.instance.ViewAllPosts();
                myPostButton.Content = "Mine opslag";
                whatsOnTheList = 0;
            }

        }
    }
}
