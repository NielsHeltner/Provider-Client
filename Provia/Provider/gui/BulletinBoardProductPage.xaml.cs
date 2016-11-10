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
using Provider.domain;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for BulletinBoardProductPage.xaml
    /// </summary>
    public partial class BulletinBoardProductPage : Page
    {
        Post selectedItem;
        BulletinBoardPage bulletinBoard;
        public BulletinBoardProductPage(Post selectedItem, BulletinBoardPage bulletinBoard)
        {
            InitializeComponent();
            HideButtons();
            this.selectedItem = selectedItem;
            postTitel.Text = selectedItem.title;
            postDesciption.Text = selectedItem.description;
            postOwner.Text = selectedItem.owner;
            postDateLabel.Text = selectedItem.creationDate.ToShortDateString();
            typeOfPost.Text = selectedItem.type.ToString();
            this.bulletinBoard = bulletinBoard;
        }

        public void HideButtons()
        {
            deletePostButton.Visibility = Visibility.Hidden;
            postDesciption.IsReadOnly = true;
            postTitel.IsReadOnly = true;
            postDesciption.Cursor = Cursors.Arrow;
            postTitel.Cursor = Cursors.Arrow;
            postDesciption.Background = Brushes.GhostWhite;

        }

        private void EditPost(object sender, RoutedEventArgs e)
        {
            if (postDesciption.IsReadOnly)
            {
                deletePostButton.Visibility = Visibility.Visible;
                postDesciption.Background = null;
                postDesciption.IsReadOnly = false;
                postDesciption.AcceptsReturn = true;
                postDesciption.IsUndoEnabled = true;
                postDesciption.ToolTip = "Uddyb dit opslag her";
                postTitel.ToolTip = "Skriv titlen på det opsalg her";
                postTitel.IsReadOnly = false;
                postTitel.Focus();
                postTitel.Cursor = Cursors.IBeam;
                postDesciption.Cursor = Cursors.IBeam;
                editPostButton.Content = "Gem";
            }
            else
            {
                Controller.instance.EditPost(selectedItem, postDesciption.Text, postTitel.Text);
                HideButtons();
                editPostButton.Content = "Redigere";
                bulletinBoard.RefreshPage(false);
                savedPostTextBlock.Visibility = Visibility.Visible;
                savedPostTextBlock.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 0, 1000), FillBehavior.HoldEnd));

            }
        }

        private void SavePost(object sender, RoutedEventArgs e)
        {
            selectedItem.description = postDesciption.Text;
            selectedItem.title = postTitel.Text;
            HideButtons();
            bulletinBoard.RefreshPage(true);
        }

        private void DeletePost(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmation = MessageBox.Show("Er du sikker på du vil slette dette opslag?", "Bekræft sletning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (confirmation)
            {
                case MessageBoxResult.Yes:
                    domain.Controller.instance.DeletePost(selectedItem);
                    bulletinBoard.RefreshPage(true);
                    break;
            }

        }
    }
}