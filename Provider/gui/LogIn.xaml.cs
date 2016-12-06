using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using IO.Swagger.Client;
using Provider.domain;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        private Frame frame;
        private MainWindow mainwindow;
        public Frontpage frontpage { get; set; }

        public LogIn(Frame frame, MainWindow mainwindow, Frontpage frontpage)
        {
            InitializeComponent();
            this.frame = frame;
            this.mainwindow = mainwindow;
            this.frontpage = frontpage;
            wrongUsernameOrPassword.Visibility = Visibility.Hidden;
            usernameBox.Focus();
        }

        private void LogUserIn(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                Dispatcher.Invoke((ThreadStart)delegate
                {
                    try
                    {
                        if (Controller.instance.LogIn(usernameBox.Text, passwordBox.Password))
                        {
                            wrongUsernameOrPassword.Visibility = Visibility.Hidden;
                            mainwindow.AnimateHeaderLogin();
                            mainwindow.LoggedIn.Content = Controller.instance.GetLoggedInUser().Username +
                                                            " logget ind";
                            if (Controller.instance.GetLoggedInUser().Rights.Value ==
                                IO.Swagger.Model.User.RightsEnum.Supplier)
                            {
                                frame.Content = mainwindow.LoginSupplier();
                            }
                            else
                            {
                                frame.Content = mainwindow.LoginProvia();
                            }
                        }
                        else
                        {
                            wrongUsernameOrPassword.Visibility = Visibility.Visible;
                            DoubleAnimationUsingKeyFrames animationKeyFrames =
                                new DoubleAnimationUsingKeyFrames();
                            DoubleKeyFrameCollection frameCollection = new DoubleKeyFrameCollection
                                {
                                    new EasingDoubleKeyFrame(40, new TimeSpan(0, 0, 0, 0, 50)),
                                    new EasingDoubleKeyFrame(70, new TimeSpan(0, 0, 0, 0, 100)),
                                    new EasingDoubleKeyFrame(40, new TimeSpan(0, 0, 0, 0, 150)),
                                    new EasingDoubleKeyFrame(70, new TimeSpan(0, 0, 0, 0, 200)),
                                    new EasingDoubleKeyFrame(40, new TimeSpan(0, 0, 0, 0, 250)),
                                    new EasingDoubleKeyFrame(56, new TimeSpan(0, 0, 0, 0, 300))
                                };
                            animationKeyFrames.KeyFrames = frameCollection;
                            usernameBox.BeginAnimation(Canvas.LeftProperty, animationKeyFrames);
                            usernameText.BeginAnimation(Canvas.LeftProperty, animationKeyFrames);
                            passwordBox.BeginAnimation(Canvas.LeftProperty, animationKeyFrames);
                            passwordText.BeginAnimation(Canvas.LeftProperty, animationKeyFrames);
                        }
                    }
                    catch (ApiException ex)
                    {
                        wrongUsernameOrPassword.Visibility = Visibility.Visible;
                        wrongUsernameOrPassword.Text = "Kunne ikke oprette forbindelse\ntil serveren. Prøv igen.";
                    }
                });
            }).Start();
        }

        private void UsernameGotFocus(object sender, RoutedEventArgs e)
        {
            usernameText.Visibility = Visibility.Hidden;
        }

        private void UsernameLostFocus(object sender, RoutedEventArgs e)
        {
            if(usernameBox.Text.Length == 0)
            {
                usernameText.Visibility = Visibility.Visible;
            }
        }

        private void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            passwordText.Visibility = Visibility.Hidden;
        }

        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length == 0)
            {
                passwordText.Visibility = Visibility.Visible;
            }
        }

        private void SubmitForm(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LogUserIn(sender, e);
            }
        }
    }
}
