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
        private IO.Swagger.Model.Page Page;

        public SupplierGroupBox(IO.Swagger.Model.Page Page)
        {
            InitializeComponent();
            this.Page = Page;
            ContactInformation.Text = Page.ContactInformation;
            Location.Text = Page.Location;
            Description.Text = Page.Description;
            if(this.Page.Note != null)
            {
                noteTextBox.Text = this.Page.Note.Text;
                lastEdited.Text = ((DateTime) this.Page.Note.CreationDate).ToLongDateString() + ".";
                lastEditor.Text = this.Page.Note.Editor;
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
                lastEdited.Text = DateTime.Today.ToLongDateString() + ".";
                lastEditor.Text = Controller.instance.GetLoggedInUser().Username;
                Controller.instance.AddNoteToSupplier(Page.Owner, Controller.instance.GetLoggedInUser().Username, noteTextBox.Text);
            }
        }
    }
}
