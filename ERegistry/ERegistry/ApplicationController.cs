using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Xml.Serialization;
using System.Xml;
using System.Security.Cryptography;

namespace ERegistry
{
    class ApplicationController
    {
        private static SqlConnection erdb = new SqlConnection("Data Source=127.0.0.1,1433;Network Library=DBMSSOCN;Initial Catalog=ERegistry;Integrated Security=True;");

        public static void ShowAddToDB(string Type, Action<bool> callback)
        {
            AddToDB add = new AddToDB(Type, callback);
            add.ShowDialog();
        }

        public static void ShowAddGraph(Action<bool> callback)
        {
            AddGraph ag = new AddGraph(callback);
            ag.ShowDialog();
        }

        public static void ShowSpecializationsDictionary()
        {
            SpecDictionary sd = new SpecDictionary();
            sd.ShowDialog();
        }

        public static DataTable ExecuteQuery(string Command)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand(Command, erdb);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch
            {
                MessageBox.Show("Execute exeption: sql command");
            }

            return dt;
        }

        public static DataTable ExecuteQuery(SqlCommand cmd)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Execute exeption: sql command");
            }

            return dt;
        }

        private static bool ExecuteQuery(SqlConnection db, SqlCommand command)
        {
            try
            {
                db.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                erdb.Close();
            }

            return true;
        }

        public static bool ExecuteCommand(string Command)
        {
            try
            {
                erdb.Open();
                SqlCommand cmd = new SqlCommand(Command, erdb);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Execute exeption: sql command");
                return false;
            }
            finally
            {
                erdb.Close();
            }
            return true;
        }

        public static bool ExecuteCommand(SqlCommand Command)
        {
            try
            {
                erdb.Open();
                Command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Execute exeption: sql command");
                return false;
            }
            finally
            {
                erdb.Close();
            }
            return true;
        }

        public static bool AddSpecialization(Specialization spec)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO spec (name) VALUES (@Name)";
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = spec.Title;

            return ExecuteQuery(erdb, command);
        }

        public static bool AddService(Service service)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO service (name, cost) VALUES (@Name, @Cost)";
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = service.Title;
            command.Parameters.Add("Cost", SqlDbType.Int).Value = service.Price;

            return ExecuteQuery(erdb, command);
        }

        public static bool AddAnalyse(Analyse analyse)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO analyzes (name, cost) VALUES (@Name, @Cost)";
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = analyse.Title;
            command.Parameters.Add("Cost", SqlDbType.Int).Value = analyse.Price;

            return ExecuteQuery(erdb, command);
        }

        public static bool AddClient(Client client)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO clients (passport, surname, name, otch, birth, gender, phone, address) VALUES (@Passport, @Surname, @Name, @Otch, @Birth, @Gender, @Phone, @Address)";
            command.Parameters.Add("Passport", SqlDbType.NVarChar).Value = client.Passport;
            command.Parameters.Add("Surname", SqlDbType.NVarChar).Value = client.Surname;
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = client.Name;
            command.Parameters.Add("Otch", SqlDbType.NVarChar).Value = client.SecondName;
            command.Parameters.Add("Birth", SqlDbType.Date).Value = client.Birthdate;
            command.Parameters.Add("Gender", SqlDbType.NVarChar).Value = client.Gender;
            command.Parameters.Add("Phone", SqlDbType.NVarChar).Value = client.Phone;
            command.Parameters.Add("Address", SqlDbType.NVarChar).Value = client.Adress;

            return ExecuteQuery(erdb, command);
        }
        
        public static bool AddEmployee(Employee e)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO doctors (surname, name, otch, birth, gender, phone, address) VALUES (@Surname, @Name, @Otch, @Birth, @Gender, @Phone, @Address)";
            command.Parameters.Add("Surname", SqlDbType.NVarChar).Value = e.Surname;
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = e.Name;
            command.Parameters.Add("Otch", SqlDbType.NVarChar).Value = e.SecondName;
            command.Parameters.Add("Birth", SqlDbType.Date).Value = e.Birthdate;
            command.Parameters.Add("Gender", SqlDbType.NVarChar).Value = e.Gender;
            command.Parameters.Add("Phone", SqlDbType.NVarChar).Value = e.Phone;
            command.Parameters.Add("Address", SqlDbType.NVarChar).Value = e.Adress;

            return ExecuteQuery(erdb, command);
        }

        public static bool AddGraph(Employee e, Specialization s, Graph g)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO doctors_spec (doctor, spec, schedule) VALUES (@Doctor, @Spec, @Schedule)";
            command.Parameters.Add("Doctor", SqlDbType.Int).Value = e.ID;
            command.Parameters.Add("Spec", SqlDbType.Int).Value = s.ID;
            command.Parameters.Add("Schedule", SqlDbType.Xml).Value = Utils.ObjectToXMLGeneric(g);

            return ExecuteQuery(erdb, command);
        }

        public static bool AddRegistry(int client, int e, int service, DateTime date, bool push, bool paid)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO registry (client_id, doctor_id, datetime, service, push, paid) VALUES (@Client, @Doctor, @Time, @Service, @Push, @Paid)";
            command.Parameters.Add("Client", SqlDbType.Int).Value = client;
            command.Parameters.Add("Doctor", SqlDbType.Int).Value = e;
            command.Parameters.Add("Time", SqlDbType.DateTime).Value = date;
            command.Parameters.Add("Service", SqlDbType.Int).Value = service;
            command.Parameters.Add("Push", SqlDbType.Bit).Value = push;
            command.Parameters.Add("Paid", SqlDbType.Int).Value = paid;

            return ExecuteQuery(erdb, command);
        }

        public static bool AddHistory(int reg_id, string diagnosis, string details, string curing, List<Analyse> an)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO history (registry_id, diagnosis, details, curing) VALUES (@rid, @di, @de, @cu)";
            command.Parameters.Add("rid", SqlDbType.Int).Value = reg_id;
            command.Parameters.Add("di", SqlDbType.NVarChar).Value = diagnosis;
            command.Parameters.Add("de", SqlDbType.NVarChar).Value = details;
            command.Parameters.Add("cu", SqlDbType.NVarChar).Value = curing;

            if (an != null && an.Count > 0)
            {
                bool result = ExecuteCommand(command);
                if (!result) return false;

                SqlCommand cmd = erdb.CreateCommand();
                cmd.CommandText = "SELECT * FROM history WHERE registry_id=(@rid) AND diagnosis=(@di) AND details=(@de) AND curing=(@cu)";
                cmd.Parameters.Add("rid", SqlDbType.Int).Value = reg_id;
                cmd.Parameters.Add("di", SqlDbType.NVarChar).Value = diagnosis;
                cmd.Parameters.Add("de", SqlDbType.NVarChar).Value = details;
                cmd.Parameters.Add("cu", SqlDbType.NVarChar).Value = curing;

                DataTable dt = ExecuteQuery(cmd);
                int id = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());

                foreach (Analyse a in an)
                {
                    AddAnalyseToHistory(id, a.ID);
                }

                return true;
            }
            else
            {
                return ExecuteQuery(erdb, command);
            }
        }

        public static bool AddAnalyseToHistory(int history_id, int analyse_id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO analyzes_history (history_id, a_id) VALUES (@hid, @aid)";
            command.Parameters.Add("hid", SqlDbType.Int).Value = history_id;
            command.Parameters.Add("aid", SqlDbType.Int).Value = analyse_id;

            return ExecuteQuery(erdb, command);
        }

        public static bool AddUser(User u)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO users (login, password, access) VALUES (@login, @pas, @a)";
            command.Parameters.Add("login", SqlDbType.NVarChar).Value = u.Login;
            command.Parameters.Add("pas", SqlDbType.NVarChar).Value = u.MD5;
            command.Parameters.Add("a", SqlDbType.Int).Value = u.Access;

            return ExecuteQuery(erdb, command);
        }

        public static DataTable SelectSpectializations(string search)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = SQLCommands.SelectSpecializations + " WHERE name LIKE @Name";
            command.Parameters.Add("Name", SqlDbType.VarChar).Value = AddPercentage(search);
            
            return ExecuteQuery(command);
        }

        public static DataTable SelectServices(string search)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = SQLCommands.SelectServices + " WHERE name LIKE @Name";
            command.Parameters.Add("Name", SqlDbType.VarChar).Value = AddPercentage(search);

            return ExecuteQuery(command);
        }

        public static DataTable SelectEmployeeBySurname(string search)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = SQLCommands.SelectEmployees + " WHERE surname LIKE @Name";
            command.Parameters.Add("Name", SqlDbType.VarChar).Value = AddPercentage(search);

            return ExecuteQuery(command);
        }

        public static bool FindUser(string login, string md5)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT login FROM users WHERE login=(@login) AND password=(@md5)";
            command.Parameters.Add("login", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("md5", SqlDbType.VarChar).Value = md5;

            DataTable dt = ExecuteQuery(command);

            if (dt.Rows.Count > 0) return true;
            else return false;
        }

        public static int GetUserAccess(string login, string md5)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT access FROM users WHERE login=(@login) AND password=(@md5)";
            command.Parameters.Add("login", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("md5", SqlDbType.VarChar).Value = md5;

            DataTable dt = ExecuteQuery(command);

            return Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
        }

        public static DataTable SelectClientBySurname(string search)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = SQLCommands.SelectClients + " WHERE surname LIKE @Name";
            command.Parameters.Add("Name", SqlDbType.VarChar).Value = AddPercentage(search);

            return ExecuteQuery(command);
        }

        public static DataTable SelectTop25ByDoctorAndDate(int doctor_id, DateTime dt)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT TOP 25 * FROM registry INNER JOIN clients ON registry.client_id=clients.client_id INNER JOIN service ON registry.service=service.service_id WHERE doctor_id=(@Doctor) AND datetime>=(@DT) ORDER BY registry.datetime";
            command.Parameters.Add("Doctor", SqlDbType.Int).Value = doctor_id;
            command.Parameters.Add("DT", SqlDbType.DateTime).Value = dt;

            return ExecuteQuery(command);
        }

        public static DataTable SelectTop25ByDate(DateTime dt)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT TOP 25 * FROM registry INNER JOIN clients ON registry.client_id=clients.client_id INNER JOIN service ON registry.service=service.service_id WHERE datetime>=(@DT) ORDER BY registry.datetime";
            command.Parameters.Add("DT", SqlDbType.DateTime).Value = dt;

            return ExecuteQuery(command);
        }

        public static DataTable SelectHistoryByClient(Client client)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = SQLCommands.SelectHistory + " WHERE clients.client_id=(@Client_id)";
            command.Parameters.Add("Client_id", SqlDbType.Int).Value = client.ID;

            return ExecuteQuery(command);
        }

        public static double SelectTopMoneyByYesterday()
        {
            DateTime before = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime to = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            before = before.AddDays(-1);

            SqlCommand command = erdb.CreateCommand();

            command.CommandText = SQLCommands.SelectMoneySum + " WHERE registry.paid=(@paid) AND (registry.datetime BETWEEN (@before) AND (@to))";
            command.Parameters.Add("paid", SqlDbType.Bit).Value = true;
            command.Parameters.Add("before", SqlDbType.DateTime).Value = before;
            command.Parameters.Add("to", SqlDbType.DateTime).Value = to;

            var dt = ExecuteQuery(command).Rows[0].ItemArray[0].ToString();

            if (dt == "") return 0;
            return Convert.ToDouble(dt);
        }

        public static DataTable SelectDoctorsList(int doctor_id)
        {
            DateTime before = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime to = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            to = to.AddDays(1);

            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT registry.datetime AS \"Дата\", clients.surname AS \"Фамилия\", clients.name AS \"Имя\", clients.otch AS \"Отчество\", service.name AS \"Название услуги\" FROM registry INNER JOIN clients ON registry.client_id=clients.client_id INNER JOIN service ON registry.service=service.service_id WHERE registry.doctor_id=(@id) AND registry.datetime BETWEEN (@before) AND (@to) ORDER BY registry.datetime";
            command.Parameters.Add("id", SqlDbType.Int).Value = doctor_id;
            command.Parameters.Add("before", SqlDbType.DateTime).Value = before;
            command.Parameters.Add("to", SqlDbType.DateTime).Value = to;

            return ExecuteQuery(command);
        }

        public static DataTable SelectZReport(DateTime date)
        {
            DateTime before = new DateTime(date.Year, date.Month, date.Day);
            DateTime to = before;
            to = to.AddDays(1);

            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT registry.datetime AS \"Дата\", service.name as \"Услуга\", service.cost as \"Стоимость\", doctors.surname as \"Фамилия доктора\", doctors.name as \"Имя доктора\", doctors.otch as \"Отчество доктора\" FROM registry INNER JOIN doctors_spec ON registry.doctor_id=doctors_spec.doctor INNER JOIN doctors ON doctors_spec.doctor=doctors.doctor_id INNER JOIN service ON registry.service=service.service_id WHERE paid=1 AND datetime BETWEEN (@before) AND (@to) ORDER BY datetime";
            command.Parameters.Add("before", SqlDbType.DateTime).Value = before;
            command.Parameters.Add("to", SqlDbType.DateTime).Value = to;

            return ExecuteQuery(command);
        }

        public static bool UpdateRegistryByService(int registry_id, int service_id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "UPDATE registry SET service=(@Service) WHERE registry_id=(@Registry)";
            command.Parameters.Add("Service", SqlDbType.Int).Value = service_id;
            command.Parameters.Add("Registry", SqlDbType.Int).Value = registry_id;

            return ExecuteCommand(command);
        }

        public static bool UpdateSpec(Specialization spec, int old)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "UPDATE spec SET name=(@Name) WHERE id=(@old)";
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = spec.Title;
            command.Parameters.Add("old", SqlDbType.Int).Value = old;

            return ExecuteQuery(erdb, command);
        }

        public static bool UpdateService(Service service, int old)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "UPDATE service SET name=(@Name), cost=(@Cost) WHERE service_id=(@old)";
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = service.Title;
            command.Parameters.Add("Cost", SqlDbType.Int).Value = service.Price;
            command.Parameters.Add("old", SqlDbType.Int).Value = old;

            return ExecuteQuery(erdb, command);
        }

        public static bool UpdateAnalyse(Analyse analyse, int old)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "UPDATE analyzes SET name=(@Name), cost=(@Cost) WHERE a_id=(@old)";
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = analyse.Title;
            command.Parameters.Add("Cost", SqlDbType.Int).Value = analyse.Price;
            command.Parameters.Add("old", SqlDbType.Int).Value = old;

            return ExecuteQuery(erdb, command);
        }

        public static bool UpdateClient(Client client, int old)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "UPDATE clients SET passport=(@Passport), surname=(@Surname), name=(@Name), otch=(@Otch), birth=(@Birth), gender=(@Gender), phone=(@Phone), address=(@Address) WHERE client_id=(@old)";
            command.Parameters.Add("Passport", SqlDbType.NVarChar).Value = client.Passport;
            command.Parameters.Add("Surname", SqlDbType.NVarChar).Value = client.Surname;
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = client.Name;
            command.Parameters.Add("Otch", SqlDbType.NVarChar).Value = client.SecondName;
            command.Parameters.Add("Birth", SqlDbType.Date).Value = client.Birthdate;
            command.Parameters.Add("Gender", SqlDbType.NVarChar).Value = client.Gender;
            command.Parameters.Add("Phone", SqlDbType.NVarChar).Value = client.Phone;
            command.Parameters.Add("Address", SqlDbType.NVarChar).Value = client.Adress;
            command.Parameters.Add("old", SqlDbType.Int).Value = old;

            return ExecuteQuery(erdb, command);
        }

        public static bool UpdateEmployee(Employee e, int old)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "UPDATE doctors SET surname=(@Surname), name=(@Name), otch=(@Otch), birth=(@Birth), gender=(@Gender), phone=(@Phone), address=(@Address) WHERE doctor_id=(@old)";
            command.Parameters.Add("Surname", SqlDbType.NVarChar).Value = e.Surname;
            command.Parameters.Add("Name", SqlDbType.NVarChar).Value = e.Name;
            command.Parameters.Add("Otch", SqlDbType.NVarChar).Value = e.SecondName;
            command.Parameters.Add("Birth", SqlDbType.Date).Value = e.Birthdate;
            command.Parameters.Add("Gender", SqlDbType.NVarChar).Value = e.Gender;
            command.Parameters.Add("Phone", SqlDbType.NVarChar).Value = e.Phone;
            command.Parameters.Add("Address", SqlDbType.NVarChar).Value = e.Adress;
            command.Parameters.Add("old", SqlDbType.Int).Value = old;

            return ExecuteQuery(erdb, command);
        }

        public static bool UpdateGraph(Graph g, int old)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO doctors_spec SET schedule=(@Schedule) WHERE id=(@old)";
            command.Parameters.Add("Schedule", SqlDbType.Xml).Value = Utils.ObjectToXMLGeneric(g);
            command.Parameters.Add("old", SqlDbType.Int).Value = old;

            return ExecuteQuery(erdb, command);
        }

        public static bool UpdatePayment(int id, bool payment)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "INSERT INTO registry SET paid=(@paid) WHERE registry_id=(@old)";
            command.Parameters.Add("paid", SqlDbType.Bit).Value = payment;
            command.Parameters.Add("old", SqlDbType.Int).Value = id;

            return ExecuteQuery(erdb, command);
        }

        public static bool DeleteRegistry(int registry_id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM registry WHERE registry_id=(@Registry)";
            command.Parameters.Add("Registry", SqlDbType.Int).Value = registry_id;

            return ExecuteCommand(command);
        }

        public static bool DeleteHistory(int history_id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM history WHERE history_id=(@History)";
            command.Parameters.Add("History", SqlDbType.Int).Value = history_id;

            return ExecuteCommand(command);
        }

        public static bool DeleteClient(int client_id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM clients WHERE client_id=(@Client)";
            command.Parameters.Add("Client", SqlDbType.Int).Value = client_id;

            return ExecuteCommand(command);
        }

        public static bool DeleteEmployee(int e_id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM doctors WHERE doctor_id=(@Doctor)";
            command.Parameters.Add("Doctor", SqlDbType.Int).Value = e_id;

            return ExecuteCommand(command);
        }

        public static bool DeleteService(int id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM service WHERE service_id=(@id)";
            command.Parameters.Add("id", SqlDbType.Int).Value = id;

            return ExecuteCommand(command);
        }

        public static bool DeleteAnalyse(int id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM analyzes WHERE a_id=(@id)";
            command.Parameters.Add("id", SqlDbType.Int).Value = id;

            return ExecuteCommand(command);
        }

        public static bool DeleteGraph(int id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM doctors_spec WHERE id=(@id)";
            command.Parameters.Add("id", SqlDbType.Int).Value = id;

            return ExecuteCommand(command);
        }

        public static bool DeleteSpec(int id)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "DELETE FROM spec WHERE id=(@id)";
            command.Parameters.Add("id", SqlDbType.Int).Value = id;

            return ExecuteCommand(command);
        }

        public static Graph SelectGraphWithIdAndSpec(int id, string spec)
        {
            string cmd = "SELECT schedule FROM doctors_spec INNER JOIN spec ON doctors_spec.spec = spec.id WHERE doctors_spec.id=" + id.ToString() +  "AND spec.name = '" + spec + "'";
            DataTable dt = ExecuteQuery(cmd);

            Graph graph = Utils.XMLToObject<Graph>(dt.Rows[0].ItemArray[0].ToString());
            return graph;
        }

        public static DataTable SelectRegistryEntry(int id, DateTime time)
        {
            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT * FROM registry INNER JOIN clients ON registry.client_id=clients.client_id INNER JOIN service ON registry.service=service.service_id WHERE registry.doctor_id=(@Doctor) AND registry.datetime=(@DateTime)";
            command.Parameters.Add("Doctor", SqlDbType.Int).Value = id;
            command.Parameters.Add("DateTime", SqlDbType.DateTime).Value = time;

            return ExecuteQuery(command);
        }

        public static string GetCorrectDate(DateTime dt)
        {
            return dt.Day + "/" + dt.Month + "/" + dt.Year + " 12:00:00 AM";
        }

        public static string GetCorrectDateTime(DateTime dt)
        {
            return dt.Year + "-" + Utils.GCTime(dt.Month) + "-" + Utils.GCTime(dt.Day) + "T" + Utils.GCTime(dt.Hour) + ":" + Utils.GCTime(dt.Minute) + ":00.000";
        }

        private static string And(bool b)
        {
            if (b) return " AND ";
            else return "";
        }

        private static string AddPercentage(string s)
        {
            return '%' + s + '%';
        }

        public static Employee ParseEmployee(object[] obj)
        {
            return new Employee(Convert.ToInt32(obj[0]), obj[1].ToString(), obj[2].ToString(), 
                obj[3].ToString(), obj[6].ToString(), obj[7].ToString(), (DateTime)obj[4], obj[5].ToString());
        }

        public static Specialization ParseSpecialization(object[] obj)
        {
            return new Specialization(Convert.ToInt32(obj[0].ToString()), obj[1].ToString());
        }

        public static Client ParseClient(object[] obj)
        {
            return new Client(Convert.ToInt32(obj[0].ToString()), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString(), obj[7].ToString(), obj[8].ToString(), (DateTime)obj[5], obj[6].ToString());
        }

        public static Service ParseService(object[] obj)
        {

            return new Service(Convert.ToInt32(obj[0].ToString()), obj[1].ToString(), Convert.ToDouble(obj[2].ToString()));
        }

        public static Analyse ParseAnalyse(object[] obj)
        {
            return new Analyse(Convert.ToInt32(obj[0].ToString()), obj[1].ToString(), Convert.ToDouble(obj[2].ToString()));
        }

        public static HistoryEntity ParseHistory(object[] obj)
        {
            int id = Convert.ToInt32(obj[0].ToString());
            List<Analyse> an = ParseAnalyzes(id);
            string client = obj[3].ToString() + " " + obj[4].ToString() + " " + obj[5].ToString();
            string doctor = obj[9].ToString() + " " + obj[10].ToString() + " " + obj[11].ToString();
            return new HistoryEntity(id, client, doctor, obj[6].ToString(), obj[7].ToString(), obj[8].ToString(), (DateTime)obj[1], an);
        }

        public static List<Analyse> ParseAnalyzes(int history_id)
        {
            List<Analyse> an = new List<Analyse>();

            SqlCommand command = erdb.CreateCommand();

            command.CommandText = "SELECT analyzes.a_id, analyzes.name, analyzes.cost FROM analyzes_history INNER JOIN analyzes ON analyzes_history.a_id=analyzes.a_id WHERE analyzes_history.history_id=(@id)";
            command.Parameters.Add("id", SqlDbType.Int).Value = history_id;

            DataTable dt = ExecuteQuery(command);

            for (int i=0; i<dt.Rows.Count; i++)
            {
                an.Add(ParseAnalyse(dt.Rows[i].ItemArray));
            }

            return an;
        }

    }

    static class SQLCommands
    {
        private static string selectClients = "SELECT client_id AS \"Номер клиента\", passport AS \"Паспорт\", surname AS \"Фамилия\", name AS \"Имя\", otch AS \"Отчество\", birth AS \"Дата рождения\", gender AS \"Пол\", phone AS \"Телефон\", address AS \"Адрес\" FROM clients";
        private static string selectEmployees = "SELECT doctor_id AS \"Номер сотрудника\", surname AS \"Фамилия\", name AS \"Имя\", otch AS \"Отчество\", birth AS \"Дата рождения\", gender AS \"Пол\", phone AS \"Телефон\", address AS \"Адрес\" FROM doctors";
        private static string selectServices = "SELECT service_id AS \"Номер услуги\", name AS \"Название\", cost AS \"Стоимость\" FROM service";
        private static string selectGraphs = "SELECT * FROM doctors_spec";
        private static string selectAnalysies = "SELECT a_id AS \"Номер анализа\", name AS \"Название анализа\", cost AS \"Стоимость\" FROM analyzes";
        private static string selectSpecializations = "SELECT id AS \"Номер специальности\", name AS \"Название\" FROM spec";
        private static string joinDoctorsSpecAndSpec = "SELECT doctors_spec.id AS \"Номер доктора\", surname AS \"Фамилия\", doctors.name AS \"Имя\", otch AS \"Отчество\", spec.name AS \"Специальность\" FROM doctors INNER JOIN doctors_spec ON doctors_spec.doctor=doctors.doctor_id INNER JOIN spec ON doctors_spec.spec=spec.id;";
        private static string selectAddHistory = "SELECT registry.registry_id AS \"Номер\", registry.datetime AS \"Время записи\", clients.client_id AS \"Номер клиента\", clients.surname AS \"Фамилия клиента\", clients.name AS \"Имя клиента\", clients.otch AS \"Отчество клиента\", doctors.surname AS \"Фамилия доктора\", doctors.name AS \"Имя доктора\", doctors.otch AS \"Отчество доктора\", service.name AS \"Название услуги\", service.cost AS \"Стоимость услуги\", registry.push AS \"Напоминание\", registry.paid AS \"Услуга оплачена\" FROM registry INNER JOIN clients ON registry.client_id=clients.client_id INNER JOIN service ON registry.service=service.service_id INNER JOIN doctors_spec ON registry.doctor_id=doctors_spec.id INNER JOIN doctors ON doctors_spec.id=doctors.doctor_id";
        private static string selectHistory = "SELECT history.history_id AS \"Номер\", registry.datetime AS \"Время записи\", clients.client_id AS \"Номер клиента\", clients.surname AS \"Фамилия клиента\", clients.name AS \"Имя клиента\", clients.otch AS \"Отчество клиента\", history.diagnosis AS \"Диагноз\", history.details AS \"Описание\", history.curing AS \"Лечение\", doctors.surname AS \"Фамилия доктора\", doctors.name AS \"Имя доктора\", doctors.otch AS \"Отчество доктора\", service.name AS \"Название услуги\", service.cost AS \"Стоимость услуги\", registry.push AS \"Напоминание\", registry.paid AS \"Услуга оплачена\" FROM history INNER JOIN registry ON history.registry_id=registry.registry_id INNER JOIN clients ON registry.client_id=clients.client_id INNER JOIN service ON registry.service=service.service_id INNER JOIN doctors_spec ON registry.doctor_id=doctors_spec.id INNER JOIN doctors ON doctors_spec.id=doctors.doctor_id";
        private static string selectDoctorsSpecAndSpecWithIdFromDoctorSpec = "SELECT doctors_spec.doctor AS \"Номер доктора\", doctors.surname AS \"Фамилия доктора\", doctors.name AS \"Имя доктора\", doctors.otch AS \"Отчество доктора\", spec.name AS \"Специализация\" FROM doctors_spec INNER JOIN doctors ON doctors_spec.id=doctors.doctor_id INNER JOIN spec ON doctors_spec.spec=spec.id";
        //forms
        private static string selectMoneySum = "SELECT sum(service.cost) FROM registry INNER JOIN service ON registry.service=service.service_id";
        private static string selectTop5SumServices = "SELECT TOP 5 service.service_id, service.name, service.cost, Sum(service.cost) AS \"sum\" FROM registry INNER JOIN service ON registry.service=service.service_id GROUP BY service.service_id, service.name, service.cost ORDER BY \"sum\" DESC";
        private static string selectTop10Doctors = "SELECT TOP 10 doctors.surname, doctors.name, doctors.otch, SUM(service.cost) FROM registry INNER JOIN doctors ON registry.doctor_id=doctors.doctor_id INNER JOIN service ON registry.service=service.service_id WHERE registry.paid=1 GROUP BY doctors.surname, doctors.name, doctors.otch";
        private static string selectMoneyByMonths = "SELECT CAST(CONVERT(char(6), datetime, 112)+'01' AS smalldatetime), SUM(service.cost) FROM registry INNER JOIN service ON registry.service=service.service_id WHERE registry.paid=1 GROUP BY CAST(CONVERT(char(6), datetime, 112)+'01' AS smalldatetime)";

        public static string SelectClients
        {
            get
            {
                return selectClients;
            }
        }

        public static string SelectEmployees
        {
            get
            {
                return selectEmployees;
            }
        }

        public static string SelectServices
        {
            get
            {
                return selectServices;
            }
        }

        public static string SelectGraphs
        {
            get
            {
                return selectGraphs;
            }
        }

        public static string SelectAnalysies
        {
            get
            {
                return selectAnalysies;
            }
        }

        public static string SelectSpecializations
        {
            get
            {
                return selectSpecializations;
            }
        }
        
        public static string JoinDoctorsSpecAndDoctors
        {
            get
            {
                return joinDoctorsSpecAndSpec;
            }
        }

        public static string SelectAddHistory
        {
            get
            {
                return selectAddHistory;
            }
        }

        public static string SelectHistory
        {
            get
            {
                return selectHistory;
            }
        }

        public static string SelectMoneySum
        {
            get
            {
                return selectMoneySum;
            }
        }

        public static string SelectTop5SumServices
        {
            get
            {
                return selectTop5SumServices;
            }
        }

        public static string SelectTop10Doctors
        {
            get
            {
                return selectTop10Doctors;
            }
        }

        public static string SelectMoneyByMonths
        {
            get
            {
                return selectMoneyByMonths;
            }
        }

        public static string SelectDoctorsSpecAndSpecWithIdFromDoctorSpec
        {
            get
            {
                return selectDoctorsSpecAndSpecWithIdFromDoctorSpec;
            }
        }
    }

    public static class Utils
    {
        public static Color ConvertStringToColor(String hex)
        {

            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long) 
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes 
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }

        //Serializing object as XML to string
        public static String ObjectToXMLGeneric<T>(T filter)
        {

            string xml = null;
            using (StringWriter sw = new StringWriter())
            {

                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, filter);
                try
                {
                    xml = sw.ToString();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return xml;
        }

        //Deserializing XML to object
        public static T XMLToObject<T>(string xml)
        {

            var serializer = new XmlSerializer(typeof(T));

            using (var textReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(textReader))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }

        public static string GetCorrectMonth(int month)
        {
            switch (month)
            {
                case 1: return "января";
                case 2: return "февраля";
                case 3: return "марта";
                case 4: return "апреля";
                case 5: return "мая";
                case 6: return "июня";
                case 7: return "июля";
                case 8: return "августа";
                case 9: return "сентября";
                case 10: return "октября";
                case 11: return "ноября";
                case 12: return "декабря";
                default: return "";
            }
        }

        public static string GetCorrectMonthIm(int month)
        {
            switch (month)
            {
                case 1: return "Январь";
                case 2: return "Февраль";
                case 3: return "Март";
                case 4: return "Апрель";
                case 5: return "Май";
                case 6: return "Июнь";
                case 7: return "Июль";
                case 8: return "Август";
                case 9: return "Сентябрь";
                case 10: return "Октябрь";
                case 11: return "Ноябрь";
                case 12: return "Декабрь";
                default: return "";
            }
        }

        public static string GCTime(int time)
        {
            if (time >= 0 && time <= 9) return "0" + time;
            else return time.ToString();
        }

        public static string TrDW(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                default: return "";
            }
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChild<T>(child, childName);
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

        public static string ToMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
        }
    }
}
