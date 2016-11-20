using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Provider.domain;
using Provider.domain.bulletinboard;


namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for BulletinBoardPage.xaml
    /// </summary>
    public partial class BulletinBoardPage : Page
    {
        private bool isItMyList; // false = its all the post, true = its the loggedin users posts OR a specifik group post, 'all warning post' ect.
        public BulletinBoardPage()
        {
            InitializeComponent();
            listView.ItemsSource = Controller.instance.ViewAllPosts();
        }

        public void SetPostInformation(Post selectedItem)
            {
            frame.Content = new BulletinBoardProductPage(selectedItem, this);
            }

        private void ViewPostInformation(object sender, MouseButtonEventArgs e)
        {
            groupBox.Header = "Opslag information";
            frame.Content = new BulletinBoardProductPage((Post) listView.SelectedItem, this);
        }

        private void CreateNewPost(object sender, RoutedEventArgs e)
        {
            groupBox.Header = "Opret nyt opslag";
            frame.Content = new CreateNewPostPage(this);
        }
        /// <summary>
        /// Refresh BulletinBoardPage
        /// True = refresh product information
        /// False = refreshs only the ListView
        /// </summary>
        /// <param name="refreshFrameToo">bool</param>
        public void RefreshPage(bool refreshFrameToo)
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewAllPosts();
            groupBox.Header = "Opslag information";
            typeOfList.Text = "Alle opslag";
            if (refreshFrameToo)
                frame.Content = null;
        }
        //TODO foreach uden for if?
        private void ListMyPosts(object sender, RoutedEventArgs e)
        {
            List<Post> myPosts = new List<Post>();
            foreach (Post post in Controller.instance.ViewAllPosts())
            {
                if (post.owner.Equals(Controller.instance.GetLoggedInUser().Username))
                {
                    myPosts.Add(post);
                }
            }
            listView.ItemsSource = null;
            if (!isItMyList)
            {
                listView.ItemsSource = myPosts;
                myPostButton.Content = "Alle opslag";
                isItMyList = true;
                typeOfList.Text = "Mine opslag";
            }
            else
            {
                listView.ItemsSource = Controller.instance.ViewAllPosts();
                myPostButton.Content = "Mine opslag";
                isItMyList = false;
                typeOfList.Text = "Alle opslag";
            }

        }
        public void SetListToWarning()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewWarningPosts();
            isItMyList = true;
            myPostButton.Content = "Alle opslag";
            typeOfList.Text = "Alle advarelser";
        }
        public void SetListToRequest()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewRequestPosts();
            isItMyList = true;
            myPostButton.Content = "Alle opslag";
            typeOfList.Text = "Alle efterspørgelser";
        }
        public void SetListToOffer()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewOfferPosts();
            isItMyList = true;
            myPostButton.Content = "Alle opslag";
            typeOfList.Text = "Alle tilbud";
        }
    }
}
