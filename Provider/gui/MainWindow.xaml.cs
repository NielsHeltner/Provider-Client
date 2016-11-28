using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Provider.domain;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BulletinBoardPage bulletinBoardPage;
        private Frontpage frontpage;
        private LogIn logIn;
        
        public MainWindow()
        {  
            InitializeComponent();
            Refresh();
            frame.Content = logIn;
            SetVisibilityToHidden();
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        public void Refresh()
        {
            bulletinBoardPage = new BulletinBoardPage();
            frontpage = new Frontpage(frame, bulletinBoardPage);
            logIn = new LogIn(frame, this, frontpage);
        }

        private void GoToFrontpage(object sender, RoutedEventArgs e)
        {
            frame.Content = frontpage;
            frontpage.RefreshFrontPage();
        }

        private void GetSupplierPages(object sender, RoutedEventArgs e)
        {
            frame.Content = new SupplierList(frame, Controller.instance.GetPages());
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Controller.instance.LogOut();
            frame.Content = logIn;
            SetVisibilityToHidden();
            AnimateHeaderLogout();
        }

        private void SetVisibilityToHidden()
        {
            showSuppliersButton.Opacity = 0;
            searchButton.Opacity = 0;
            homeButton.Opacity = 0;
            loggedIn.Opacity = 0;
            logout.Opacity = 0;
            searchText.Opacity = 0;
            searchTermTextBox.Opacity = 0;
            searchTermTextBox.IsEnabled = false;
            searchButton.IsEnabled = false;
            showSuppliersButton.IsEnabled = false;
            homeButton.IsEnabled = false;
            loggedIn.IsEnabled = false;
            logout.IsEnabled = false;
            searchTermTextBox.IsEnabled = false;
        }
        public void AnimateHeaderLogin()
        {
            //AnimateAfterImageCompleted();

            // Animate image logo 
            DoubleAnimation imageAnimate = new DoubleAnimation(150, 0, new TimeSpan(0, 0, 2));
            ElasticEase ease = new ElasticEase
            {
                Springiness = 10,
                Oscillations = 0,
                EasingMode = EasingMode.EaseOut
            };
            imageAnimate.EasingFunction = ease;
            image.BeginAnimation(Canvas.LeftProperty, imageAnimate);

            // Animate Search bar
            DoubleAnimation searchbarAnimate = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop);
            searchbarAnimate.Completed += AnimateControlsCompleted;
            searchTermTextBox.BeginAnimation(OpacityProperty, searchbarAnimate);

            // Animate Search bar text
            searchText.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));

            // Animate buttons
            homeButton.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            showSuppliersButton.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            searchButton.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            logout.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            loggedIn.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
        }
        private void AnimateControlsCompleted(object sender, EventArgs e)
        {
            searchText.Opacity = 1;
            searchTermTextBox.Opacity = 1;
            homeButton.Opacity = 1;
            showSuppliersButton.Opacity = 1;
            searchButton.Opacity = 1;
            logout.Opacity = 1;
            loggedIn.Opacity = 1;
            searchTermTextBox.IsEnabled = true;
            showSuppliersButton.IsEnabled = true;
            homeButton.IsEnabled = true;
            loggedIn.IsEnabled = true;
            logout.IsEnabled = true;
            searchTermTextBox.IsEnabled = true;
            searchButton.IsEnabled = true;
        }

        private void AnimateHeaderLogout()
        {
            DoubleAnimation da = new DoubleAnimation(0,150, new TimeSpan(0, 0, 2));
            ElasticEase ease = new ElasticEase
            {
                Springiness = 10,
                Oscillations = 0,
                EasingMode = EasingMode.EaseOut
            };
            da.EasingFunction = ease;
            image.BeginAnimation(Canvas.LeftProperty, da);
        }

        private void _Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTermTextBox.Text))
            {
                frame.Content = frontpage;
            }
            else
            {
                frame.Content = new SupplierList(frame, Controller.instance.Search(searchTerm));
            }
        }

        private void Search(object sender, KeyEventArgs e)
        {
            _Search(searchTermTextBox.Text);
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            _Search(searchTermTextBox.Text);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           if(Controller.instance.GetLoggedInUser() != null) 
            if (e.NewSize.Width < 1125)
                image.Source = new BitmapImage(new Uri("../resources/P.png", UriKind.Relative));
            else 
                image.Source = new BitmapImage(new Uri("../resources/provider2.png", UriKind.Relative));
        }
    }
}
