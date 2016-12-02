using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Provider.domain;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SupplierGroupBox : Page
    {
        private IO.Swagger.Model.Page page2;

        public SupplierGroupBox(IO.Swagger.Model.Page page)
        {
            InitializeComponent();
            this.page2 = page;
            if(page2.Note != null)
            {
                noteTextBox.Text = page2.Note.Text;
                lastEdited.Text = ((DateTime) page2.Note.CreationDate).ToLongDateString() + ".";
                lastEditor.Text = page2.Note.Editor;
            }
            noteTextBox.Cursor = Cursors.Arrow;
        }

        private void EditNote(object sender, RoutedEventArgs e)
        {
            if (noteTextBox.IsReadOnly)
            {
                noteTextBox.AcceptsReturn = true;
                noteTextBox.Cursor = Cursors.IBeam;
                noteTextBox.IsReadOnly = false;          
                editNote.Content = "Gem";

            }
            else
            {
                noteTextBox.Cursor = Cursors.Arrow;
                noteTextBox.IsReadOnly = true;
                editNote.Content = "Rediger notater";
                lastEdited.Text = DateTime.Today.ToLongDateString() + ".";
                lastEditor.Text = Controller.instance.GetLoggedInUser().Username;
                Controller.instance.AddNoteToSupplier(page2.Owner, Controller.instance.GetLoggedInUser().Username, noteTextBox.Text);
            }
        }
    }
}
