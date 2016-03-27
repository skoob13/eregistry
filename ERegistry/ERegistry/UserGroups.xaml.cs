using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для UserGroups.xaml
    /// </summary>
    public partial class UserGroups : Page
    {
        private int Tab;

        public UserGroups()
        {
            Tab = 0;
            InitializeComponent();
            InitClientsDataGrid();
        }

        private void InitClientsDataGrid()
        {
            Shower.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectClients).DefaultView;
        }

        private void InitDoctorsDataGrid()
        {
            Shower.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectEmployees).DefaultView;
        }

        private void InitServiceDataGrid()
        {
            Shower.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectServices).DefaultView;
        }

        private void InitGraphsDataGrid()
        {
            Shower.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectGraphs).DefaultView;
        }

        private void InitAnalysiesDataGrid()
        {
            Shower.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectAnalysies).DefaultView;
        }

        private void MB(bool what)
        {
            ToggleTab(Tab);
            if (what)
            {
                MessageBox.Show("Успешно добавлено в базу данных!", "Менджер базы данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Не удалось добавить в базу данных!", "Менеджер базы данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ToggleTab(int tab)
        {
            UntoggleTab(Tab);
            Tab = tab;

            switch (tab)
            {
                //Clients
                case 0:
                    c_p.Mask = "00 00 000 000";
                    Tb_p.Text = "Паспорт:";
                    ClTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("19191F"));
                    ClRect.Visibility = Visibility.Visible;
                    ClientPanel.Visibility = Visibility.Visible;
                    AdressTB.Text = "Домашний адрес:";
                    //Graph.Visibility = Visibility.Hidden;
                    InitClientsDataGrid();
                    break;

                //Employees
                case 1:
                    c_p.Mask = "";
                    Tb_p.Text = "Номер:";
                    EmTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("19191F"));
                    EmRect.Visibility = Visibility.Visible;
                    ClientPanel.Visibility = Visibility.Visible;
                    AdressTB.Text = "Адрес рассылки:";
                    //Graph.Visibility = Visibility.Visible;
                    InitDoctorsDataGrid();
                    break;

                //Services
                case 2:
                    SeTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("19191F"));
                    SeRect.Visibility = Visibility.Visible;
                    ServicesPanel.Visibility = Visibility.Visible;
                    //Graph.Visibility = Visibility.Hidden;
                    InitServiceDataGrid();
                    break;

                //Professions
                case 3:
                    PrTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("19191F"));
                    PrRect.Visibility = Visibility.Visible;
                    ProfPanel.Visibility = Visibility.Visible;
                    //Graph.Visibility = Visibility.Hidden;
                    InitGraphsDataGrid();
                    break;

                //Analyses
                case 4:
                    AnTB.Foreground = new SolidColorBrush(Utils.ConvertStringToColor("19191F"));
                    AnRect.Visibility = Visibility.Visible;
                    AnalysesPanel.Visibility = Visibility.Visible;
                    //Graph.Visibility = Visibility.Hidden;
                    InitAnalysiesDataGrid();
                    break;
            }
        }

        private void UntoggleTab(int tab)
        {
            switch (tab)
            {
                //Clients
                case 0:
                    ClTB.Foreground = new SolidColorBrush(Colors.White);
                    ClRect.Visibility = Visibility.Hidden;
                    ClientPanel.Visibility = Visibility.Hidden;
                    break;

                //Employees
                case 1:
                    EmTB.Foreground = new SolidColorBrush(Colors.White);
                    EmRect.Visibility = Visibility.Hidden;
                    ClientPanel.Visibility = Visibility.Hidden;
                    break;

                //Services
                case 2:
                    SeTB.Foreground = new SolidColorBrush(Colors.White);
                    SeRect.Visibility = Visibility.Hidden;
                    ServicesPanel.Visibility = Visibility.Hidden;
                    break;

                //Professions
                case 3:
                    PrTB.Foreground = new SolidColorBrush(Colors.White);
                    PrRect.Visibility = Visibility.Hidden;
                    ProfPanel.Visibility = Visibility.Hidden;
                    break;

                //Analyses
                case 4:
                    AnTB.Foreground = new SolidColorBrush(Colors.White);
                    AnRect.Visibility = Visibility.Hidden;
                    AnalysesPanel.Visibility = Visibility.Hidden;
                    break;
            }
        }

        //Clients
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToggleTab(0);
        }

        //Empoyees
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ToggleTab(1);
        }

        //Services
        private void Grid_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            ToggleTab(2);
        }

        //Professions
        private void Grid_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            ToggleTab(3);
        }

        //Analyses
        private void Grid_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            ToggleTab(4);
        }

        private void AddButton(object sender, MouseButtonEventArgs e)
        {
            switch (Tab)
            {
                case 0:
                    ApplicationController.ShowAddToDB("Client", new Action<bool>(MB));
                    break;
                case 1:
                    ApplicationController.ShowAddToDB("Emp", new Action<bool>(MB));
                    break;
                case 2:
                    ApplicationController.ShowAddToDB("Service", new Action<bool>(MB));
                    break;
                case 3:
                    ApplicationController.ShowAddGraph(new Action<bool>(MB));
                    break;
                case 4:
                    ApplicationController.ShowAddToDB("Analyse", new Action<bool>(MB));
                    break;
                default:
                    break;
            }
        }

        private void OpenDictionarySpecializations(object sender, RoutedEventArgs e)
        {
            ApplicationController.ShowSpecializationsDictionary();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToggleTab(Tab);
            c_a.Text = "";
            c_b.Text = "";
            c_g.Text = "";
            c_n.Text = "";
            c_o.Text = "";
            c_p.Text = "";
            c_ph.Text = "";
            c_s.Text = "";
        }

        private void FindClient_Click(object sender, RoutedEventArgs e)
        {
            if (c_a.Text.Length == 0 && c_b.SelectedDate == null && c_g.SelectedItem == null &&
                c_n.Text.Length == 0 && c_o.Text.Length == 0 && c_p.Text.Length == 0 && c_ph.Text.Length == 0 &&
                c_s.Text.Length == 0)
                return;

            bool flag = false;
            string cmd;

            if (Tab == 0)
                cmd = SQLCommands.SelectClients + " WHERE ";
            else cmd = SQLCommands.SelectEmployees + " WHERE ";

            if (c_p.Text.Length > 0)
            {
                if (Tab == 0)
                {
                    cmd += And(flag) + "passport LIKE '%" + c_p.Text + "%'";
                    flag = true;
                }
                else
                {
                    cmd += And(flag) + "doctor_id=" + c_p.Text;
                    flag = true;
                }
            }

            if (c_s.Text.Length > 0)
            {
                cmd += And(flag) + "surname LIKE '%" + c_s.Text + "%'";
                flag = true;
            }

            if (c_n.Text.Length > 0)
            {
                cmd += And(flag) + "name LIKE '%" + c_n.Text + "%'";
                flag = true;
            }

            if (c_o.Text.Length > 0)
            {
                cmd += And(flag) + "otch LIKE '%" + c_o.Text + "%'";
                flag = true;
            }

            if (c_b.SelectedDate != null)
            {
                cmd += And(flag) + "birth='" + ApplicationController.GetCorrectDate((DateTime)c_b.SelectedDate) + "'";
                flag = true;
            }

            if (c_g.SelectedItem != null)
            {
                cmd += And(flag) + "gender LIKE '%" + (c_g.SelectedItem as ComboBoxItem).Content.ToString() + "%'";
                flag = true;
            }

            if (c_ph.Text.Length > 0)
            {
                cmd += And(flag) + "phone LIKE '%" + c_ph.Text + "%'";
                flag = true;
            }

            if (c_a.Text.Length > 0)
            {
                cmd += And(flag) + "address LIKE '%" + c_a.Text + "%'";
            }


            Shower.ItemsSource = ApplicationController.ExecuteQuery(cmd).DefaultView;
        }

        private static string And(bool b)
        {
            if (b) return " AND ";
            else return "";
        }

        private void OnlyDigitsEnter(object sender, TextChangedEventArgs e)
        {
            string n = "";
            TextBox tb = sender as TextBox;

            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (Char.IsDigit(tb.Text[i]))
                {
                    n += tb.Text[i];
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            tb.Text = n;
        }

        private void c_p_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tab != 1) return;

            string n = "";
            TextBox tb = sender as TextBox;

            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (Char.IsDigit(tb.Text[i]))
                {
                    n += tb.Text[i];
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            tb.Text = n;
        }

        private void s_flush_Click(object sender, RoutedEventArgs e)
        {
            ToggleTab(Tab);
            s_cost.Text = "";
            s_num.Text = "";
        }

        private void s_find_Click(object sender, RoutedEventArgs e)
        {
            if (s_num.Text.Length == 0 && s_cost.Text.Length == 0)
                return;

            bool flag = false;
            string cmd = SQLCommands.SelectServices + " WHERE ";

            if (s_num.Text.Length > 0)
            {
                cmd += And(flag) + "name LIKE '%" + s_num.Text + "%'";
                flag = true;
            }

            if (s_cost.Text.Length > 0)
            {
                cmd += And(flag) + "cost=" + s_cost.Text;
                flag = true;
            }

            Shower.ItemsSource = ApplicationController.ExecuteQuery(cmd).DefaultView;
        }

        private void ds_flush_Click(object sender, RoutedEventArgs e)
        {
            ToggleTab(Tab);
            ds_name.Text = "";
            ds_num.Text = "";
            ds_ot.Text = "";
            ds_spec.Text = "";
            ds_sur.Text = "";
        }

        private void ds_find_Click(object sender, RoutedEventArgs e)
        {
            if (ds_sur.Text.Length == 0 && ds_spec.Text.Length ==0 && ds_ot.Text.Length == 0 &&
                ds_num.Text.Length == 0 && ds_name.Text.Length == 0)
                return;

            bool flag = false;
            string cmd = SQLCommands.SelectServices;

            //not ready yet TODO

            //if (s_num.Text.Length > 0)
            //{
            //    cmd += And(flag) + "name LIKE '%" + s_num.Text + "%'";
            //    flag = true;
            //}

            //if (s_cost.Text.Length > 0)
            //{
            //    cmd += And(flag) + "cost=" + s_cost.Text;
            //    flag = true;
            //}

            //Shower.ItemsSource = ApplicationController.ExecuteQuery(cmd).DefaultView;
        }

        private void a_flush_Click(object sender, RoutedEventArgs e)
        {
            ToggleTab(Tab);
            a_cost.Text = "";
            a_name.Text = "";
        }

        private void a_find_Click(object sender, RoutedEventArgs e)
        {
            if (a_name.Text.Length == 0 && a_cost.Text.Length == 0)
                return;

            bool flag = false;
            string cmd = SQLCommands.SelectAnalysies + " WHERE ";

            if (a_name.Text.Length > 0)
            {
                cmd += And(flag) + "name LIKE '%" + a_name.Text + "%'";
                flag = true;
            }

            if (a_cost.Text.Length > 0)
            {
                cmd += And(flag) + "cost=" + a_cost.Text;
                flag = true;
            }

            Shower.ItemsSource = ApplicationController.ExecuteQuery(cmd).DefaultView;
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (Shower.SelectedItem != null)
            {
                object[] drw = (Shower.SelectedItem as DataRowView).Row.ItemArray;
                Action<bool> cb = new Action<bool>(MB);
                AddToDB ad;

                switch (Tab)
                {
                    case 0:
                        ad = new AddToDB("Client", ApplicationController.ParseClient(drw), cb);
                        ad.ShowDialog();
                        break;
                    case 1:
                        ad = new AddToDB("Emp", ApplicationController.ParseEmployee(drw), cb);
                        ad.ShowDialog();
                        break;
                    case 2:
                        ad = new AddToDB("Service", ApplicationController.ParseService(drw), cb);
                        ad.ShowDialog();
                        break;
                    case 3:
                        DoctorsSpec d = new DoctorsSpec(Convert.ToInt32(drw[0]), Convert.ToInt32(drw[1]), Convert.ToInt32(drw[2]), Utils.XMLToObject<Graph>(drw[3].ToString()));
                        ad = new AddToDB("Graph", d, cb);
                        ad.ShowDialog();
                        break;
                    case 4:
                        ad = new AddToDB("Analyse", ApplicationController.ParseAnalyse(drw), cb);
                        ad.ShowDialog();
                        break;
                }
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            if (Shower.SelectedItem != null)
            {
                object[] drw = (Shower.SelectedItem as DataRowView).Row.ItemArray;
                Action<bool> cb = new Action<bool>(MB);

                var result = MessageBox.Show("Удалить из базы данных?", "Электронная регистратура", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;

                switch (Tab)
                {
                    case 0:
                        ApplicationController.DeleteClient(Convert.ToInt32(drw[0].ToString()));
                        break;
                    case 1:
                        ApplicationController.DeleteEmployee(Convert.ToInt32(drw[0].ToString()));
                        break;
                    case 2:
                        ApplicationController.DeleteService(Convert.ToInt32(drw[0].ToString()));
                        break;
                    case 3:
                        ApplicationController.DeleteGraph(Convert.ToInt32(drw[0].ToString()));
                        break;
                    case 4:
                        ApplicationController.DeleteAnalyse(Convert.ToInt32(drw[0].ToString()));
                        break;
                }
            }
        }
    }
}
