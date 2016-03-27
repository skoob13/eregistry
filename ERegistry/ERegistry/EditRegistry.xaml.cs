using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для EditRegistry.xaml
    /// </summary>
    public partial class EditRegistry : Window
    {
        private Reg Registry;

        public EditRegistry(Reg registry, Brush color)
        {
            InitializeComponent();

            bg.Background = color;
            Registry = registry;
            Service.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectServices).DefaultView;

            labelName.Text = registry.Client.Name + " " + registry.Client.SecondName;
            labelSurame.Text = registry.Client.Surname;
            labelTime.Text = Utils.GCTime(registry.Time.Hour) + ":" + Utils.GCTime(registry.Time.Minute);
            labelDoctor.Text = registry.Doctor.Name + " " + registry.Doctor.Otch;
            labelService.Text = registry.Service.Title;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GetCheck_Click(object sender, RoutedEventArgs e)
        {
            //Set to paid
            string file = Reports.CreateCheck(Registry);
            Process.Start(file);
            
            if (!String.IsNullOrEmpty(file))
            {
                ApplicationController.UpdatePayment(Registry.ID, true);
            }
        }

        private void Service_b_Click(object sender, RoutedEventArgs e)
        {
            if (Service_tb.Text.Length > 0)
            {
                Service.ItemsSource = ApplicationController.SelectServices(Service_tb.Text).DefaultView;
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (Service.SelectedItem != null)
            {
                bool back = ApplicationController.UpdateRegistryByService(Registry.ID, ApplicationController.ParseService((Service.SelectedItem as DataRowView).Row.ItemArray).ID);

                if (back)
                    OK_step2.Visibility = Visibility.Visible;
                else MessageBox.Show("Невозможно изменить запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
