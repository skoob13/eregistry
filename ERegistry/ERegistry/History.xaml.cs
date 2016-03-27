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

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        private Client SelectedClient;

        public History()
        {
            InitializeComponent();

            Search.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectHistory).DefaultView;
            Clients.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectClients).DefaultView;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddHistory ah = new AddHistory();
            ah.ShowDialog();
            Search.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectHistory).DefaultView;
        }

        private void SelectClient_Click(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedItem != null)
            {
                SelectedClient = ApplicationController.ParseClient((Clients.SelectedItem as System.Data.DataRowView).Row.ItemArray);
                Results.Text = "Результаты поиска для клиента: ";
                ResultsName.Text = SelectedClient.ToString();

                Search.ItemsSource = ApplicationController.SelectHistoryByClient(SelectedClient).DefaultView;
            }
        }

        private void b_search_Click(object sender, RoutedEventArgs e)
        {
            if (surname.Text.Length == 0 && passport.Text.Length == 0 && name.Text.Length == 0 &&
                otch.Text.Length == 0 && birth.SelectedDate == null)
            {
                return;
            }

            bool flag = false;
            string cmd = SQLCommands.SelectClients + " WHERE ";

            if (!passport.Text.Contains('_'))
            {
                cmd += And(flag) + "clients.passport LIKE '%" + passport.Text + "%'";
                flag = true;
            }

            if (surname.Text.Length > 0)
            {
                cmd += And(flag) + "clients.surname LIKE '%" + surname.Text + "%'";
                flag = true;
            }

            if (name.Text.Length > 0)
            {
                cmd += And(flag) + "clients.name LIKE '%" + name.Text + "%'";
                flag = true;
            }

            if (otch.Text.Length > 0)
            {
                cmd += And(flag) + "clients.otch LIKE '%" + otch.Text + "%'";
                flag = true;
            }

            if (birth.SelectedDate != null)
            {
                cmd += And(flag) + "clients.birth='" + ApplicationController.GetCorrectDate((DateTime)birth.SelectedDate) + "'";
                flag = true;
            }

            Clients.ItemsSource = ApplicationController.ExecuteQuery(cmd).DefaultView;
        }

        private static string And(bool b)
        {
            if (b) return " AND ";
            else return "";
        }

        private void b_flush_Click(object sender, RoutedEventArgs e)
        {
            surname.Text = "";
            name.Text = "";
            passport.Text = "";
            otch.Text = "";
            birth.Text = "";
            Results.Text = "Результаты поиска: ";
            ResultsName.Text = "";
            //here need to flush clients
            Clients.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectClients).DefaultView;
            Search.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectHistory).DefaultView;
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (Search.SelectedItem != null)
            {
                HistoryEntity he = ApplicationController.ParseHistory((Search.SelectedItem as System.Data.DataRowView).Row.ItemArray);
                ShowHistory sh = new ShowHistory(he, true);
                sh.ShowDialog();
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            if (Search.SelectedItem != null)
            {
                HistoryEntity he = ApplicationController.ParseHistory((Search.SelectedItem as System.Data.DataRowView).Row.ItemArray);
                var result = MessageBox.Show(String.Format("Вы действительно хотите удалить запись №{0} от {1}?", he.ID.ToString(), he.GetCorrectDate()), "Электронная регистратура", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ApplicationController.DeleteHistory(he.ID);
                    Search.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectHistory).DefaultView;
                }
            }
        }

        private void Search_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Search.SelectedItem != null)
            {
                HistoryEntity he = ApplicationController.ParseHistory((Search.SelectedItem as System.Data.DataRowView).Row.ItemArray);
                ShowHistory sh = new ShowHistory(he, false);
                sh.ShowDialog();
            }
        }
    }
}
