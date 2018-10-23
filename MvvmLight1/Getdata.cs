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
                people.Name = reader.GetString(1);
                people.Age = reader.GetInt32(2);
                people.Sex = reader.GetString(3);
                list.Add(people);
            }
            con.Close();
            return list;
        }
    }
}
