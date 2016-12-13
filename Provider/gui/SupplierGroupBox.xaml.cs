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
        private IO.Swagger.Model.Page page;

        public SupplierGroupBox(IO.Swagger.Model.Page page)
        {
            InitializeComponent();
            HideBorderandSetArrow();
            this.page = Controller.instance.FindPage(page);
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
                page = Controller.instance.FindPageByName(page.Owner);
                ContactInformation.Text = page.ContactInformation;
                Location.Text = page.Location;
                Description.Text = page.Description;
                if (page.Note != null)
                {
                    noteTextBox.Text = page.Note.Text;
                    lastEdited.Text = ((DateTime) page.Note.CreationDate).ToLongDateString();
                    lastEditor.Text = page.Note.Editor + ".";
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
                editNote.Content = "Rediger note";
                lastEdited.Text = DateTime.Today.ToLongDateString();
                lastEditor.Text = Controller.instance.GetLoggedInUser().Username + ".";
                Controller.instance.AddNoteToSupplier(page.Owner, Controller.instance.GetLoggedInUser().Username, noteTextBox.Text);
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
                page.Description = Description.Text;
                page.ContactInformation = ContactInformation.Text;
                page.Location = Location.Text;
                Controller.instance.ManageSupplierPage(page);
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
