using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SelectAnalyzes.xaml
    /// </summary>
    public partial class SelectAnalyzes : Window
    {
        private List<Analyse> an;
        private Action<List<Analyse>> cb;

        public SelectAnalyzes(Action<List<Analyse>> callback, List<Analyse> analyzes)
        {
            InitializeComponent();
            All.ItemsSource = ApplicationController.ExecuteQuery(SQLCommands.SelectAnalysies).DefaultView;
            if (analyzes != null) an = analyzes;
            else an = new List<Analyse>();
            Count.Text = an.Count.ToString();
            cb = callback;
            Selected.ItemsSource = an;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (All.SelectedItem != null)
            {
                Analyse s = ApplicationController.ParseAnalyse((All.SelectedItem as DataRowView).Row.ItemArray);
                if (CheckAnalyse(s))
                {
                    an.Add(s);
                    Selected.ItemsSource = an;
                    Selected.Items.Refresh();
                    Count.Text = an.Count.ToString();
                }
            }
        }

        private bool CheckAnalyse(Analyse s)
        {
            for (int i=0; i<an.Count; i++)
            {
                if (an[i].ID == s.ID) return false;
            }
            return true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            cb(an);
            this.Close();
        }
    }
}
