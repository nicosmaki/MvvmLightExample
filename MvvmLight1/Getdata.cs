using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MvvmLight1.Model;
using System.Collections.ObjectModel;
namespace MvvmLight1
{
    public static class Getdata
    {
        public static ObservableCollection<Person> GetAllPeople()
        {
            ObservableCollection<Person> list = new ObservableCollection<Person>();
            SqlConnection con = dbconnect.getcon();
            SqlCommand cmd = new SqlCommand("select * from mvvmtest", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Person people = new Person();
                people.Name = reader.GetString(0);
                people.Age = reader.GetInt32(1);
                people.Sex = reader.GetString(2);
                list.Add(people);
            }
            con.Close();
            return list;
        }
    }
}
