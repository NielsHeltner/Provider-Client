using IO.Swagger.Model;

namespace Provider.domain.users
{
    public interface IUserManager
    {

        User loggedInUser { get; set; }

        void LogOut();

    }
}