using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Provider.domain;
using System.Windows.Media.Imaging;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BulletinBoardPage BulletinBoardPage;
        private Frontpage Frontpage;
        private SupplierFrontpage SupplierFrontpage;
        private LogIn LogIn;
        
        public MainWindow()
        {  
            InitializeComponent();
            LogIn = new LogIn(Frame, this, Frontpage);
            Frame.Content = LogIn;
            SetVisibilityToHidden();
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        public Frontpage LoginProvia()
        {
            BulletinBoardPage = new BulletinBoardPage();
            return Frontpage = new Frontpage(Frame, BulletinBoardPage);        
        }

        public SupplierFrontpage LoginSupplier()
        {
            BulletinBoardPage = new BulletinBoardPage();
            return SupplierFrontpage = new SupplierFrontpage(Frame, BulletinBoardPage);
        }

        private void GoToFrontpage(object sender, RoutedEventArgs e)
        {
            if(Controller.instance.GetLoggedInUser().Rights.Value == IO.Swagger.Model.User.RightsEnum.Supplier)
            {
                Frame.Content = SupplierFrontpage;
                SupplierFrontpage.RefreshFrontPage();
            }
            else
            {
                Frame.Content = Frontpage;
                Frontpage.RefreshFrontPage();
            }
        }

        private void GetSupplierPages(object sender, RoutedEventArgs e)
        {
            Frame.Content = new SupplierList(Frame, Controller.instance.GetPages());
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Controller.instance.LogOut();
            Frame.Content = LogIn;
            SetVisibilityToHidden();
            AnimateHeaderLogout();
        }

        private void SetVisibilityToHidden()
        {
            ShowSuppliersButton.Opacity = 0;
            ShowSupplierButton.Opacity = 0;
            SearchButton.Opacity = 0;
            HomeButton.Opacity = 0;
            LoggedIn.Opacity = 0;
            Logout.Opacity = 0;
            SearchText.Opacity = 0;
            SearchTermTextBox.Opacity = 0;
            SearchTermTextBox.IsEnabled = false;
            SearchButton.IsEnabled = false;
            ShowSuppliersButton.IsEnabled = false;
            ShowSupplierButton.IsEnabled = false;
            HomeButton.IsEnabled = false;
            LoggedIn.IsEnabled = false;
            Logout.IsEnabled = false;
        }
        public void AnimateHeaderLogin()
        {
            //AnimateAfterImageCompleted();

            // Animate image logo 
            DoubleAnimation ImageAnimate = new DoubleAnimation(150, 0, new TimeSpan(0, 0, 2));
            ElasticEase Ease = new ElasticEase
            {
                Springiness = 10,
                Oscillations = 0,
                EasingMode = EasingMode.EaseOut
            };
            ImageAnimate.EasingFunction = Ease;
            Image.BeginAnimation(Canvas.LeftProperty, ImageAnimate);

            // Animate Search bar
            DoubleAnimation SearchbarAnimate = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop);
            SearchbarAnimate.Completed += AnimateControlsCompleted;
            SearchTermTextBox.BeginAnimation(OpacityProperty, SearchbarAnimate);

            // Animate Search bar text
            SearchText.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));

            // Animate buttons
            HomeButton.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            SearchButton.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            Logout.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            LoggedIn.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));

            // Animate button according to logged in rights
            if(Controller.instance.GetLoggedInUser().Rights == IO.Swagger.Model.User.RightsEnum.Supplier)
            {
                ShowSupplierButton.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            }
            else 
            {
                ShowSuppliersButton.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            }
        }
        private void AnimateControlsCompleted(object sender, EventArgs e)
        {
            // Show controls after animation
            SearchText.Opacity = 1;
            SearchTermTextBox.Opacity = 1;
            HomeButton.Opacity = 1;
            SearchButton.Opacity = 1;
            Logout.Opacity = 1;
            LoggedIn.Opacity = 1;
            SearchTermTextBox.IsEnabled = true;
            HomeButton.IsEnabled = true;
            LoggedIn.IsEnabled = true;
            Logout.IsEnabled = true;
            SearchButton.IsEnabled = true;

            // Show correct control according to logged in rights
            if(Controller.instance.GetLoggedInUser().Rights == IO.Swagger.Model.User.RightsEnum.Supplier)
            {
                ShowSupplierButton.Opacity = 1;
                ShowSupplierButton.IsEnabled = true;
                ShowSupplierButton.Visibility = Visibility.Visible;
                ShowSuppliersButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShowSuppliersButton.Opacity = 1;
                ShowSuppliersButton.IsEnabled = true;
                ShowSuppliersButton.Visibility = Visibility.Visible;
                ShowSupplierButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AnimateHeaderLogout()
        {
            DoubleAnimation DoubleAnimation = new DoubleAnimation(0,150, new TimeSpan(0, 0, 2));
            ElasticEase ease = new ElasticEase
            {
                Springiness = 10,
                Oscillations = 0,
                EasingMode = EasingMode.EaseOut
            };
            DoubleAnimation.EasingFunction = ease;
            Image.BeginAnimation(Canvas.LeftProperty, DoubleAnimation);
        }

        private void _Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(SearchTermTextBox.Text) || Controller.instance.GetLoggedInUser().Rights == IO.Swagger.Model.User.RightsEnum.Supplier)
            {
                Frame.Content = Frontpage;
            }
            else
            {
                Frame.Content = new SupplierList(Frame, Controller.instance.Search(searchTerm));
            }
        }

        private void Search(object sender, KeyEventArgs e)
        {
            _Search(SearchTermTextBox.Text);
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            _Search(SearchTermTextBox.Text);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           if(Controller.instance.GetLoggedInUser() != null) 
            if (e.NewSize.Width < 1125)
                Image.Source = new BitmapImage(new Uri("../resources/P.png", UriKind.Relative));
            else 
                Image.Source = new BitmapImage(new Uri("../resources/provider2.png", UriKind.Relative));
        }

        private void GetSupplierPage(object sender, RoutedEventArgs e)
        {
            Frame.Content = new SupplierInformation(Controller.instance.GetPages().Find(SupplierPage => SupplierPage.Owner.Equals(Controller.instance.GetLoggedInUser().Username)));
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Controller.instance.DeleteTempFiles();
        }
    }
}
