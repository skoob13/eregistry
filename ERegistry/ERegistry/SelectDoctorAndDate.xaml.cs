using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для SelectDoctorAndDate.xaml
    /// </summary>
    public partial class SelectDoctorAndDate : Window
    {
        private Action<DoctorWithSpec, DateTime> cb;
        private List<DoctorWithSpec> doctors;

        public SelectDoctorAndDate(Action<DoctorWithSpec, DateTime> callback)
        {
            InitializeComponent();
            doctors = FetchComboBox();
            Doctors.ItemsSource = doctors;
            cb = callback;
        }

        private List<DoctorWithSpec> FetchComboBox()
        {
            List<DoctorWithSpec> returningList = new List<DoctorWithSpec>();
            DataTable dt = ApplicationController.ExecuteQuery(SQLCommands.JoinDoctorsSpecAndDoctors);

            for (int i=0; i<dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                returningList.Add(new DoctorWithSpec(Convert.ToInt32(row.ItemArray[0].ToString()), row.ItemArray[1].ToString(), row.ItemArray[2].ToString(), row.ItemArray[3].ToString(), row.ItemArray[4].ToString()));
            }

            returningList.Sort();

            return returningList;
        }

        private void Find_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if no enter just return
            if (Doctors.SelectedItem == null)
            {
                return;
            }
            else if (Date.SelectedDate == null)
            {
                cb(doctors[Doctors.SelectedIndex], new DateTime());
            }
            else
            {
                cb(doctors[Doctors.SelectedIndex], (DateTime)Date.SelectedDate);
            }

            this.Close();
        }
    }
}
