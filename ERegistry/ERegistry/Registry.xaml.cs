using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ERegistry
{
    public partial class Registry : Page
    {
        string[] colors = { "ECCB68", "6ED6B6", "259B24", "E51C23", "6ED6B6", "489C5E", "FF4C4C", "FFEB3B", "673AB7", "CDDC39", "03A9F4", "FFC107", "FF9800", "00BCD4", "009688", "FF5722", "795548", "E91E63", "9C27B0", "607D8B", "212121" };
        Random rnd = new Random();

        private int doctor_id;
        private DoctorWithSpec SelectedDoctor;
        private DateTime SelectedDate;

        public Registry()
        {
            InitializeComponent();

            NO.Text = DateTime.Now.Day.ToString();
            Surname.Text = Utils.GetCorrectMonth(DateTime.Now.Month);
            dayOfWeek.Text = Utils.TrDW(DateTime.Now.DayOfWeek);

            bg.Background = new SolidColorBrush(Utils.ConvertStringToColor(colors[rnd.Next(0, colors.Length)]));
            Show25Top();
        }
 
        private Grid AddItem(string surname, string name, string otch, string time)
        {
            Grid main = new Grid();
            main.Width = 180;
            main.Height = 140;
            main.Margin = new Thickness(4);
            main.Background = new SolidColorBrush(Colors.White);

            DropShadowEffect de = new DropShadowEffect();
            de.BlurRadius = 10;
            de.Direction = -90;
            de.RenderingBias = RenderingBias.Quality;
            de.ShadowDepth = 1;
            de.Opacity = 0.3;
            main.Effect = de;

            main.RowDefinitions.Add(new RowDefinition());
            RowDefinition rd = new RowDefinition();
            rd.Height = new GridLength(40);
            main.RowDefinitions.Add(rd);

            Grid g1 = new Grid();
            g1.Background = new SolidColorBrush(Utils.ConvertStringToColor(colors[rnd.Next(0, colors.Length)]));
            g1.RowDefinitions.Add(new RowDefinition());
            g1.RowDefinitions.Add(new RowDefinition());
            g1.RowDefinitions.Add(new RowDefinition());

            TextBlock s = new TextBlock();
            s.Text = surname;
            s.Foreground = new SolidColorBrush(Colors.White);
            s.FontWeight = FontWeights.DemiBold;
            s.FontSize = 18;
            s.Margin = new Thickness(4);
            s.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(s, 0);

            TextBlock s1 = new TextBlock();
            s1.Text = name;
            s1.Foreground = new SolidColorBrush(Colors.White);
            s1.FontWeight = FontWeights.DemiBold;
            s1.FontSize = 18;
            s1.Margin = new Thickness(4);
            s1.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(s1, 1);

            TextBlock s2 = new TextBlock();
            s2.Text = otch;
            s2.Foreground = new SolidColorBrush(Colors.White);
            s2.FontWeight = FontWeights.DemiBold;
            s2.FontSize = 18;
            s2.Margin = new Thickness(4);
            s2.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(s2, 2);

            g1.Children.Add(s);
            g1.Children.Add(s1);
            g1.Children.Add(s2);

            Grid.SetRow(g1, 0);

            Grid g2 = new Grid();
            Grid.SetRow(g2, 1);

            TextBlock s3 = new TextBlock();
            s3.Text = time;
            s3.Foreground = new SolidColorBrush(Colors.Black);
            s3.FontWeight = FontWeights.Bold;
            s3.FontSize = 20;
            s3.Opacity = 0.9;
            s3.Margin = new Thickness(4);
            s3.VerticalAlignment = VerticalAlignment.Center;

            g2.Children.Add(s3);

            main.Children.Add(g1);
            main.Children.Add(g2);

            return main;
        }

        private void AddRegistry_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectDoctorAndDate s = new SelectDoctorAndDate(new Action<DoctorWithSpec, DateTime>(SetDataGrid));
            s.ShowDialog();
        }

        private void SetDataGrid(DoctorWithSpec doctor, DateTime date)
        {
            SelectedDoctor = doctor;
            SelectedDate = date;

            dayOfWeek.Text = doctor.Spec;
            NO.FontSize = 32;
            NO.Text = doctor.Name + " " + doctor.Otch;
            Surname.Text = doctor.Surname;
            Surname.FontSize = 36;

            doctor_id = doctor.ID;

            if (date == new DateTime())
            {
                Top25.Visibility = Visibility.Visible;
                Timetable.Visibility = Visibility.Hidden;

                Wrapper.Children.Clear();
                Future25ForDoctor(doctor);
            }
            else
            {
                Top25.Visibility = Visibility.Hidden;
                Timetable.Visibility = Visibility.Visible;

                Reg.Children.Clear();

                SetTimetable(doctor, date);
            }
        }

        private void Show25Top()
        {
            DataTable dt = ApplicationController.SelectTop25ByDate(DateTime.Now);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DoctorWithSpec doctor = new DoctorWithSpec();
                object[] itemArray = dt.Rows[i].ItemArray;
                doctor.ID = Convert.ToInt32(itemArray[2].ToString());
                
                Reg r = ParseReg(itemArray, doctor, (DateTime)itemArray[3]);
                string time =  Utils.GCTime(r.Time.Day) + "." + Utils.GCTime(r.Time.Month) + "." + r.Time.Year + " " + Utils.GCTime(r.Time.Hour) + ":" + Utils.GCTime(r.Time.Minute);

                Wrapper.Children.Add(AddItem(r.Client.Surname, r.Client.Name, r.Client.SecondName, time));
            }
        }

        private void Future25ForDoctor(DoctorWithSpec doctor)
        {
            DataTable dt = ApplicationController.SelectTop25ByDoctorAndDate(doctor.ID, DateTime.Now);

            for (int i=0; i<dt.Rows.Count; i++)
            {
                object[] itemArray = dt.Rows[i].ItemArray;
                doctor.ID = Convert.ToInt32(itemArray[2].ToString());

                Reg r = ParseReg(itemArray, doctor, (DateTime)itemArray[3]);
                string time = Utils.GCTime(r.Time.Day) + "." + Utils.GCTime(r.Time.Month) + "." + r.Time.Year + " " + Utils.GCTime(r.Time.Hour) + ":" + Utils.GCTime(r.Time.Minute);

                Wrapper.Children.Add(AddItem(r.Client.Surname, r.Client.Name, r.Client.SecondName, time));
            }
        }

        private void SetTimetable(DoctorWithSpec doctor, DateTime date)
        {
            Graph graph = ApplicationController.SelectGraphWithIdAndSpec(doctor.ID, doctor.Spec);

            int offset = date.DayOfWeek - DayOfWeek.Monday;
            if (offset == -1) offset = 6;

            DateTime nd = date;
            nd = nd.AddDays(-offset);

            if (CountMinutes(graph.PnStart, graph.PnEnd))
            {
                AddColumn(nd, FetchRegistry(graph.PnStart, graph.PnEnd, nd, graph.Interval, doctor));
            }
            else
            {
                AddEmptyColumn();
            }

            nd = nd.AddDays(1);

            if (CountMinutes(graph.VtStart, graph.VtEnd))
            {
                AddColumn(nd, FetchRegistry(graph.VtStart, graph.VtEnd, nd, graph.Interval, doctor));
            }
            else
            {
                AddEmptyColumn();
            }

            nd = nd.AddDays(1);

            if (CountMinutes(graph.SrStart, graph.SrEnd))
            {
                AddColumn(nd, FetchRegistry(graph.SrStart, graph.SrEnd, nd, graph.Interval, doctor));
            }
            else
            {
                AddEmptyColumn();
            }

            nd = nd.AddDays(1);

            if (CountMinutes(graph.ChStart, graph.ChEnd))
            {
                AddColumn(nd, FetchRegistry(graph.ChStart, graph.ChEnd, nd, graph.Interval, doctor));
            }
            else
            {
                AddEmptyColumn();
            }

            nd = nd.AddDays(1);

            if (CountMinutes(graph.PtStart, graph.PtEnd))
            {
                AddColumn(nd, FetchRegistry(graph.PtStart, graph.PtEnd, nd, graph.Interval, doctor));
            }
            else
            {
                AddEmptyColumn();
            }

            nd = nd.AddDays(1);

            if (CountMinutes(graph.SbStart, graph.SbEnd))
            {
                AddColumn(nd, FetchRegistry(graph.SbStart, graph.SbEnd, nd, graph.Interval, doctor));
            }
            else
            {
                AddEmptyColumn();
            }

            nd = nd.AddDays(1);

            if (CountMinutes(graph.VsStart, graph.VsEnd))
            {
                AddColumn(nd, FetchRegistry(graph.VsStart, graph.VsEnd, nd, graph.Interval, doctor));
            }
            else
            {
                AddEmptyColumn();
            }
        }

        private List<Day> FetchRegistry(DateTime start, DateTime end, DateTime day, int interval, DoctorWithSpec doctor)
        {
            List<Day> days = new List<Day>();
            for (DateTime i=start; i < end; i=i.AddMinutes(interval))
            {
                DateTime nd = new DateTime(day.Year, day.Month, day.Day, i.Hour, i.Minute, i.Second);
                DataTable dt = ApplicationController.SelectRegistryEntry(doctor_id, nd);

                Day newDay = new Day();
                newDay.Time = Utils.GCTime(i.Hour) + ":" + Utils.GCTime(i.Minute);

                if (dt.Rows.Count > 0)
                {
                    object[] itemArray = dt.Rows[0].ItemArray;
                    newDay.Reg = ParseReg(itemArray, doctor, nd);
                }
                else
                {
                    newDay.Reg = new Reg();
                    newDay.Reg.Doctor = doctor;
                    newDay.Reg.Time = nd;
                }

                days.Add(newDay);
            }

            return days;
        }

        private Reg ParseReg(object[] itemArray, DoctorWithSpec doctor, DateTime actualDate)
        {
            Reg r = new Reg();

            object[] clientSubArray = new object[9];
            object[] serviceSubArray = new object[3];

            Array.Copy(itemArray, 7, clientSubArray, 0, 9);
            Array.Copy(itemArray, 16, serviceSubArray, 0, 3);

            r.ID = Convert.ToInt32(itemArray[0].ToString());
            Client c = ApplicationController.ParseClient(clientSubArray);
            Service s = ApplicationController.ParseService(serviceSubArray);

            r.Client = c;
            r.Doctor = doctor;
            r.Service = s;
            r.PushUpdate = Convert.ToBoolean(itemArray[5]);
            r.Paid = Convert.ToBoolean(itemArray[6]);
            r.Time = actualDate;

            return r;
        }

        private bool CountMinutes(DateTime start, DateTime end)
        {
            return (end.Hour * 60 + end.Minute) - (start.Hour * 60 + start.Minute) > 0;
        }
        
        private void AddEmptyColumn()
        {
            Grid main = new Grid();
            main.Width = 130;

            Reg.Children.Add(main);
        } 

        private void AddColumn(DateTime time, List<Day> timetable)
        {
            //Set main grid
            Grid main = new Grid();
            main.Width = 140;
            main.Height = 490;
            main.Margin = new Thickness(4);

            //Shadow
            DropShadowEffect de = new DropShadowEffect();
            de.BlurRadius = 10;
            de.Direction = -90;
            de.RenderingBias = RenderingBias.Quality;
            de.ShadowDepth = 5;
            de.Opacity = 0.3;
            main.Effect = de;

            RowDefinition rd = new RowDefinition();
            rd.Height = new GridLength(40);
            RowDefinition rd1 = new RowDefinition();
            rd1.Height = new GridLength(1, GridUnitType.Star);
            main.RowDefinitions.Add(rd);
            main.RowDefinitions.Add(rd1);

            //set header
            Grid header = new Grid();
            header.RowDefinitions.Add(new RowDefinition());
            header.RowDefinitions.Add(new RowDefinition());
            header.Background = new SolidColorBrush(Utils.ConvertStringToColor(colors[rnd.Next(0,colors.Length)]));

            //create tbs
            TextBlock tb1 = new TextBlock();
            TextBlock tb2 = new TextBlock();
            tb1.Foreground = new SolidColorBrush(Colors.White);
            tb2.Foreground = new SolidColorBrush(Colors.White);
            tb1.FontWeight = FontWeights.Bold;
            tb2.FontWeight = FontWeights.Bold;
            tb1.Text = Utils.GCTime(time.Day) + " " + Utils.GetCorrectMonth(time.Month) + " " + time.Year;
            tb2.Text = Utils.TrDW(time.DayOfWeek);

            tb1.HorizontalAlignment = HorizontalAlignment.Center;
            tb2.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(tb1, 0);
            Grid.SetRow(tb2, 1);
            header.Children.Add(tb1);
            header.Children.Add(tb2);

            //create context menu
            ContextMenu cm = new ContextMenu();

            MenuItem red = new MenuItem();
            red.Header = "Редактировать";
            red.Click += new RoutedEventHandler(RedactingRegistry);

            MenuItem delete = new MenuItem();
            delete.Header = "Удалить";
            delete.Click += new RoutedEventHandler(DeleteRegistry);

            cm.Items.Add(red);
            cm.Items.Add(delete);

            //create datagrid
            DataGrid dg = new DataGrid();
            Grid.SetRow(dg, 1);
            dg.AutoGenerateColumns = true;
            dg.CellStyle = App.Current.Resources["CellStyle"] as Style;
            dg.CanUserAddRows = false;
            dg.CanUserDeleteRows = false;
            dg.CanUserReorderColumns = false;
            dg.IsReadOnly = true;
            dg.ItemsSource = timetable;
            dg.GridLinesVisibility = DataGridGridLinesVisibility.None;
            dg.HeadersVisibility = DataGridHeadersVisibility.None;
            dg.Loaded += new RoutedEventHandler(DGLoaded);
            dg.BorderThickness = new Thickness(0);
            dg.MouseDoubleClick += new MouseButtonEventHandler(DGDoubleClick);
            dg.ContextMenu = cm;

            main.Children.Add(header);
            main.Children.Add(dg);

            Reg.Children.Add(main);
        }

        private void DGLoaded(object sender, RoutedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            dg.Columns[0].Width = 35;
            dg.Columns[1].Width = 105;
        }

        //Открыть форму для создания записи
        private void DGDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DateTime nd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime dt = (dg.SelectedItem as Day).Reg.Time;

            if ((dg.SelectedItem as Day).Reg.ToString() == "  ")
            {
                if (nd.CompareTo(dt) != -1) return;
                AddRegistry ar = new AddRegistry(new Action<bool>(MB), (dg.SelectedItem as Day).Reg, bg.Background);
                ar.ShowDialog();

                SetDataGrid(SelectedDoctor, SelectedDate);
            }
            else
            {
                EditRegistry er = new EditRegistry((dg.SelectedItem as Day).Reg, bg.Background);
                er.ShowDialog();
            }
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

        private void RedactingRegistry(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            DateTime nd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime dt = (item.SelectedItem as Day).Reg.Time;

            if (nd.CompareTo(dt) != -1) return;

            if ((item.SelectedItem as Day).Reg.ToString() != "  ")
            {
                EditRegistry er = new EditRegistry((item.SelectedItem as Day).Reg, bg.Background);
                er.ShowDialog();
            }
            else
            {
                DGDoubleClick(item, e as MouseButtonEventArgs);
            }
        }

        private void DeleteRegistry(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            var reg = (item.SelectedItem as Day).Reg;

            if (reg.ToString() != "  ")
            {
                var result =  MessageBox.Show(String.Format("Вы действительно хотите удалить запись клиента {0}?", reg.ToString()), "Удалить запись", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MB(ApplicationController.DeleteRegistry(reg.ID));
                        break;
                }
            }
        }
    }
}
