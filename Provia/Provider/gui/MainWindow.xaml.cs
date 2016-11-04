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
using Provider.gui;
using Provider.domain;
using System.Windows.Media.Animation;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Frontpage frontpage = new Frontpage();
        private LogIn logIn;
        
        public MainWindow()
        {  
            InitializeComponent();
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            SetVisibilityToHidden();
            logIn = new LogIn(frame, this, frontpage);
            frame.Content = logIn;
        }

        private void GoToFrontpage(object sender, RoutedEventArgs e)
        {
            frame.Content = frontpage;
        }

        private void GetSupplierPages(object sender, RoutedEventArgs e)
        {
            frame.Content = new SupplierList(frame);
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
            SearchTermTextBox.Opacity = 0;
            SearchTermTextBox.IsEnabled = false;
            showSuppliersButton.IsEnabled = false;
            homeButton.IsEnabled = false;
            loggedIn.IsEnabled = false;
            logout.IsEnabled = false;
            SearchTermTextBox.IsEnabled = false;
        }
        public void AnimateHeaderLogin()
        {
            //AnimateAfterImageCompleted();

            // Animate image logo 
            DoubleAnimation imageAnimate = new DoubleAnimation(122, 0, new TimeSpan(0, 0, 2));
            ElasticEase ease = new ElasticEase();
            ease.Springiness = 10;
            ease.Oscillations = 0;
            ease.EasingMode = EasingMode.EaseOut;
            imageAnimate.EasingFunction = ease;
            image.BeginAnimation(Canvas.LeftProperty, imageAnimate);

            // Animate Search bar
            DoubleAnimation searchbarAnimate = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop);
            searchbarAnimate.Completed += AnimateControlsCompleted;
            SearchTermTextBox.BeginAnimation(Control.OpacityProperty, searchbarAnimate);

            // Animate Search bar text
            searchText.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));

            // Animate buttons
            homeButton.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            showSuppliersButton.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            searchButton.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            logout.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
            loggedIn.BeginAnimation(Control.OpacityProperty, new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500), FillBehavior.Stop));
        }
        private void AnimateControlsCompleted(object sender, EventArgs e)
        {
            searchText.Opacity = 1;
            SearchTermTextBox.Opacity = 1;
            homeButton.Opacity = 1;
            showSuppliersButton.Opacity = 1;
            searchButton.Opacity = 1;
            logout.Opacity = 1;
            loggedIn.Opacity = 1;
            SearchTermTextBox.IsEnabled = true;
            showSuppliersButton.IsEnabled = true;
            homeButton.IsEnabled = true;
            loggedIn.IsEnabled = true;
            logout.IsEnabled = true;
            SearchTermTextBox.IsEnabled = true;
        }

        private void AnimateHeaderLogout()
        {
            DoubleAnimation da = new DoubleAnimation(0,122, new TimeSpan(0, 0, 2));
            ElasticEase ease = new ElasticEase();
            ease.Springiness = 10;
            ease.Oscillations = 0;
            ease.EasingMode = EasingMode.EaseOut;
            da.EasingFunction = ease;
            image.BeginAnimation(Canvas.LeftProperty, da);
        }

    }
}
