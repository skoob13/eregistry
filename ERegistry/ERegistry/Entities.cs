using System;
using System.Collections.Generic;
using System.Linq;

namespace ERegistry
{
    public class Client
    {
        public int ID
        {
            get;
            set;
        }

        public string Passport
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string SecondName
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public DateTime Birthdate
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string Adress
        {
            get;
            set;
        }

        public Client()
        {
            ID = 0;
            Passport = "";
            Surname = "";
            Name = "";
            SecondName = "";
            Phone = "";
            Adress = "";
            Birthdate = new DateTime();
            Gender = "Male";
        }

        public Client(int id, string passport, string surname, string name, string secondname, string phone, string adress, DateTime birthdate, string gender)
        {
            ID = id;
            Passport = passport;
            Surname = surname;
            Name = name;
            SecondName = secondname;
            Phone = phone;
            Adress = adress;
            Birthdate = birthdate;
            Gender = gender;
        }

        public Client(string passport, string surname, string name, string secondname, string phone, string adress, DateTime birthdate, string gender)
        {
            ID = 0;
            Passport = passport;
            Surname = surname;
            Name = name;
            SecondName = secondname;
            Phone = phone;
            Adress = adress;
            Birthdate = birthdate;
            Gender = gender;
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + SecondName;
        }
    }

    public class Employee
    {
        public int ID
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string SecondName
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public DateTime Birthdate
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string Adress
        {
            get;
            set;
        }

        public Employee()
        {
            ID = 0;
            Surname = "";
            Name = "";
            SecondName = "";
            Phone = "";
            Adress = "";
            Birthdate = new DateTime();
            Gender = "Male";
        }

        public Employee(int id, string surname, string name, string secondname, string phone, string adress, DateTime birthdate, string gender)
        {
            ID = id;
            Surname = surname;
            Name = name;
            SecondName = secondname;
            Phone = phone;
            Adress = adress;
            Birthdate = birthdate;
            Gender = gender;
        }

        public Employee(string surname, string name, string secondname, string phone, string adress, DateTime birthdate, string gender)
        {
            ID = 0;
            Surname = surname;
            Name = name;
            SecondName = secondname;
            Phone = phone;
            Adress = adress;
            Birthdate = birthdate;
            Gender = gender;
        }
    }

    public class Service
    {
        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public Service()
        {
            Title = "";
            Price = 0;
        }

        public Service(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public Service(int id, string title, double price)
        {
            ID = id;
            Title = title;
            Price = price;
        }
    }

    public class Specialization
    {
        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public Specialization()
        {
            Title = "";
        }

        public Specialization(string title)
        {
            Title = title;
        }

        public Specialization(int id, string title)
        {
            ID = id;
            Title = title;
        }
    }

    public class Analyse
    {
        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public Analyse()
        {
            Title = "";
            Price = 0;
        }

        public Analyse(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public Analyse(int id, string title, double price)
        {
            ID = id;
            Title = title;
            Price = price;
        }
    }

    [Serializable]
    public class Graph
    {
        public DateTime PnStart { get; set; }
        public DateTime PnEnd { get; set; }
        public DateTime VtStart { get; set; }
        public DateTime VtEnd { get; set; }
        public DateTime SrStart { get; set; }
        public DateTime SrEnd { get; set; }
        public DateTime ChStart { get; set; }
        public DateTime ChEnd { get; set; }
        public DateTime PtStart { get; set; }
        public DateTime PtEnd { get; set; }
        public DateTime SbStart { get; set; }
        public DateTime SbEnd { get; set; }
        public DateTime VsStart { get; set; }
        public DateTime VsEnd { get; set; }
        public int Interval { get; set; }
    }

    public class DoctorWithSpec: IComparable
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Otch { get; set; }
        public string Spec { get; set; }

        public DoctorWithSpec()
        {
            ID = 0;
            Surname = "";
            Name = "";
            Otch = "";
            Spec = "";
        }

        public DoctorWithSpec(string surname, string name, string otch, string spec)
        {
            ID = 0;
            Surname = surname;
            Name = name;
            Otch = otch;
            Spec = spec;
        }

        public DoctorWithSpec(int id, string surname, string name, string otch, string spec)
        {
            ID = id;
            Surname = surname;
            Name = name;
            Otch = otch;
            Spec = spec;
        }

        public override string ToString()
        {
            return String.Format("{0} | {1} {2} {3}", Spec, Surname, Name, Otch);
        }

        public int CompareTo(object obj)
        {
            DoctorWithSpec ds = obj as DoctorWithSpec;

            if (Spec.CompareTo(ds.Spec) == 1) return 1;
            else if (Spec.CompareTo(ds.Spec) == 0) return 0;
            else return -1;
        }
    }

    public class Day
    {
        public string Time { get; set; }
        public Reg Reg { get; set; }

        public Day()
        {
            Time = "10:00";
            Reg = new Reg();
        }
    }

    public class Reg
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public Client Client { get; set; }
        public DoctorWithSpec Doctor { get; set; } 
        public Service Service { get; set; }
        public bool PushUpdate { get; set; }
        public bool Paid { get; set; }

        public Reg()
        {
            ID = 0;
            Time = new DateTime();
            Client = new Client();
            Doctor = new DoctorWithSpec();
            Service = new Service();
            PushUpdate = false;
            Paid = false;
        }

        public override string ToString()
        {
            return Client.ToString();
        }
    }

    public class HistoryEntity
    {
        public List<Analyse> Analyzes
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }

        public string Client
        {
            get;
            set;
        }

        public string Doctor
        {
            get;
            set;
        }

        public string Diagnosis
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public string Curing
        {
            get;
            set;
        }

        public HistoryEntity()
        {
            Analyzes = new List<Analyse>();
            ID = 0;
            Time = new DateTime();
            Client = "";
            Doctor = "";
            Diagnosis = "";
            Details = "";
            Curing = "";
        }

        public HistoryEntity(int id, string client, string doctor, string diagnosis, string details, string curing, DateTime time, List<Analyse> an)
        {
            Analyzes = an;
            ID = id;
            Client = client;
            Doctor = doctor;
            Time = time;
            Diagnosis = diagnosis;
            Details = details;
            Curing = curing;
        }

        public double CostAnalyzes()
        {
            if (Analyzes != null && Analyzes.Count > 0)
            {
                return Analyzes.Sum((a) => { return a.Price; });
            }
            return 0;
        }

        public int CountAnalyzes()
        {
            if (Analyzes != null)
            {
                return Analyzes.Count;
            }
            return 0;
        }

        public string GetCorrectDate()
        {
            return Utils.GCTime(Time.Day) + "." + Utils.GCTime(Time.Month) + "." + Time.Year + " в " + Utils.GCTime(Time.Hour) + ":" + Utils.GCTime(Time.Minute);
        }
    }

    public class DoctorsSpec
    {
        public Graph Graph
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public int SpecID
        {
            get;
            set;
        }

        public DoctorsSpec()
        {
            ID = 0;
            SpecID = 0;
            EmployeeID = 0;
            Graph = new Graph();
        }

        public DoctorsSpec(int id, int e, int s, Graph g)
        {
            ID = id;
            EmployeeID = e;
            SpecID = s;
            Graph = g;
        }
    }

    public class User
    {
        public string Login
        {
            get;
            set;
        }

        public string MD5
        {
            get;
            set;
        }

        public int Access
        {
            get;
            set;
        }

        public User()
        {
            Login = "";
            MD5 = "";
            Access = -1;
        }

        public User(string login, string md5, int access)
        {
            Login = login;
            MD5 = md5;
            Access = access;
        }
    }
}
