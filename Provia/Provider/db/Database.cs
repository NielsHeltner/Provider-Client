using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Provider.domain.page;

namespace Provider.db
{
    public class Database : IDatabase
    {
        private static IDatabase _instance;
        private NpgsqlCommand cmd = new NpgsqlCommand();

        public static IDatabase instance
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

        private void GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=tek-mmmi-db0a.tek.c.sdu.dk;Username=group_2;Password=MDI5NTli;Database=group_2_db");
            conn.Open();
            cmd.Connection = conn;
        }

        public bool GetLogin(string username, string password)
        {
            GetConnection();

            cmd.CommandText = "SELECT * FROM public.user WHERE username='"+username+"' AND password='"+password+"' AND rights=1";
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
        }

        public List<Page> GetSuppliers()
        {
            GetConnection();
            cmd.CommandText = "SELECT * FROM public.user WHERE rights=2";
            NpgsqlDataReader read = null;

            List<Page> pageList = new List<Page>();
            try
            {
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    pageList.Add(new Page(new domain.users.Supplier(read.GetString(0), read.GetString(1))));
                }
            } catch(PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return pageList;
        }

        public List<Product> GetProducts(string supplier)
        {
            GetConnection();
            cmd.CommandText = "SELECT " +
                "public.product.id, public.product.\"productName\", public.product.description, public.product.price, public.product.packaging, " +
                "public.product.\"chemicalName\", public.product.density, public.product.\"deliveryTime\" " +
                "FROM public.product " +
                "INNER JOIN public.pageproducts ON public.product.id = public.pageproducts.product WHERE " +
                "public.pageproducts.page='" + supplier + "'";

            NpgsqlDataReader reader = null;
            List<Product> productList = new List<Product>();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //System.Diagnostics.Debug.WriteLine(reader.GetInt32(0));
                    //System.Diagnostics.Debug.WriteLine(reader.GetString(1));
                    productList.Add(new Product(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetDouble(3),reader.GetString(4), reader.GetString(5), reader.GetDouble(6)));
                }
            } catch (PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return productList;
        }
    }
}
