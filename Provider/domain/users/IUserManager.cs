using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Provider.domain.users
{
    public interface IUserManager
    {

        User loggedInUser { get; set; }

        bool LogIn(string userName, string password);

        void LogOut();

    }
}