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
            //SearchTermTextBox.Visibility = Visibility.Hidden;
            SearchTermTextBox.Opacity = 0;
        }
        public void AnimateHeaderLogin()
        {
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 1);
            DoubleAnimation doubleanimate = new DoubleAnimation();
            doubleanimate.To = 0;
            doubleanimate.From = 90;
            doubleanimate.Duration = new Duration(duration);
            Storyboard.SetTargetName(doubleanimate, image.Name);
            Storyboard.SetTargetProperty(doubleanimate, new PropertyPath(Canvas.LeftProperty));
            storyboard.Children.Add(doubleanimate);
            storyboard.Completed += new EventHandler(AnimateAfterImageCompleted);

            storyboard.Begin(this);
        }
        private void AnimateAfterImageCompleted(object sender, EventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 1);

            DoubleAnimation doubleanimation = new DoubleAnimation(0, 1, new Duration(duration));
            Storyboard.SetTargetName(doubleanimation, SearchTermTextBox.Name);
            Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(Control.OpacityProperty));
            storyboard.Children.Add(doubleanimation);

            DoubleAnimation searchTextAnimate = new DoubleAnimation(0, 1, new Duration(duration));
            Storyboard.SetTargetName(searchTextAnimate, searchText.Name);
            Storyboard.SetTargetProperty(searchTextAnimate, new PropertyPath(Control.OpacityProperty));
            storyboard.Children.Add(searchTextAnimate);

            storyboard.Begin(this);
        }
        private void AnimateHeaderLogout()
        {
            Storyboard sb = new Storyboard();
            TimeSpan dur = new TimeSpan(0, 0, 1);
            DoubleAnimation da = new DoubleAnimation();
            da.To = 90;
            da.From = 0;
            da.Duration = new Duration(dur);
            Storyboard.SetTargetName(da, image.Name);
            Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
            sb.Children.Add(da);
            sb.Begin(this);
        }
    }
}
