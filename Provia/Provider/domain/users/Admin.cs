namespace Provider.domain.users
{
    public class Admin : AbstractUser
    {
        public Admin(string userName, string password) : base(userName, password)
        {
        }
    }
}
