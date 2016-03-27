using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для AddGraph.xaml
    /// </summary>
    public partial class AddGraph : Window
    {
        private Employee SelectedEmployee;
        private Specialization SelectedSpec;
        private Graph SelectedGraph;

        private Action<bool> cb;

        public AddGraph(Action<bool> callback)
        {
            InitializeComponent();
            Doctors.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectEmployees).DefaultView;
            Spec.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectSpecializations).DefaultView;
            cb = callback;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Surname_search.Text.Length > 0)
            {
                Doctors.ItemsSource = ApplicationController.SelectEmployeeBySurname(Surname_search.Text).DefaultView;
            }
        }

        private void Spec_search_button_Click(object sender, RoutedEventArgs e)
        {
            if (Spec_search.Text.Length > 0)
            {
                Spec.ItemsSource = ApplicationController.SelectSpectializations(Spec_search.Text).DefaultView;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Doctors.SelectedItem != null)
            {
                SelectedEmployee = ApplicationController.ParseEmployee((Doctors.SelectedItem as DataRowView).Row.ItemArray);
                OK_step1.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Spec.SelectedItem != null)
            {
                SelectedSpec = ApplicationController.ParseSpecialization((Spec.SelectedItem as DataRowView).Row.ItemArray);
                OK_step2.Visibility = Visibility.Visible;
            }
        }

        private void CrGraph_Click(object sender, RoutedEventArgs e)
        {
            AddToDB a = new AddToDB("Graph", (b)=> { });
            a.ShowDialog();
            
            if (a.CreatedGraph != null)
            {
                SelectedGraph = a.CreatedGraph;
                OK_step3.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OK_step1.Visibility = Visibility.Hidden;
            OK_step2.Visibility = Visibility.Hidden;
            OK_step3.Visibility = Visibility.Hidden;
            Spec_search.Text = "";
            Surname_search.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (OK_step1.Visibility == Visibility.Visible &&
                OK_step2.Visibility == Visibility.Visible &&
                OK_step3.Visibility == Visibility.Visible)
            {
                cb(ApplicationController.AddGraph(SelectedEmployee, SelectedSpec, SelectedGraph));
                this.Close();
            }
        }
    }
}
