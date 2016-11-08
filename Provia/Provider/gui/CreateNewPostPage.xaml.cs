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

            int typeOfPost;
            if (WarningRB.IsChecked.Value)
            {
                typeOfPost = 1;
            }
            else if (requestRB.IsChecked.Value)
            {
                typeOfPost = 2;
            }
            else if (OfferRB.IsChecked.Value)
            {
                typeOfPost = 3;
            } else
            {
                typeOfPost = 0;
            }
            Controller.instance.CreatePost(Controller.instance.GetLoggedInUserName(), TitleTextBox.Text, PostDescriptionTextBox.Text, typeOfPost);
            bulletinBoardPage.RefreshPage();
            SomthingWentWrongLabel.Visibility = Visibility.Hidden;
        }
        
        
    }
}
