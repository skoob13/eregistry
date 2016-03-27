using System;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для AddRegistry.xaml
    /// </summary>
    public partial class AddRegistry : Window
    {
        private Reg registry;
        private Client selectedClient;
        private Service selectedService;
        private Action<bool> cb;

        public AddRegistry(Action<bool> callback, Reg Registry, Brush color)
        {
            InitializeComponent();

            cb = callback;

            top.Background = color;
            bot.Background = color;

            registry = Registry;

            Time.Text = registry.Time.Hour + ":" + Registry.Time.Minute;
            name_doctor.Text = registry.Doctor.Surname + " " + registry.Doctor.Name + " " + registry.Doctor.Otch;

            Clients.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectClients).DefaultView;
            Services.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectServices).DefaultView;
        }

        private void Surname_find_click(object sender, RoutedEventArgs e)
        {
            if (Surname_search.Text.Length > 0)
            {
                Clients.ItemsSource = ApplicationController.SelectClientBySurname(Surname_search.Text).DefaultView;
            }
        }

        private void Service_search_button_Click(object sender, RoutedEventArgs e)
        {
            if (Service_search.Text.Length > 0)
            {
                Services.ItemsSource = ApplicationController.SelectServices(Service_search.Text).DefaultView;
            }
        }

        private void SelectClient_Click(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedItem != null)
            {
                selectedClient = ApplicationController.ParseClient((Clients.SelectedItem as DataRowView).Row.ItemArray);
                OK_step1.Visibility = Visibility.Visible;
            }
        }

        private void SelectService_Click(object sender, RoutedEventArgs e)
        {
            if (Services.SelectedItem != null)
            {
                selectedService = ApplicationController.ParseService((Services.SelectedItem as DataRowView).Row.ItemArray);
                OK_step2.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (OK_step1.Visibility == Visibility.Visible && OK_step2.Visibility == Visibility.Visible)
            {
                cb(ApplicationController.AddRegistry(selectedClient.ID, registry.Doctor.ID, selectedService.ID, registry.Time, (bool)Push.IsChecked, (bool)Paid.IsChecked));
                this.Close();
            }
        }

        private void Flush_Click(object sender, RoutedEventArgs e)
        {
            Surname_search.Text = "";
            Service_search.Text = "";

            OK_step1.Visibility = Visibility.Hidden;
            OK_step2.Visibility = Visibility.Hidden;

            Clients.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectClients).DefaultView;
            Services.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectServices).DefaultView;
        }
    }
}
