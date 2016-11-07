using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=tek-mmmi-db0a.tek.c.sdu.dk;Username=group_2;Password=MDI5NTli;Database=group_2_db");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM public.user";
            NpgsqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Console.WriteLine(read.GetString(0));
            }
            Console.ReadLine();
        }
    }
}
