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

    public partial class Antonio : Page
    {
        private Frame mainWindow;

        public Antonio(Frame mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void changeToNiels(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Nils();
        }
    }
}
