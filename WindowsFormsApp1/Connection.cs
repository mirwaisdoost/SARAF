using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace WindowsFormsApp1
{
    class Connection
    {
        public static string server="localhost";
        private static string database = "saraf";
        public static string port = "3306";
        private static string uid = "root";
        private static string pass = "";
        private static string ssl="none";
        public static MySqlConnection con;

        public static void open()
        {
            try
            {
                con = new MySqlConnection("server='" + server + "';Database='" + database + "';" +
                    "port='" + port + "';User Id='" + uid + "';password='" + pass + "';SslMode='" + ssl + "'; Character Set = utf8;");

                if (con.State == ConnectionState.Closed)
                    con.Open();
            }catch(Exception e)
            {
                e.Equals(MessageBox.Show("Remote Server Error!"));
            }
        }

        public static void close()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }catch(Exception e)
            {
                e.Equals(System.Windows.MessageBox.Show("Remote Server Error!"));
            }
        }

        public static void setServer(string Server, string Port)
        {
            server = Server;
            Port = port; 
        }
    }
}
