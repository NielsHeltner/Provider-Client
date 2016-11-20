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
        private IO.Swagger.Model.Page page2;
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

        public SupplierGroupBox(IO.Swagger.Model.Page page)
        {
            InitializeComponent();
            this.page2 = page;
            if(page2.Note != null)
            {
                noteTextBox.Text = page2.Note.Text;
                lastEdited.Text = ((DateTime) page2.Note.CreationDate).ToLongDateString();
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
                Controller.instance.AddNoteToSupplier(page2.Owner, noteTextBox.Text);
            }
        }
    }
}
