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
        }

        private void SetVisibilityToHidden()
        {
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
            loggedIn.Visibility = Visibility.Hidden;
            searchText.Visibility = Visibility.Hidden;
            SearchTermTextBox.Visibility = Visibility.Hidden;
        }

        public void button1_Click()
        {
            Storyboard sb = new Storyboard();
            TimeSpan dur = new TimeSpan(0, 0, 2);
            DoubleAnimation da = new DoubleAnimation();
            da.To = 92;
            da.From = 213;
            da.Duration = new Duration(dur);
            Storyboard.SetTargetName(da, image.Name);
            Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
            sb.Children.Add(da);
            //sb.Completed += Sb_Completed;
            

            sb.Begin(this);

        }

    }
}
