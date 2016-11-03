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
        Frame frame;
        Frontpage frontpage;
        List<Button> buttons;
        Label logged_in;
        TextBlock searchText;
        TextBox searchBox;
        public LogIn(Frame frame, Frontpage frontpage, List<Button> button, Label logged_in, TextBlock searchText, TextBox searchBox)
        {
            InitializeComponent();
            this.frame = frame;
            this.frontpage = frontpage;
            this.buttons = button;
            this.logged_in = logged_in;
            this.searchText = searchText;
            this.searchBox = searchBox;
        }

        private void LogUserIn(object sender, RoutedEventArgs e)
        {
            logged_in.Visibility = Visibility.Visible;
            searchText.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            foreach(Button button in buttons)
            {
                button.Visibility = Visibility.Visible;
            }

            frame.Content = frontpage;
        }
    }
}
