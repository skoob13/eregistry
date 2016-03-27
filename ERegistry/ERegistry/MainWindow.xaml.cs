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

/*
Default color scheme:
H1: #666674
Menu BG: #19191F
Menu selected bg: #101014
Main text color: #69696D
*/

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Components for navigation
        private Page _registry;
        private Page _history;
        private Page _usergroups;
        private Page _forms;

        //Navigation route
        private string _route;
        private User user;

        public MainWindow()
        {
            InitializeComponent();

            _registry = new Registry();
            _history = new History();
            _usergroups = new UserGroups();
            _forms = new Forms();

            ToggleMenu("Registry");

            Login.Text = "a";
            Password.Password = "123";
        }

        private void ToggleMenu(string Route)
        {
            if (Route == _route) return;

            UntoggleMenu(_route);

            switch (Route)
            {
                case "Registry":
                    _route = "Registry";
                    NavigationPage.Navigate(_registry);
                    RegistryGrid.Background = new SolidColorBrush(Utils.ConvertStringToColor("101014"));
                    RegistryRect.Visibility = Visibility.Visible;
                    RegistryTB.Foreground = new SolidColorBrush(Colors.White);
                    break;
                case "Man":
                    _route = "Man";
                    NavigationPage.Navigate(_usergroups);
                    ManGrid.Background = new SolidColorBrush(Utils.ConvertStringToColor("101014"));
                    ManRect.Visibility = Visibility.Visible;
                    ManTB.Foreground = new SolidColorBrush(Colors.White);
                    break;
                case "History":
                    _route = "History";
                    NavigationPage.Navigate(_history);
                    HisGrid.Background = new SolidColorBrush(Utils.ConvertStringToColor("101014"));
                    HisRect.Visibility = Visibility.Visible;
                    HisTB.Foreground = new SolidColorBrush(Colors.White);
                    break;
                case "Forms":
                    _route = "Forms";
                    NavigationPage.Navigate(_forms);
                    FormsGrid.Background = new SolidColorBrush(Utils.ConvertStringToColor("101014"));
                    FormsRect.Visibility = Visibility.Visible;
                    FormsTB.Foreground = new SolidColorBrush(Colors.White);
                    break;
            }
        }

        private void UntoggleMenu(string Route)
        {
            switch (Route)
            {
                case "Registry":
                    RegistryGrid.Background = new SolidColorBrush(Colors.Transparent);
                    RegistryRect.Visibility = Visibility.Hidden;
                    RegistryTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("69696D"));
                    break;
                case "Man":
                    ManGrid.Background = new SolidColorBrush(Colors.Transparent);
                    ManRect.Visibility = Visibility.Hidden;
                    ManTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("69696D"));
                    break;
                case "History":
                    HisGrid.Background = new SolidColorBrush(Colors.Transparent);
                    HisRect.Visibility = Visibility.Hidden;
                    HisTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("69696D"));
                    break;
                case "Forms":
                    FormsGrid.Background = new SolidColorBrush(Colors.Transparent);
                    FormsRect.Visibility = Visibility.Hidden;
                    FormsTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("69696D"));
                    break;
            }
        }

        private void RegistryGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleMenu("Registry");
        }

        private void ManGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleMenu("Man");
        }

        private void HisGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleMenu("History");
        }

        private void FormsGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleMenu("Forms");
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (login.Visibility == Visibility.Visible)
            {
                login.Visibility = Visibility.Hidden;
                reg.Visibility = Visibility.Visible;
            }
            else
            {
                login.Visibility = Visibility.Visible;
                reg.Visibility = Visibility.Hidden;
            }
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length > 0 && Password.Password.Length >= 3)
            {
                if (ApplicationController.FindUser(Login.Text, Utils.ToMD5(Password.Password)))
                {
                    user = new User(Login.Text, Password.Password, ApplicationController.GetUserAccess(Login.Text, Utils.ToMD5(Password.Password)));
                    ParseUser();
                }
                else
                {
                    MessageBox.Show("Связка логин-пароль не была найдена в базе данных!", "Электронная регистратура", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            if (reg_name.Text.Length > 0 && reg_pas.Password.Length >= 3 && 
                reg_pas_again.Password == reg_pas.Password && 
                reg_type.SelectedItem != null )
            {
                string md5 = Utils.ToMD5(reg_pas.Password);
                if (!ApplicationController.FindUser(reg_name.Text, md5))
                {
                    User u = new User(reg_name.Text, md5, reg_type.SelectedIndex + 1);
                    if (!ApplicationController.AddUser(u))
                    {
                        MessageBox.Show("Ошибка: не удалось добавить в базу данных!", "Электронная регистратура", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        user = u;
                        MessageBox.Show("Вы зарегистрированы!", "Электронная регистратура", MessageBoxButton.OK, MessageBoxImage.Information);
                        ParseUser();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь уже существует в базе данных!", "Электронная регистратура", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Электронная регистратура", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ParseUser()
        {
            Overlay.Visibility = Visibility.Hidden;
            Login_Tb.Text = user.Login;
            if (user.Access == 2)
            {
                Grid.SetRow(HisGrid, 0);
                ToggleMenu("History");
                RegistryGrid.Visibility = Visibility.Hidden;
                ManGrid.Visibility = Visibility.Hidden;
                FormsGrid.Visibility = Visibility.Hidden;
                Avatar.Source = Application.Current.Resources["DoctorDefault"] as ImageSource;
            }
            else if (user.Access == 3)
            {
                //chief
                Avatar.Source = Application.Current.Resources["ChiefDefault"] as ImageSource;
            }
            else
            {
                //adm
                Avatar.Source = Application.Current.Resources["AdDefault"] as ImageSource;
            }
        }
    }
}
