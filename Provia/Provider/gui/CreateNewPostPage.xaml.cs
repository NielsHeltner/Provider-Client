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
        public CreateNewPostPage()
        {
            InitializeComponent();
        }
        /// "1" is warningPost
        /// "2" is requestPost
        /// "3" is offerPost
        /// skal måske laves om... det snakker vi lige om
        private void CreateNewPost(object sender, RoutedEventArgs e)
        {

                int typeOfPost;
                if (WarningRB.IsChecked == true)
                {
                    typeOfPost = 1;
                } else if(requestRB.IsChecked == true)
                {
                    typeOfPost = 2;
                } else if(OfferRB.IsChecked == true)
                {
                    typeOfPost = 3;
                }
                Controller.instance.CreatePost(Controller.instance.GetLoggedInUserName(), TitleTextBox.Text, PostDescriptionTextBox.Text, typeOfPost);

        }
    }
}
