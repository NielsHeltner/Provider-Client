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
            List<Button> buttons = new List<Button>();
            buttons.Add(button);
            buttons.Add(button2);
            buttons.Add(button1);
            buttons.Add(logout);
            logIn = new LogIn(frame, frontpage, buttons, loggedIn, searchText, SearchTermTextBox, this);
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
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
            loggedIn.Visibility = Visibility.Hidden;
            //searchText.Visibility = Visibility.Hidden;
            searchText.Opacity = 0;
            //searchText.Opacity = 1;
            //SearchTermTextBox.Visibility = Visibility.Hidden;
            SearchTermTextBox.Opacity = 0;
            SearchTermTextBox.IsEnabled = false;
        }
        public void AnimateHeaderLogin()
        {
            AnimateAfterImageCompleted();
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 0, 2, 0);
            DoubleAnimation doubleanimate = new DoubleAnimation();
            doubleanimate.To = 0;
            doubleanimate.From = 90;
            doubleanimate.Duration = new Duration(duration);
            Storyboard.SetTargetName(doubleanimate, image.Name);
            Storyboard.SetTargetProperty(doubleanimate, new PropertyPath(Canvas.LeftProperty));
            storyboard.Children.Add(doubleanimate);

            ElasticEase ease = new ElasticEase();
            ease.Springiness = 10;
            ease.Oscillations = 0;
            ease.EasingMode = EasingMode.EaseOut;
            doubleanimate.EasingFunction = ease;

            //storyboard.Completed += AnimateAfterImageCompleted;
           
            storyboard.Begin(this);
        }
        private void AnimateAfterImageCompleted()
        {
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, 500);

            DoubleAnimation doubleanimation = new DoubleAnimation(0, 1, duration, FillBehavior.Stop);
            Storyboard.SetTargetName(doubleanimation, SearchTermTextBox.Name);
            Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(Control.OpacityProperty));
            storyboard.Children.Add(doubleanimation);

            DoubleAnimation searchTextAnimate = new DoubleAnimation(0, 1, duration, FillBehavior.Stop);
            Storyboard.SetTargetName(searchTextAnimate, searchText.Name);
            Storyboard.SetTargetProperty(searchTextAnimate, new PropertyPath(Control.OpacityProperty));
            storyboard.Children.Add(searchTextAnimate);
            storyboard.Completed += AnimateControlsCompleted;

            storyboard.Begin(this);

            SearchTermTextBox.IsEnabled = true;
        }

        private void AnimateControlsCompleted(object sender, EventArgs e)
        {
            searchText.Opacity = 1;
            SearchTermTextBox.Opacity = 1;
        }

        private void AnimateHeaderLogout()
        {
            TimeSpan dur = new TimeSpan(0, 0, 0, 2, 0);
            DoubleAnimation da = new DoubleAnimation(0,90, dur);
            ElasticEase ease = new ElasticEase();
            ease.Springiness = 10;
            ease.Oscillations = 0;
            ease.EasingMode = EasingMode.EaseOut;
            da.EasingFunction = ease;
            image.BeginAnimation(Canvas.LeftProperty, da);
        }
    }
}
