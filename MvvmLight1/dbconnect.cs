
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MvvmLight1
{
    public static class dbconnect
    {
        public static SqlConnection getcon()
        {
            string str = "server=.;database=backsys;uid=sa;pwd=slm125hl";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }
    }
}