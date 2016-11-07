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
using Provider.domain.bulletinboard;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for BulletinBoardProductPage.xaml
    /// </summary>
    public partial class BulletinBoardProductPage : Page
    {

        public BulletinBoardProductPage(Post selectedItem)
        {
            InitializeComponent();
            HideButtons();
            postTitel.Text = selectedItem.title;
            postDesciption.Text = selectedItem.description;
            postOwner.Text = selectedItem.owner.userName;
            postDateLabel.Text = selectedItem.creationDate.ToShortDateString();
            typeOfPost.Text = TypeOfPost(selectedItem.type);
        }
        
        /// "1" is warningPost
        /// "2" is requestPost
        /// "3" is offerPost
        /// burde måske blive flyttet til domain Snak lige om det.
        private string TypeOfPost(int type)
        {
            switch (type)
            {
                case 1:
                    return "Advarelse";
                case 2:
                    return "For spørgelse";
                case 3:
                    return "Tilbud";
                default:
                    return "N/A(error)";
            }
        }
        public void HideButtons()
        {
            deletePostButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Hidden;
            postDesciption.IsReadOnly = true;
            postTitel.IsReadOnly = true;
        }

        private void EditPost(object sender, RoutedEventArgs e)
        {
            deletePostButton.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Visible;
            postDesciption.IsReadOnly = false;
            postDesciption.AcceptsReturn = true;
            postDesciption.IsUndoEnabled = true;
            postTitel.IsReadOnly = false;
            postTitel.Focus();
        }
    }
}