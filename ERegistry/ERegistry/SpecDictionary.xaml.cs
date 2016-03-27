using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Логика взаимодействия для SpecDictionary.xaml
    /// </summary>
    public partial class SpecDictionary : Window
    {
        public SpecDictionary()
        {
            InitializeComponent();
            DataGridUpdate();
        }

        private void DataGridUpdate()
        {
            DataTable dt = ApplicationController.ExecuteQuery("SELECT * FROM spec");
            dt.Columns[0].ColumnName = "Номер";
            dt.Columns[1].ColumnName = "Название";
            Dic.ItemsSource = dt.DefaultView;
        }

        private void AddSource(object sender, RoutedEventArgs e)
        {
            ApplicationController.ShowAddToDB("Prof", new Action<bool>(ShowMB));
        }

        private void SetColumnSizes(object sender, EventArgs e)
        {
            Dic.Columns[0].Width = 50;
            Dic.Columns[1].Width = 430;
        }

        private void DGLoaded(object sender, RoutedEventArgs e)
        {
            Dic.Columns[0].Width = 50;
            Dic.Columns[1].Width = 430;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid));
            if (dpd != null)
            {
                dpd.AddValueChanged(Dic, SetColumnSizes);
            }
        }

        private void ShowMB(bool result)
        {
            if (result)
            {
                MessageBox.Show("Запись успешно добавлена!", "Добавить запись", MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridUpdate();
            }
            else
            {
                MessageBox.Show("Ошибка добавления записи!", "Добавить запись", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
