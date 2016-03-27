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
using System.Windows.Shapes;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для AddHistory.xaml
    /// </summary>
    public partial class AddHistory : Window
    {
        private int SelectedRegistryID;
        private DateTime dtDefaultValue;
        private Client SelectedClient;
        private DateTime SelectedDT;
        private List<Analyse> SelectedAnalyzes;

        public AddHistory()
        {
            InitializeComponent();
            Clients.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectAddHistory).DefaultView;
 
            dtDefaultValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtDefaultValue.AddSeconds(47);

            rDate.Value = dtDefaultValue;
        }

        private void b_search_Click(object sender, RoutedEventArgs e)
        {
            if (passport.Text.Contains('_') && surname.Text.Length == 0 && name.Text.Length == 0 &&
                otch.Text.Length == 0 && birth.SelectedDate == null && rDate.Value == dtDefaultValue)
            {
                return;
            }

            bool flag = false;
            string cmd = SQLCommands.SelectAddHistory + " WHERE ";

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

            if (rDate.Value != dtDefaultValue)
            {
                cmd += And(flag) + "registry.datetime='" + ApplicationController.GetCorrectDateTime((DateTime)rDate.Value) + "'";
                flag = true;
            }

            Clients.ItemsSource = ApplicationController.ExecuteQuery(cmd).DefaultView;
        }

        private void b_flush_Click(object sender, RoutedEventArgs e)
        {
            surname.Text = "";
            name.Text = "";
            passport.Text = "";
            otch.Text = "";
            birth.Text = "";
            rDate.Value = dtDefaultValue;
            //here need to flush clients
            Clients.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectAddHistory).DefaultView;
        }

        private static string And(bool b)
        {
            if (b) return " AND ";
            else return "";
        }

        private void SelectReg_Click(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedItem != null)
            {
                SelectedClient = ApplicationController.ParseClient(ApplicationController.ExecuteQuery("SELECT * FROM clients WHERE client_id="+(Clients.SelectedItem as System.Data.DataRowView).Row.ItemArray[2].ToString()).Rows[0].ItemArray);
                SelectedDT = (DateTime)(Clients.SelectedItem as System.Data.DataRowView).Row.ItemArray[1];
                SelectedRegistryID = Convert.ToInt32((Clients.SelectedItem as System.Data.DataRowView).Row.ItemArray[0]);

                OK_step1.Visibility = Visibility.Visible;

                tb_client.Visibility = Visibility.Visible;
                tb_dt.Visibility = Visibility.Visible;
                client_surname.Text = SelectedClient.ToString();
                registry_date.Text = Utils.GCTime(SelectedDT.Day) + "." + Utils.GCTime(SelectedDT.Month) + "." + SelectedDT.Year;
                registry_time.Text = Utils.GCTime(SelectedDT.Hour) + ":" + Utils.GCTime(SelectedDT.Minute);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            tb_curing.BorderBrush = new SolidColorBrush(Colors.Transparent);
            tb_details.BorderBrush = new SolidColorBrush(Colors.Transparent);
            tb_diagnosis.BorderBrush = new SolidColorBrush(Colors.Transparent);

            if (SelectedClient == null || SelectedDT == null)
            {
                MB("Не выбрана запись!");
                return;
            }

            if (tb_diagnosis.Text.Length == 0)
            {
                tb_diagnosis.BorderBrush = new SolidColorBrush(Colors.Red);
                MB("Не заполнено поле диагноза!");
                return;
            }

            if (tb_details.Text.Length == 0)
            {
                tb_details.BorderBrush = new SolidColorBrush(Colors.Red);
                MB("Не заполнено поле описания!");
                return;
            }

            if (tb_curing.Text.Length == 0)
            {
                tb_diagnosis.BorderBrush = new SolidColorBrush(Colors.Red);
                MB("Не заполнено поле лечения!");
                return;
            }

            MB(ApplicationController.AddHistory(SelectedRegistryID, tb_diagnosis.Text, tb_details.Text, tb_curing.Text, SelectedAnalyzes));
            this.Close();
        }

        private void MB(string text)
        {
            MessageBox.Show(text, "Электронная регистратура", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MB(bool what)
        {
            if (what)
            {
                MessageBox.Show("Успешно добавлено в базу данных!", "Менджер базы данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Не удалось добавить в базу данных!", "Менеджер базы данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddAnalyzes_Click(object sender, RoutedEventArgs e)
        {
            SelectAnalyzes sa = new SelectAnalyzes(new Action<List<Analyse>>(CheckAnalyses), new List<Analyse>());
            sa.ShowDialog();
        }

        private void CheckAnalyses(List<Analyse> an)
        {
            SelectedAnalyzes = an;
            double sum = an.Sum((a) => { return a.Price; });

            Sum.Text = sum.ToString();
            Count.Text = an.Count.ToString();
        }
    }
}
