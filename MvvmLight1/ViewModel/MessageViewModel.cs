using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Data.SqlClient;
using MvvmLight1.Model;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Interactivity;
using MvvmLight1.View;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight1.ViewModel
{
    public class MessageViewModel:ViewModelBase
    {

        ObservableCollection<Person> people = new ObservableCollection<Person>();

        public ObservableCollection<Person> People
        {
            get { return people; }
            set
            {
                people = value;
                RaisePropertyChanged(() => People);
            }
        }
        public MessageViewModel()
        {
            change = new RelayCommand(getdata);
            Showdata1 = new RelayCommand<DataGrid>(showdata);
            Gotopage2 = new RelayCommand(gotopage2);
            Gotopage1 = new RelayCommand(gotopage1);
            //login = new RelayCommand(showlogin);
            this.People = Getdata.GetAllPeople();
            SqlConnection con = dbconnect.getcon();
            SqlCommand cmd = new SqlCommand("select * from mvvmtest where name='maki'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //p = new Person();
                this.p = new Person();
                p.Name = reader.GetString(0);
                p.Age = reader.GetInt32(1);
                p.Sex = reader.GetString(2);
                p.Content = reader.GetString(3);

            }
            con.Close();
        }
        private Person person;
        public Person p
        {
            get { return person; }
            set
            {
                person = value;
                RaisePropertyChanged(() => p);
            }
        }


        private Page _newpage;
        public Page Newpage
        {
            get { return _newpage; }
            set
            {
                _newpage = value;
                RaisePropertyChanged(() => Newpage);
            }
        }

        public RelayCommand Gotopage2
        {
            get;
            set;
        }
        public RelayCommand Gotopage1
        {
            get;
            set;
        }

        public RelayCommand change
        {
            get;
            set;
        }

        public RelayCommand<DataGrid> Showdata1
        {
            get;
            set;
        }

        public RelayCommand login
        {
            get;
            set;
        }

        /*private void showlogin()
        {
            Console.WriteLine(p.Loginname);
        }*/

        private void showdata(DataGrid dataGrid)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                Person peo = (Person)dataGrid.SelectedItems[0];
                //MessageBox.Show(peo.Name + "," + peo.Age + "+" + peo.Sex);
                Console.WriteLine(peo.Content);
            }
        }

        private void gotopage2()
        {
            Page2 p2 = new Page2();
            Newpage = p2;
        }
        private void gotopage1()
        {
            Page1 p1 = new Page1();
            Newpage = p1;
            Messenger.Default.Send<string>("传过来的", "aaa");
        }

        private void getdata()
        {
            SqlConnection con = dbconnect.getcon();
            SqlCommand cmd = new SqlCommand("select * from mvvmtest where name='nico'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p.Name = reader.GetString(0);
                p.Age = reader.GetInt32(1);
                p.Sex = reader.GetString(2);
                p.Content = reader.GetString(3);
            }
            con.Close();
        }
        
    }
}
