using System;
using System.Windows;
using System.Windows.Controls;
using Provider.domain;

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
                lastEdited.Text = page.note.creationDate.ToLongDateString();
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
                lastEdited.Text = DateTime.Today.ToLongDateString();
                Controller.instance.AddNoteToSupplier(page.owner, noteTextBox.Text);
            }
        }
    }
}
