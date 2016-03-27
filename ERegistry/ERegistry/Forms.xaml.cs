using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting.Primitives;
using System.Windows.Media;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для Forms.xaml
    /// </summary>
    public partial class Forms : Page
    {
        private DataTable TableToPrint;

        public Forms()
        {
            InitializeComponent();

            MoneyAmount.Text = ApplicationController.SelectTopMoneyByYesterday().ToString()+ "₽";
            DateTime nd = DateTime.Now;
            nd = nd.AddDays(-1);
            Date.Text = "за " + Utils.GCTime(nd.Day) + " " + Utils.GetCorrectMonth(nd.Month) + " " + nd.Year;

            SetTop5Services();
            SetTop10Doctors();
            SetMonths();

            Doctors.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectDoctorsSpecAndSpecWithIdFromDoctorSpec).DefaultView;
        }

        private void SetTop5Services()
        {
            List<KeyValuePair<string, double>> MyValue = new List<KeyValuePair<string, double>>();

            DataTable dt = ApplicationController.ExecuteQuery(SQLCommands.SelectTop5SumServices);

            for (int i=0; i<dt.Rows.Count; i++)
            {
                object[] obj = dt.Rows[i].ItemArray;

                double sum = Convert.ToDouble(obj[3].ToString());
                string name = obj[1].ToString();
                MyValue.Add(new KeyValuePair<string, double>(name, sum));
            }

            Top5Services.DataContext = MyValue;
        }

        private void SetTop10Doctors()
        {
            List<KeyValuePair<string, double>> MyValue = new List<KeyValuePair<string, double>>();

            DataTable dt = ApplicationController.ExecuteQuery(SQLCommands.SelectTop10Doctors);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object[] obj = dt.Rows[i].ItemArray;

                double sum = Convert.ToDouble(obj[3].ToString());
                string name = obj[0].ToString() + " " + obj[1].ToString() + " " + obj[2].ToString();
                MyValue.Add(new KeyValuePair<string, double>(name, sum));
            }

            Top10Doctors.DataContext = MyValue;
        }

        private void SetMonths()
        {
            List<KeyValuePair<string, double>> MyValue = new List<KeyValuePair<string, double>>();

            DataTable dt = ApplicationController.ExecuteQuery(SQLCommands.SelectMoneyByMonths);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object[] obj = dt.Rows[i].ItemArray;

                double sum = Convert.ToDouble(obj[1].ToString());
                string name = Utils.GetCorrectMonthIm(((DateTime)obj[0]).Month);
                MyValue.Add(new KeyValuePair<string, double>(name, sum));
            }

            ByMonths.DataContext = MyValue;
        }

        private void Top5Services_Loaded(object sender, RoutedEventArgs e)
        {
            EdgePanel ep = Utils.FindChild<EdgePanel>(sender as Chart, "ChartArea");
            if (ep != null)
            {
                var grid = ep.Children.OfType<Grid>().FirstOrDefault();
                if (grid != null)
                {
                    grid.Background = new SolidColorBrush(Colors.Transparent);
                }

                var border = ep.Children.OfType<Border>().FirstOrDefault();
                if (border != null)
                {
                    border.BorderBrush = new SolidColorBrush(Colors.Transparent);
                }
            }

            Legend legend = Utils.FindChild<Legend>(sender as Chart, "Legend");
            if (legend != null)
            {
                legend.Background = new SolidColorBrush(Colors.Transparent);
                legend.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Doctors.SelectedItem != null)
            {
                DataTable table = ApplicationController.SelectDoctorsList(Convert.ToInt32((Doctors.SelectedItem as DataRowView).Row.ItemArray[0].ToString()));
                List.ItemsSource = table.DefaultView;

                TableToPrint = table;

                if (table.Rows.Count > 0) PrintList.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_name.Text = "";
            tb_otch.Text = "";
            tb_spec.Text = "";
            tb_surname.Text = "";
            Doctors.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectDoctorsSpecAndSpecWithIdFromDoctorSpec).DefaultView;
            List.ItemsSource = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ZDate.SelectedDate != null)
            {
                DataTable table = ApplicationController.SelectZReport((DateTime)ZDate.SelectedDate);
                ZList.ItemsSource = table.DefaultView;
                TableToPrint = table;

                if (table.Rows.Count > 0) ZlistPrint.IsEnabled = true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (tb_name.Text.Length == 0 && tb_otch.Text.Length == 0 && tb_spec.Text.Length == 0
                && tb_surname.Text.Length == 0)
                return;

            bool flag = false;
            string cmd = SQLCommands.SelectDoctorsSpecAndSpecWithIdFromDoctorSpec + " WHERE ";

            if (tb_name.Text.Length > 0)
            {
                cmd += And(flag) + "doctors.name LIKE '%" + tb_name.Text + "%'";
                flag = true;
            }

            if (tb_otch.Text.Length > 0)
            {
                cmd += And(flag) + "doctors.otch LIKE '%" + tb_otch.Text + "%'";
                flag = true;
            }

            if (tb_spec.Text.Length > 0)
            {
                cmd += And(flag) + "spec.name LIKE '%" + tb_spec.Text + "%'";
                flag = true;
            }

            if (tb_surname.Text.Length > 0)
            {
                cmd += And(flag) + "doctors.surname LIKE '%" + tb_surname.Text + "%'";
                flag = true;
            }

            Doctors.ItemsSource = ApplicationController.ExecuteQuery(cmd).DefaultView;
        }

        private static string And(bool b)
        {
            if (b) return " AND ";
            else return "";
        }

        private void PrintList_Click(object sender, RoutedEventArgs e)
        {
            string name = (Doctors.SelectedItem as DataRowView).Row.ItemArray[1].ToString() + " " + (Doctors.SelectedItem as DataRowView).Row.ItemArray[2].ToString() + " " + (Doctors.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
            string file = Reports.CreateList(TableToPrint, DateTime.Now, name);

            Process.Start(file);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string file = Reports.CreateZList(TableToPrint, DateTime.Now);

            Process.Start(file);
        }
    }
}
