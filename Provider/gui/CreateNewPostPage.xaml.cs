using System;
using System.Windows;
using IO.Swagger.Model;
using Provider.domain;
using Provider.domain.bulletinboard;
using Page = System.Windows.Controls.Page;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for CreateNewPost.xaml
    /// </summary>
    public partial class CreateNewPostPage : Page
    {
        private BulletinBoardPage bulletinBoardPage;
        public CreateNewPostPage(BulletinBoardPage bulletinboard)
        {
            InitializeComponent();
            bulletinBoardPage = bulletinboard;
            CreationDateTextBlock.Text = DateTime.Today.ToShortDateString();
            OwnerTextBlock.Text = Controller.instance.GetLoggedInUser().Username;
        }

        private void CreateNewPost(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PostDescriptionTextBox.Text) && !string.IsNullOrWhiteSpace(postTitleTextBox.Text))
            {
                if (WarningRB.IsChecked == false && OfferRB.IsChecked == false && requestRB.IsChecked == false)
                {
                    SomthingWentWrongLabel.Content = "Husk at vælge katagori";
                    SomthingWentWrongLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    CreatePost();
                } 

            }
            else
            {
                SomthingWentWrongLabel.Content = "Der skal være en titel og en beskrivelse i dit opslag";
                SomthingWentWrongLabel.Visibility = Visibility.Visible;
            }
        }

        private void CreatePost()
        {
            PostType typeOfPost;
            if (WarningRB.IsChecked.Value)
            {
                typeOfPost = PostType.Warning;
            }
            else if (requestRB.IsChecked.Value)
            {
                typeOfPost = PostType.Request;
            }
            else if (OfferRB.IsChecked.Value)
            {
                typeOfPost = PostType.Offer;
            }
            else
            {
                typeOfPost = PostType.NotAvailable;
            }
                Controller.instance.CreatePost(Controller.instance.GetLoggedInUser().Username, DateTime.Now.Date, postTitleTextBox.Text, PostDescriptionTextBox.Text, typeOfPost);
                bulletinBoardPage.RefreshPage(true);
        }

        private void TitleLostFocus(object sender, RoutedEventArgs e)
        {
            if (postTitleTextBox.Text.Length == 0)
            {
                titleText.Visibility = Visibility.Visible;
            }
        }

        private void TitleGotFocus(object sender, RoutedEventArgs e)
        {
            titleText.Visibility = Visibility.Hidden;
        }

        private void PostDescriptionLostFocus(object sender, RoutedEventArgs e)
        {
            if (PostDescriptionTextBox.Text.Length == 0)
            {
                desriptionText.Visibility = Visibility.Visible;
            }
        }

        private void PostDescriptionGotFocus(object sender, RoutedEventArgs e)
        {
            desriptionText.Visibility = Visibility.Hidden;
        }
    }
}
