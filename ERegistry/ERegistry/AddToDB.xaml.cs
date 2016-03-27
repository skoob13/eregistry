using System;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace ERegistry
{
    /// <summary>
    /// Логика взаимодействия для AddToDB.xaml
    /// </summary>
    public partial class AddToDB : Window
    {
        //form type
        private string type;
        private Action<bool> cb;
        private object Setter;
  
        public Graph CreatedGraph
        {
            get;
            set;
        }
        public AddToDB(string Type, Action<bool> callback)
        {
            InitializeComponent();
            type = Type;
            setStyle(type);
            cb = callback;
            CreatedGraph = null;
        }

        public AddToDB(string Type, object obj, Action<bool> callback)
        {
            InitializeComponent();
            type = Type;
            setStyle(type, obj);
            cb = callback;
            CreatedGraph = null;
            Setter = obj;
        }

        private void setStyle(string Type)
        {
            switch (Type)
            {
                case "Client":
                    this.Title = "Добавить клиента";
                    Label.Text = "Добавить клиента";
                    Client_style.Visibility = Visibility.Visible;
                    break;
                case "Emp":
                    this.Title = "Добавить сотрудника";
                    Label.Text = "Добавить сотрудника";
                    Employee_style.Visibility = Visibility.Visible;
                    break;
                case "Service":
                    this.Title = "Добавить услугу";
                    Label.Text = "Добавить услугу";
                    Service_analyse_style.Visibility = Visibility.Visible;
                    break;
                case "Analyse":
                    this.Title = "Добавить анализ";
                    Label.Text = "Добавить анализ";
                    Service_analyse_style.Visibility = Visibility.Visible;
                    break;
                case "Prof":
                    this.Title = "Добавить специальность";
                    Label.Text = "Добавить специальность";
                    Prof_style.Visibility = Visibility.Visible;
                    break;
                case "Graph":
                    this.Title = "Создать график";
                    Label.Text = "Создать график";
                    Graph_style.Visibility = Visibility.Visible;
                    break;
                default:
                    MessageBox.Show("Форма не будет инициализирована.", "Ошибка формы", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void setStyle(string Type, object obj)
        {
            switch (Type)
            {
                case "Client":
                    this.Title = "Изменить клиента";
                    Label.Text = "Изменить клиента";
                    Add_button.Content = "Изменить";
                    SetClient(obj);
                    Client_style.Visibility = Visibility.Visible;
                    break;
                case "Emp":
                    this.Title = "Изменить сотрудника";
                    Label.Text = "Изменить сотрудника";
                    Add_button.Content = "Изменить";
                    Employee_style.Visibility = Visibility.Visible;
                    SetDoctor(obj);
                    break;
                case "Service":
                    this.Title = "Изменить услугу";
                    Label.Text = "Изменить услугу";
                    Add_button.Content = "Изменить";
                    Service_analyse_style.Visibility = Visibility.Visible;
                    SetService(obj);
                    break;
                case "Analyse":
                    this.Title = "Изменить анализ";
                    Label.Text = "Изменить анализ";
                    Add_button.Content = "Изменить";
                    Service_analyse_style.Visibility = Visibility.Visible;
                    SetAnalyse(obj);
                    break;
                case "Prof":
                    this.Title = "Изменить специальность";
                    Label.Text = "Изменить специальность";
                    Add_button.Content = "Изменить";
                    Prof_style.Visibility = Visibility.Visible;
                    SetProf(obj);
                    break;
                case "Graph":
                    this.Title = "Изменить график";
                    Label.Text = "Изменить график";
                    Add_button.Content = "Изменить";
                    Graph_style.Visibility = Visibility.Visible;
                    SetGraph(obj);
                    break;
                default:
                    break;
            }
        }

        private void SetClient(object obj)
        {
            Client c = obj as Client;
            cs_adress.Text = c.Adress;
            cs_birthday.SelectedDate = c.Birthdate;
            cs_gender.SelectedIndex = c.Gender == "Мужской" ? 1 : 0;
            cs_name.Text = c.Name;
            cs_otch.Text = c.SecondName;
            cs_pas.Text = c.Passport;
            cs_phone.Text = c.Phone;
            cs_sur.Text = c.Surname;
        }

        private void SetDoctor(object obj)
        {
            Employee e = obj as Employee;
            es_ad.Text = e.Adress;
            es_birth.SelectedDate = e.Birthdate;
            es_gender.SelectedIndex = e.Gender == "Мужской" ? 1 : 0;
            es_name.Text = e.Name;
            es_otch.Text = e.SecondName;
            es_phone.Text = e.Phone;
            es_sur.Text = e.Surname;
        }

        private void SetService(object obj)
        {
            Service s = obj as Service;

            ss_cost.Text = s.Price.ToString();
            ss_name.Text = s.Title;
        }

        private void SetAnalyse(object obj)
        {
            Analyse s = obj as Analyse;

            ss_cost.Text = s.Price.ToString();
            ss_name.Text = s.Title;
        }

        private void SetProf(object obj)
        {
            Specialization s = obj as Specialization;

            Prof_tb.Text = s.Title;
        }

        private void SetGraph(object obj)
        {
            DateTime nd = new DateTime();

            DoctorsSpec d = obj as DoctorsSpec;
            Graph g = d.Graph;

            if (g.Interval == 15) Interval.SelectedIndex = 0;
            else if (g.Interval == 30) Interval.SelectedIndex = 1;
            else Interval.SelectedIndex = 2;

            if (g.PnStart != nd)
            {
                pn.IsChecked = true;
                pntp.IsEnabled = true;
                pttpe.IsEnabled = true;
                pntp.Value = g.PnStart;
                pntpe.Value = g.PnEnd;

            }

            if (g.VtStart != nd)
            {
                vt.IsChecked = true;
                vttp.IsEnabled = true;
                vttpe.IsEnabled = true;
                vttp.Value = g.VtStart;
                vttpe.Value = g.VtEnd;
            }

            if (g.SrStart != nd)
            {
                sr.IsChecked = true;
                srtp.IsEnabled = true;
                srtpe.IsEnabled = true;
                srtp.Value = g.SrStart;
                srtpe.Value = g.SrEnd;
            }

            if (g.ChStart != nd)
            {
                ch.IsChecked = true;
                chtp.IsEnabled = true;
                chtpe.IsEnabled = true;
                chtp.Value = g.ChStart;
                chtpe.Value = g.ChEnd;
            }

            if (g.PtStart != nd)
            {
                pt.IsChecked = true;
                pttp.IsEnabled = true;
                pttpe.IsEnabled = true;
                pttp.Value = g.PtStart;
                pttpe.Value = g.PtEnd;
            }

            if (g.SbStart != nd)
            {
                sb.IsChecked = true;
                sbtp.IsEnabled = true;
                sbtpe.IsEnabled = true;
                sbtp.Value = g.SbStart;
                sbtpe.Value = g.SbEnd;
            }

            if (g.VsStart != nd)
            {
                vs.IsChecked = true;
                vstp.IsEnabled = true;
                vstpe.IsEnabled = true;
                vstp.Value = g.VsStart;
                vstpe.Value = g.VsEnd;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (Setter == null) AddWithoutSetter(sender, e);
            else
            {
                AddWithSetter(sender, e);
            }
        }

        private void AddWithoutSetter(object sender, RoutedEventArgs e)
        {
            switch (type)
            {
                case "Client":
                    AddClient();
                    break;
                case "Emp":
                    AddEmployee();
                    break;
                case "Service":
                    AddService();
                    break;
                case "Analyse":
                    AddAnalyse();
                    break;
                case "Prof":
                    if (Prof_tb.Text.Length > 0)
                    {
                        Specialization s = new Specialization(Prof_tb.Text);
                        cb(ApplicationController.AddSpecialization(s));
                        this.Close();
                    }
                    break;
                case "Graph":
                    AddGraph();
                    break;
            }
        }

        //Function for editing previos object
        private void AddWithSetter(object sender, RoutedEventArgs e)
        {
            switch (type)
            {
                case "Client":
                    EditClient();
                    break;
                case "Emp":
                    EditEmployee();
                    break;
                case "Service":
                    EditService();
                    break;
                case "Analyse":
                    EditAnalyse();
                    break;
                case "Prof":
                    if (Prof_tb.Text.Length > 0 && (Setter as Specialization).Title != Prof_tb.Text)
                    {
                        Specialization s = new Specialization(Prof_tb.Text);
                        cb(ApplicationController.UpdateSpec(s, (Setter as Specialization).ID));
                        this.Close();
                    }
                    break;
                case "Graph":
                    EditGraph();
                    break;
            }
        }

        private void AddService()
        {
            if (!CheckService()) return;
            else
            {
                Service s = new Service(ss_name.Text, Convert.ToInt32(ss_cost.Text));
                cb(ApplicationController.AddService(s));
                this.Close();
            }
        }

        private void EditService()
        {
            Service s = Setter as Service;
            if ((ss_cost.Text == s.Price.ToString() && ss_name.Text == s.Title)
                || !CheckService())
                return;
            else
            {
                Service ns = new Service(ss_name.Text, Convert.ToInt32(ss_cost.Text));
                cb(ApplicationController.UpdateService(ns, s.ID));
                this.Close();
            }
        }

        private void AddAnalyse()
        {
            if (!CheckService()) return;
            else
            {
                Analyse a = new Analyse(ss_name.Text, Convert.ToInt32(ss_cost.Text));
                cb(ApplicationController.AddAnalyse(a));
                this.Close();
            }
        }

        private void EditAnalyse()
        {
            Analyse a = Setter as Analyse;
            if ((ss_cost.Text == a.Price.ToString() && ss_name.Text == a.Title) 
                || !CheckService()) return;
            else
            {
                Analyse na = new Analyse(ss_name.Text, Convert.ToInt32(ss_cost.Text));
                cb(ApplicationController.UpdateAnalyse(na, a.ID));
                this.Close();
            }
        }

        private void AddEmployee()
        {
            if (!CheckEmployee()) return;
            else
            {
                Employee e = new Employee(es_sur.Text, es_name.Text, es_otch.Text, es_phone.Text, es_ad.Text, (DateTime)es_birth.SelectedDate, (es_gender.SelectedValue as ComboBoxItem).Content.ToString());
                cb(ApplicationController.AddEmployee(e));
                this.Close();
            }
        }

        private void EditEmployee()
        {
            Employee e = Setter as Employee;
            if ((es_ad.Text == e.Adress && es_birth.SelectedDate == e.Birthdate && es_gender.Text == e.Gender
                && es_name.Text == e.Name && es_otch.Text == e.SecondName && es_phone.Text == e.Phone 
                && es_sur.Text == e.Surname) || (!CheckEmployee())) return;
            else
            {
                Employee ne = new Employee(es_sur.Text, es_name.Text, es_otch.Text, es_phone.Text, es_ad.Text, (DateTime)es_birth.SelectedDate, (es_gender.SelectedValue as ComboBoxItem).Content.ToString());
                cb(ApplicationController.UpdateEmployee(ne, e.ID));
                this.Close();
            }
        }

        private void AddClient()
        {
            if (!CheckClient()) return;
            else
            {
                Client c = new Client(cs_pas.Text, cs_sur.Text, cs_name.Text, cs_otch.Text, cs_phone.Text, cs_adress.Text, (DateTime)cs_birthday.SelectedDate, (cs_gender.SelectedValue as ComboBoxItem).Content.ToString());
                cb(ApplicationController.AddClient(c));
                this.Close();
            }
        }

        private bool CheckService()
        {
            if (ss_name.Text.Length < 1)
            {
                MB("Не заполнено поле с названием анализа!", false);
                return false;
            }
            else if (ss_cost.Text.Length < 1)
            {
                MB("Не заполнено поле с ценой анализа!", false);
                return false;
            }
            return true;
        }

        private bool CheckEmployee()
        {
            if (es_sur.Text.Length < 1)
            {
                MB("Не заполнено поле с фамилией сотрудника!", false);
                return false;
            }
            else if (es_name.Text.Length < 1)
            {
                MB("Не заполнено поле с именем сотрудника!", false);
                return false;
            }
            else if (es_otch.Text.Length < 1)
            {
                MB("Не заполнено поле с отчеством сотрудника!", false);
                return false;
            }
            else if (es_gender.SelectedValue == null)
            {
                MB("Не заполнено поле с полом сотрудника!", false);
                return false;
            }
            else if (es_birth.SelectedDate == null)
            {
                MB("Не заполнено поле с датой рождения сотрудника!", false);
                return false;
            }
            else if (es_phone.Text.Contains('_'))
            {
                MB("Не заполнено поле с телефоном сотрудника!", false);
                return false;
            }
            else if (es_ad.Text.Length < 1)
            {
                MB("Не заполнено поле с адресом сотрудника!", false);
                return false;
            }
            return true;
        }

        private bool CheckClient()
        {
            if (cs_pas.Text.Contains('_'))
            {
                MB("Не заполнены паспортные данные клиента!", false);
                return false;
            }
            else if (cs_sur.Text.Length < 1)
            {
                MB("Не заполнено поле с фамилией клиента!", false);
                return false;
            }
            else if (cs_name.Text.Length < 1)
            {
                MB("Не заполнено поле с именем клиента!", false);
                return false;
            }
            else if (cs_otch.Text.Length < 1)
            {
                MB("Не заполнено поле с отчеством клиента!", false);
                return false;
            }
            else if (cs_gender.SelectedValue == null)
            {
                MB("Не заполнено поле с полом клиента!", false);
                return false;
            }
            else if (cs_birthday.SelectedDate == null)
            {
                MB("Не заполнено поле с датой рождения клиента!", false);
                return false;
            }
            else if (cs_phone.Text.Contains('_'))
            {
                MB("Не заполнено поле с телефоном клиента!", false);
                return false;
            }
            else if (cs_adress.Text.Length < 1)
            {
                MB("Не заполнено поле с адресом клиента!", false);
                return false;
            }
            return true;
        }

        private void EditClient()
        {
            Client c = Setter as Client;
            if ((cs_pas.Text == c.Passport && cs_adress.Text == c.Adress && cs_birthday.SelectedDate == c.Birthdate
                && cs_gender.Text == c.Gender && cs_name.Text == c.Name && cs_otch.Text == c.SecondName
                && cs_phone.Text == c.Passport && cs_sur.Text == c.Surname) || !CheckClient())
                return;
            else
            {
                Client nc = new Client(cs_pas.Text, cs_sur.Text, cs_name.Text, cs_otch.Text, cs_phone.Text, cs_adress.Text, (DateTime)cs_birthday.SelectedDate, (cs_gender.SelectedValue as ComboBoxItem).Content.ToString());
                cb(ApplicationController.UpdateClient(nc, c.ID));
                this.Close();
            }
        }

        private void MB(string text, bool what)
        {
            if (what)
            {
                MessageBox.Show(text, "Менджер базы данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(text, "Менеджер базы данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddGraph()
        {
            Graph g = new Graph();

            if (Interval.SelectedItem == null) return;

            g.Interval = Convert.ToInt32((Interval.SelectedItem as ComboBoxItem).Content);

            if ((!(bool)pn.IsChecked && !(bool)vt.IsChecked && !(bool)sr.IsChecked && !(bool)ch.IsChecked
                && !(bool)pt.IsChecked && !(bool)sb.IsChecked) && !(bool)vs.IsChecked)
                return;

            if ((bool)pn.IsChecked)
            {
                g.PnStart = (DateTime)pntp.Value;
                g.PnEnd = (DateTime)pntpe.Value;

                if (!CheckGraph(g.PnStart, g.PnEnd, g.Interval))
                {
                    MB("понедельник");
                    return;
                }
            }
            else
            {
                g.PnStart = new DateTime();
                g.PnEnd = new DateTime();
            }

            if ((bool)vt.IsChecked)
            {
                g.VtStart = (DateTime)vttp.Value;
                g.VtEnd = (DateTime)vttpe.Value;

                if (!CheckGraph(g.VtStart, g.VtEnd, g.Interval))
                {
                    MB("вторник");
                    return;
                }
            }
            else
            {
                g.VtStart = new DateTime();
                g.VtEnd = new DateTime();
            }

            if ((bool)sr.IsChecked)
            {
                g.SrStart = (DateTime)srtp.Value;
                g.SrEnd = (DateTime)srtpe.Value;

                if (!CheckGraph(g.SrStart, g.SrEnd, g.Interval))
                {
                    MB("среда");
                    return;
                }
            }
            else
            {
                g.SrStart = new DateTime();
                g.SrEnd = new DateTime();
            }

            if ((bool)ch.IsChecked)
            {
                g.ChStart = (DateTime)chtp.Value;
                g.ChEnd = (DateTime)chtpe.Value;

                if (!CheckGraph(g.ChStart, g.ChEnd, g.Interval))
                {
                    MB("четверг");
                    return;
                }
            }
            else
            {
                g.ChStart = new DateTime();
                g.ChEnd = new DateTime();
            }

            if ((bool)pt.IsChecked)
            {
                g.PtStart = (DateTime)pttp.Value;
                g.PtEnd = (DateTime)pttpe.Value;

                if (!CheckGraph(g.PtStart, g.PtEnd, g.Interval))
                {
                    MB("пятница");
                    return;
                }
            }
            else
            {
                g.PtStart = new DateTime();
                g.PtEnd = new DateTime();
            }

            if ((bool)sb.IsChecked)
            {
                g.SbStart = (DateTime)sbtp.Value;
                g.SbEnd = (DateTime)sbtpe.Value;

                if (!CheckGraph(g.SbStart, g.SbEnd, g.Interval))
                {
                    MB("суббота");
                    return;
                }
            }
            else
            {
                g.SbStart = new DateTime();
                g.SbEnd = new DateTime();
            }

            if ((bool)vs.IsChecked)
            {
                g.VsStart = (DateTime)vstp.Value;
                g.VsEnd = (DateTime)vstpe.Value;

                if (!CheckGraph(g.VsStart, g.VsEnd, g.Interval))
                {
                    MB("воскресенье");
                    return;
                }
            }
            else
            {
                g.VsStart = new DateTime();
                g.VsEnd = new DateTime();
            }

            CreatedGraph = g;
            this.Close();
        }

        private bool CheckGraph(DateTime s, DateTime e, int i)
        {
            int minutes = (e.Hour * 60 + e.Minute) - (s.Hour * 60 + s.Minute);
            return (minutes % i == 0) && minutes > 0;
        }

        private void MB(string day)
        {
            MessageBox.Show(String.Format("В день {0}, время начала работы сотрудника и время конца работы сотрудника не совпадают с временным промежутком!", day), "Ошибка создания графика", MessageBoxButton.OK, MessageBoxImage.Error) ;
        }

        private void pn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if ((bool)cb.IsChecked)
            {
                pntp.IsEnabled = true;
                pntpe.IsEnabled = true;
            }
            else
            {
                pntp.IsEnabled = false;
                pntpe.IsEnabled = false;
            }
        }

        private void vt_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if ((bool)cb.IsChecked)
            {
                vttp.IsEnabled = true;
                vttpe.IsEnabled = true;
            }
            else
            {
                vttp.IsEnabled = false;
                vttpe.IsEnabled = false;
            }
        }

        private void sr_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if ((bool)cb.IsChecked)
            {
                srtp.IsEnabled = true;
                srtpe.IsEnabled = true;
            }
            else
            {
                srtp.IsEnabled = false;
                srtpe.IsEnabled = false;
            }
        }

        private void ch_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if ((bool)cb.IsChecked)
            {
                chtp.IsEnabled = true;
                chtpe.IsEnabled = true;
            }
            else
            {
                chtp.IsEnabled = false;
                chtpe.IsEnabled = false;
            }
        }

        private void pt_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if ((bool)cb.IsChecked)
            {
                pttp.IsEnabled = true;
                pttpe.IsEnabled = true;
            }
            else
            {
                pttp.IsEnabled = false;
                pttpe.IsEnabled = false;
            }
        }

        private void sb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if ((bool)cb.IsChecked)
            {
                sbtp.IsEnabled = true;
                sbtpe.IsEnabled = true;
            }
            else
            {
                sbtp.IsEnabled = false;
                sbtpe.IsEnabled = false;
            }
        }

        private void vs_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if ((bool)cb.IsChecked)
            {
                vstp.IsEnabled = true;
                vstpe.IsEnabled = true;
            }
            else
            {
                vstp.IsEnabled = false;
                vstpe.IsEnabled = false;
            }
        }

        private void ss_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            string n = "";
            for (int i=0; i<ss_cost.Text.Length; i++)
            {
                if (Char.IsDigit(ss_cost.Text[i]))
                {
                    n += ss_cost.Text[i];
                }
                else
                {
                    SystemSounds.Beep.Play();
                }
            }
            ss_cost.Text = n;
        }

        private void EditGraph()
        {
            Graph g = new Graph();

            if (Interval.SelectedItem == null) return;

            g.Interval = Convert.ToInt32((Interval.SelectedItem as ComboBoxItem).Content);

            if ((!(bool)pn.IsChecked && !(bool)vt.IsChecked && !(bool)sr.IsChecked && !(bool)ch.IsChecked
                && !(bool)pt.IsChecked && !(bool)sb.IsChecked) && !(bool)vs.IsChecked)
                return;

            if ((bool)pn.IsChecked)
            {
                g.PnStart = (DateTime)pntp.Value;
                g.PnEnd = (DateTime)pntpe.Value;

                if (!CheckGraph(g.PnStart, g.PnEnd, g.Interval))
                {
                    MB("понедельник");
                    return;
                }
            }
            else
            {
                g.PnStart = new DateTime();
                g.PnEnd = new DateTime();
            }

            if ((bool)vt.IsChecked)
            {
                g.VtStart = (DateTime)vttp.Value;
                g.VtEnd = (DateTime)vttpe.Value;

                if (!CheckGraph(g.VtStart, g.VtEnd, g.Interval))
                {
                    MB("вторник");
                    return;
                }
            }
            else
            {
                g.VtStart = new DateTime();
                g.VtEnd = new DateTime();
            }

            if ((bool)sr.IsChecked)
            {
                g.SrStart = (DateTime)srtp.Value;
                g.SrEnd = (DateTime)srtpe.Value;

                if (!CheckGraph(g.SrStart, g.SrEnd, g.Interval))
                {
                    MB("среда");
                    return;
                }
            }
            else
            {
                g.SrStart = new DateTime();
                g.SrEnd = new DateTime();
            }

            if ((bool)ch.IsChecked)
            {
                g.ChStart = (DateTime)chtp.Value;
                g.ChEnd = (DateTime)chtpe.Value;

                if (!CheckGraph(g.ChStart, g.ChEnd, g.Interval))
                {
                    MB("четверг");
                    return;
                }
            }
            else
            {
                g.ChStart = new DateTime();
                g.ChEnd = new DateTime();
            }

            if ((bool)pt.IsChecked)
            {
                g.PtStart = (DateTime)pttp.Value;
                g.PtEnd = (DateTime)pttpe.Value;

                if (!CheckGraph(g.PtStart, g.PtEnd, g.Interval))
                {
                    MB("пятница");
                    return;
                }
            }
            else
            {
                g.PtStart = new DateTime();
                g.PtEnd = new DateTime();
            }

            if ((bool)sb.IsChecked)
            {
                g.SbStart = (DateTime)sbtp.Value;
                g.SbEnd = (DateTime)sbtpe.Value;

                if (!CheckGraph(g.SbStart, g.SbEnd, g.Interval))
                {
                    MB("суббота");
                    return;
                }
            }
            else
            {
                g.SbStart = new DateTime();
                g.SbEnd = new DateTime();
            }

            if ((bool)vs.IsChecked)
            {
                g.VsStart = (DateTime)vstp.Value;
                g.VsEnd = (DateTime)vstpe.Value;

                if (!CheckGraph(g.VsStart, g.VsEnd, g.Interval))
                {
                    MB("воскресенье");
                    return;
                }
            }
            else
            {
                g.VsStart = new DateTime();
                g.VsEnd = new DateTime();
            }

            cb(ApplicationController.UpdateGraph(g, (Setter as DoctorsSpec).ID));
            this.Close();
        }
    }
}
