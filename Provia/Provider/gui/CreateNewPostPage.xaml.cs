using Provider.domain;
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
    /// Interaction logic for CreateNewPost.xaml
    /// </summary>
    public partial class CreateNewPostPage : Page
    {
        private BulletinBoardPage bulletinBoardPage;
        public CreateNewPostPage(BulletinBoardPage Bulletinboard)
        {
            InitializeComponent();
            this.bulletinBoardPage = Bulletinboard;
            CreationDateTextBlock.Text = DateTime.Today.ToShortDateString();
            OwnerTextBlock.Text = Controller.instance.GetLoggedInUserName();
        }
        /// 0 is error
        /// "1" is warningPost
        /// "2" is requestPost
        /// "3" is offerPost
        /// skal måske laves om... det snakker vi lige om
        private void CreateNewPost(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(PostDescriptionTextBox.Text) && !string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                CreatePost();
            }
            else
            {
                SomthingWentWrongLabel.Visibility = Visibility.Visible;
            }
               
        }
        private void CreatePost()
        {

            domain.bulletinboard.Post.Types typeOfPost;

            if (WarningRB.IsChecked.Value)
            {
                typeOfPost = domain.bulletinboard.Post.Types.Warning;
            }
            else if (requestRB.IsChecked.Value)
            {
                typeOfPost = domain.bulletinboard.Post.Types.Request;
            }
            else if (OfferRB.IsChecked.Value)
            {
                typeOfPost = domain.bulletinboard.Post.Types.Offer;
            } else
            {
                typeOfPost = domain.bulletinboard.Post.Types.NotAvailabe;
            }
                Controller.instance.CreatePost(Controller.instance.GetLoggedInUserName(), TitleTextBox.Text, PostDescriptionTextBox.Text, typeOfPost);
                bulletinBoardPage.RefreshPage();
        }
        
        
    }
}
