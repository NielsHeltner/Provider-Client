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
using Provider.domain;
using Provider.domain.users;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SupplierGroupBox : Page
    {
        private Provider.domain.page.Page page;
        public SupplierGroupBox(Provider.domain.page.Page page)
        {
            InitializeComponent();
            this.page = page;
            if(page.note != null)
            {
                noteTextBox.Text = page.note.text;
            }
            else
            {
                noteTextBox.Text = "Note er null";
            }
        }

        private void EditNote(object sender, RoutedEventArgs e)
        {
            if (noteTextBox.IsReadOnly)
            {
                noteTextBox.IsReadOnly = false;
                editNote.Content = "Gem";
            }
            else
            {
                noteTextBox.IsReadOnly = true;
                editNote.Content = "Rediger notater";
                Controller.instance.AddNoteToSupplier(page.name, noteTextBox.Text);
            }
        }
    }
}
