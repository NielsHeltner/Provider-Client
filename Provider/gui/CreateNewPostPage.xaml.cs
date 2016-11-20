using System;
using System.Windows;
using System.Windows.Controls;
using Provider.domain;
using Provider.domain.bulletinboard;

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
            Post.Types typeOfPost;
            if (WarningRB.IsChecked.Value)
            {
                typeOfPost = Post.Types.Warning;
            }
            else if (requestRB.IsChecked.Value)
            {
                typeOfPost = Post.Types.Request;
            }
            else if (OfferRB.IsChecked.Value)
            {
                typeOfPost = Post.Types.Offer;
            }
            else
            {
                typeOfPost = Post.Types.NotAvailabe;
            }
                Controller.instance.CreatePost(Controller.instance.GetLoggedInUser().Username, postTitleTextBox.Text, PostDescriptionTextBox.Text, typeOfPost);
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
