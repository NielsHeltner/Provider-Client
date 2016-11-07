using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Provider.db
{
    class Database
    {
        private static Database _instance;

        public static Database instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Database();
                }
                return _instance;
            }
            private set
            {

            }
        }

        public bool GetLogin(string username, string password)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=tek-mmmi-db0a.tek.c.sdu.dk;Username=group_2;Password=MDI5NTli;Database=group_2_db");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM public.user WHERE username='"+username+"' AND password='"+password+"'";
            NpgsqlDataReader read = null;
            try
            {
                read = cmd.ExecuteReader();
            }
            catch(PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return read.HasRows;
            /*while (read.Read())
            {
                Console.WriteLine(read.GetString(1));
            }*/
        }
    }
}
