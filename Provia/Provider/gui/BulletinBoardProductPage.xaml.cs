﻿using System;
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

        public BulletinBoardProductPage()
        {
            InitializeComponent();
        }

        public BulletinBoardProductPage(Post selectedItem)
        {
            InitializeComponent();
            deletePostButton.Visibility = Visibility.Collapsed;
            saveButton.Opacity = 0;
            postTitel.Text = selectedItem.title;
            postDesciption.Text = selectedItem.description;
            postOwner.Text = selectedItem.owner.userName;
            postDateLabel.Text = selectedItem.creationDate.ToShortDateString();
        }

        private void Click_editPostButton(object sender, RoutedEventArgs e)
        {
            deletePostButton.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Visible;
        }
    }
}
