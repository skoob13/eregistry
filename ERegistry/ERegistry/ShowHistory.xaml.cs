using System;
using System.Collections.Generic;
using System.Windows;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для ShowHistory.xaml
    /// </summary>
    public partial class ShowHistory : Window
    {
        private HistoryEntity historyEntity;
        private List<Analyse> analyzes;

        public ShowHistory(HistoryEntity HE, bool isRedacting)
        {
            InitializeComponent();

            historyEntity = HE;
            tb_cname.Text = HE.Client;
            tb_dname.Text = HE.Doctor;
            tb_count.Text = HE.CountAnalyzes().ToString();
            tb_cost.Text = HE.CostAnalyzes().ToString();
            tb_curing.Text = HE.Curing;
            tb_details.Text = HE.Details;
            tb_diagnosis.Text = HE.Diagnosis;
            analyzes = new List<Analyse>(HE.Analyzes);
            DGAnalyzes.ItemsSource = analyzes;

            this.Title = "Запись №" + HE.ID.ToString() + " от " + HE.GetCorrectDate();

            if (!isRedacting)
            {
                tb_details.IsReadOnly = true;
                tb_diagnosis.IsReadOnly = true;
                tb_curing.IsReadOnly = true;
                SelectAnalyzes.Visibility = Visibility.Hidden;
                Save.Visibility = Visibility.Hidden;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectAnalyzes_Click(object sender, RoutedEventArgs e)
        {
            SelectAnalyzes sa = new SelectAnalyzes(new Action<List<Analyse>>(SetDG), analyzes);
            sa.ShowDialog();
        }

        private void SetDG(List<Analyse> an)
        {
            analyzes = an;
            DGAnalyzes.ItemsSource = an;
            DGAnalyzes.Items.Refresh();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (tb_details.Text != historyEntity.Details)
            {
                string cmd = "UPDATE history SET details='" + tb_details.Text + "' WHERE history_id=" + historyEntity.ID;
                ApplicationController.ExecuteCommand(cmd);
            }

            if (tb_details.Text != historyEntity.Curing)
            {
                string cmd = "UPDATE history SET curing='" + tb_curing.Text + "' WHERE history_id=" + historyEntity.ID;
                ApplicationController.ExecuteCommand(cmd);
            }

            if (tb_diagnosis.Text != historyEntity.Details)
            {
                string cmd = "UPDATE history SET diagnosis='" + tb_diagnosis.Text + "' WHERE history_id=" + historyEntity.ID;
                ApplicationController.ExecuteCommand(cmd);
            }

            AddAnalyzes();
            MessageBox.Show("Запись изменена!", "Электронная регистратура", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();

        }

        private void AddAnalyzes()
        {
            //True - not changed

            if (analyzes.Count == historyEntity.Analyzes.Count) return;

            for (int i=0; i<analyzes.Count; i++)
            {
                if (!CheckElement(analyzes[i]))
                {
                    ApplicationController.AddAnalyseToHistory(historyEntity.ID, analyzes[i].ID);
                }
            }
        }

        private bool CheckElement(Analyse a)
        {
            for (int j = 0; j < historyEntity.Analyzes.Count; j++)
            {
                if (a.ID == historyEntity.Analyzes[j].ID) return true;
            }
            return false;
        }

        private void DGAnalyzes_Loaded(object sender, RoutedEventArgs e)
        {
            if (DGAnalyzes.Columns.Count == 3)
            {
                DGAnalyzes.Columns[0].Header = "Номер анализа";
                DGAnalyzes.Columns[1].Header = "Название анализа";
                DGAnalyzes.Columns[2].Header = "Стоимость анализа";
            }
        }
    }
}
