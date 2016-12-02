using System;
using System.Windows;
using System.Windows.Controls;
using Provider.domain;
using IO.Swagger.Model;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SupplierGroupBox : System.Windows.Controls.Page
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

            if (Controller.instance.GetLoggedInUser().Rights == User.RightsEnum.Provia)
            {
                editPage.Visibility = Visibility.Collapsed;
            }
            else if (Controller.instance.GetLoggedInUser().Rights == User.RightsEnum.Supplier)
            {
                noteTextBox.Visibility = Visibility.Collapsed;
                editNote.Visibility = Visibility.Collapsed;
                editerBox.Visibility = Visibility.Collapsed;
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

        private void ManageSupplierPage(object sender, RoutedEventArgs e)
        {
            if (Description.IsReadOnly)
            {
                Description.IsReadOnly = false;
                ContactInformation.IsReadOnly = false;
                Location.IsReadOnly = false;
                editPage.Content = "Gem";
            }
            else
            {
                Description.IsReadOnly = true;
                ContactInformation.IsReadOnly = true;
                Location.IsReadOnly = true;
                editPage.Content = "Rediger informationer";
                Page.Description = Description.Text;
                Page.ContactInformation = ContactInformation.Text;
                Page.Location = Location.Text;
                Controller.instance.ManageSupplerPage(Page);
            }
        }
    }
}
