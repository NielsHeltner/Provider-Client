using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            HideBorderandSetArrow();
            this.Page = Controller.instance.GetPages().Find(p => p.Equals(Page));
            Refresh();

            if (Controller.instance.GetLoggedInUser().Rights == User.RightsEnum.Provia)
            {
                LocationBox.Height = 60;
                ContactInfoBox.Height = 60;
                editPage.Visibility = Visibility.Collapsed;
            }
            else if (Controller.instance.GetLoggedInUser().Rights == User.RightsEnum.Supplier)
            {
                LocationBox.Height = 240;
                ContactInfoBox.Height = 240;
                noteTextBox.Visibility = Visibility.Collapsed;
                editNote.Visibility = Visibility.Collapsed;
                editerBox.Visibility = Visibility.Collapsed;
                noteGroup.Visibility = Visibility.Collapsed;
            }
            else
            {
                LocationBox.Height = 60;
                ContactInfoBox.Height = 60;
            }
            noteTextBox.Cursor = Cursors.Arrow;
            Update();
        }

        private void Update()
        {
            new Thread(() =>
            {
                while (true)
                {
                    lock (Controller.instance.GetUpdateLock())
                    {
                        Monitor.Wait(Controller.instance.GetUpdateLock());
                        Refresh();
                    }
                }
            }).Start();
        }

        private void Refresh()
        {
            Dispatcher.Invoke((ThreadStart)delegate
            {
                ContactInformation.Text = Page.ContactInformation;
                Location.Text = Page.Location;
                Description.Text = Page.Description;
                if (Page.Note != null)
                {
                    noteTextBox.Text = Page.Note.Text;
                    lastEdited.Text = ((DateTime) Page.Note.CreationDate).ToLongDateString() + ".";
                    lastEditor.Text = Page.Note.Editor;
                }
            });
        }

        private void EditNote(object sender, RoutedEventArgs e)
        {
            if (noteTextBox.IsReadOnly)
            {
                noteTextBox.AcceptsReturn = true;
                noteTextBox.Cursor = Cursors.IBeam;
                noteTextBox.IsReadOnly = false;
                noteTextBox.BorderThickness = new Thickness(1, 1, 1, 1);
                editNote.Content = "Gem";
            }
            else
            {
                noteTextBox.Cursor = Cursors.Arrow;
                noteTextBox.BorderThickness = new Thickness(0, 0, 0, 0);
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
                Description.BorderThickness = new Thickness(1, 1, 1, 1);
                ContactInformation.BorderThickness = new Thickness(1, 1, 1, 1);
                Location.BorderThickness = new Thickness(1, 1, 1, 1);
                Description.Cursor = Cursors.IBeam;
                Location.Cursor = Cursors.IBeam;
                ContactInformation.Cursor = Cursors.IBeam;
                editPage.Content = "Gem";
            }
            else
            {
                Description.IsReadOnly = true;
                ContactInformation.IsReadOnly = true;
                Location.IsReadOnly = true;
                HideBorderandSetArrow();
                editPage.Content = "Rediger informationer";
                Page.Description = Description.Text;
                Page.ContactInformation = ContactInformation.Text;
                Page.Location = Location.Text;
                Controller.instance.ManageSupplerPage(Page);
            }
        }

        private void HideBorderandSetArrow()
        {
            Description.Cursor = Cursors.Arrow;
            ContactInformation.Cursor = Cursors.Arrow;
            Location.Cursor = Cursors.Arrow;
            noteTextBox.Cursor = Cursors.Arrow;
            Description.BorderThickness = new Thickness(0, 0, 0, 0);
            ContactInformation.BorderThickness = new Thickness(0, 0, 0, 0);
            Location.BorderThickness = new Thickness(0, 0, 0, 0);
            noteTextBox.BorderThickness = new Thickness(0, 0, 0, 0);
        }
    }
}
