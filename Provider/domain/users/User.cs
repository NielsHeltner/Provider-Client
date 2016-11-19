namespace Provider.domain.users
{
    public class User
    {
        public enum Rights
        {
            Provia,
            Supplier,
            Admin
        };

        public string userName { get; }

        public string password { get; }

        public Rights rights { get; }

        public User(string userName, string password, Rights rights)
        {
            this.userName = userName;
            this.password = password;
            this.rights = rights;
        }

    }
}
