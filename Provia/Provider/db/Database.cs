using System;
using System.Collections.Generic;
using Npgsql;
using Provider.domain.page;
using Provider.domain.bulletinboard;
using Provider.domain.users;

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
        }

        private Database() { }

        private void GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=tek-mmmi-db0a.tek.c.sdu.dk;Username=group_2;Password=MDI5NTli;Database=group_2_db");
            conn.Open(); // TODO: burde overveje en try-catch her, da der noglegange opstår exceptions
            cmd.Connection = conn;
        }

        public User GetLogin(string username, string password)
        {
            GetConnection();

            cmd.CommandText = "SELECT * FROM public.user WHERE username='" + username + "' AND password='" + password + "'";
            User user = null;
            try
            {
                NpgsqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    User.Rights rights;
                    switch (read.GetString(2))
                    {
                        case "Provia":
                            rights = User.Rights.Provia;
                            break;
                        case "Supplier":
                            rights = User.Rights.Supplier;
                            break;
                        case "Admin":
                            rights = User.Rights.Admin;
                            break;
                        default:
                            rights = default(User.Rights);
                            break;
                    }
                    user = new User(read.GetString(0), read.GetString(1), rights);
                }
            }
            catch(PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return user;
        }

        public List<Page> GetSuppliers()
        {
            GetConnection();
            cmd.CommandText = "SELECT public.user.username, public.note.text, public.note.date FROM public.user " +
                                "LEFT JOIN public.note ON public.user.username = public.note.supplier WHERE public.user.rights=2";
            List<Page> pageList = new List<Page>();
            try
            {
                NpgsqlDataReader read = cmd.ExecuteReader();
                Page page;
                while (read.Read())
                {
                    if(read.IsDBNull(1) && read.IsDBNull(2))
                    {
                        page = new Page(read.GetString(0));
                    }
                    else
                    {
                        page = new Page(read.GetString(0), new Note(read.GetString(1), read.GetDateTime(2)));

                    }
                    pageList.Add(page);
                }
            }
            catch (PostgresException e)
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
            List<Product> productList = new List<Product>();
            try
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productList.Add(new Product(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetDouble(3),reader.GetString(4), reader.GetString(5), reader.GetDouble(6)));
                }
            }
            catch (PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return productList;
        }

        public void AddNote(string supplierName, Note note)
        {
            GetConnection();
            cmd.CommandText = "INSERT INTO public.note(supplier, text, date) " + 
                                "VALUES('" + supplierName + "', '" + note.text + "', '" + note.creationDate + "');";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public void UpdateNote(string supplierName, Note note)
        {
            GetConnection();
            cmd.CommandText = "UPDATE public.note SET text = '" + note.text + "', date = '" + DateTime.Today + 
                                "' WHERE public.note.supplier = '" + supplierName + "';";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public int AddPost(string owner, Post post)
        {
            GetConnection();
            cmd.CommandText = "INSERT INTO public.post(username, type, text, \"creationDate\", title) " +
                                "VALUES('" + owner + "', '" + post.type.ToString() + "', '" + post.description + "', '" + post.creationDate + "', '" + post.title + "') " + 
                                "RETURNING id;";
            int id = 0;
            try
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            catch (PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return id;
        }

        public void UpdatePost(string owner, Post post)
        {
            GetConnection();
            cmd.CommandText = "UPDATE public.post SET text = '" + post.description + "', title = '" + post.title + "' WHERE id = " + post.id + ";";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public void DeletePost(Post post)
        {
            GetConnection();
            cmd.CommandText = "DELETE FROM public.post WHERE id = " + post.id + ";";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public List<Post> GetPosts()
        {
            GetConnection();
            cmd.CommandText = "SELECT * FROM public.post";
            List<Post> postList = new List<Post>();
            try
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Post.Types type;
                    switch(reader.GetString(4))
                    {
                        case "Warning":
                            type = Post.Types.Warning;
                            break;
                        case "Request":
                            type = Post.Types.Request;
                            break;
                        case "Offer":
                            type = Post.Types.Offer;
                            break;
                        default:
                            type = Post.Types.NotAvailabe;
                            break;
                    }
                    postList.Add(new Post(reader.GetString(0), reader.GetString(3), reader.GetString(1), type, reader.GetDateTime(2), reader.GetInt32(5)));
                }
            }
            catch (PostgresException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return postList;
        }
    }
}
