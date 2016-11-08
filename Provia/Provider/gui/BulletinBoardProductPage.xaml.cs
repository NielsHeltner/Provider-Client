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
using System.Windows.Media.Animation;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for BulletinBoardProductPage.xaml
    /// </summary>
    public partial class BulletinBoardProductPage : Page
    {
        Post selectedItem;
        public BulletinBoardProductPage(Post selectedItem)
        {
            InitializeComponent();
            HideButtons();
            this.selectedItem = selectedItem;
            postTitel.Text = selectedItem.title;
            postDesciption.Text = selectedItem.description;
            postOwner.Text = selectedItem.owner;
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
            savedPostTextBlock.Visibility = Visibility.Hidden;
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

        private void SavePost(object sender, RoutedEventArgs e)
        {
            selectedItem.description = postDesciption.Text;
            selectedItem.title = postTitel.Text;
            HideButtons();
            savedPostTextBlock.Visibility = Visibility.Visible;
            savedPostTextBlock.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 0, 1000), FillBehavior.HoldEnd));
        }

        private void DeletePost(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmation = MessageBox.Show("Er du sikker på du vil slette dette opslag?", "Bekræft sletning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (confirmation)
            {
                case MessageBoxResult.Yes:
                    domain.Controller.instance.DeletePost(selectedItem);
                    break;
            }

        }
    }
}