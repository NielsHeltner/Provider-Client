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

            cmd.CommandText = "SELECT " +
                "public.product.id, public.product.\"productName\", public.product.description, public.product.price, public.product.packaging, " +
                "public.product.\"chemicalName\", public.product.density, public.product.\"deliveryTime\" " +
                "FROM public.product " +
                "INNER JOIN public.pageproducts ON public.product.id = public.pageproducts.product";
            NpgsqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Console.WriteLine(read.GetString(4));
            }
            Console.ReadLine();
        }
    }
}
