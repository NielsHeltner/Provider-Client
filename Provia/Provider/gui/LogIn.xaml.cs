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

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        private Frame frame;
        private Frontpage frontpage;
        private List<Button> buttons;
        private Label loggedIn;
        private TextBlock searchText;
        private TextBox searchBox;
        private MainWindow mainwindow;
        public LogIn(Frame frame, Frontpage frontpage, List<Button> buttons, Label loggedIn, TextBlock searchText, TextBox searchBox, MainWindow mainwindow)
        {
            InitializeComponent();
            this.frame = frame;
            this.frontpage = frontpage;
            this.buttons = buttons;
            this.loggedIn = loggedIn;
            this.searchText = searchText;
            this.searchBox = searchBox;
            this.mainwindow = mainwindow;
        }

        private void LogUserIn(object sender, RoutedEventArgs e)
        {
            mainwindow.AnimateHeaderLogin();
            loggedIn.Visibility = Visibility.Visible;
            //searchText.Visibility = Visibility.Visible;
            //searchBox.Visibility = Visibility.Visible;
            foreach(Button button in buttons)
            {
                button.Visibility = Visibility.Visible;
            }
            frame.Content = frontpage;
            frame.NavigationService.RemoveBackEntry();
        }
    }
}
