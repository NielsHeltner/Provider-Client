namespace Provider.domain.users
{
    public abstract class AbstractUser
    {
        public string userName { get; private set; }

        public string password { get; private set; }

        protected AbstractUser(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public int getRights()
        {
            return 1;
        }

    }
}
