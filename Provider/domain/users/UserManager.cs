using System.Security.Cryptography;
using System.Text;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Provider.domain.users
{
    public class UserManager : IUserManager
    {
        public User loggedInUser { get; set; }

        /// <summary>
        /// Skal logge brugeren ind. Kontrollerer først med Validate() metoden, som returnerer en bruger. 
        /// Den bruger bliver sat til loggedInUser, og så indlæses alle leverandører og opslag.
        /// </summary>
        /// <param name="userName">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns> If the user gets validated the user will be set as the logged in user
        /// and the boolean returns true. If the user is not validated, the boolean returns false. 
        /// </returns>
        public bool LogIn(string userName, string password, ControllerApi api)
        {
            User user = api.Validate(userName, password);
            if (user != null)
            {
                loggedInUser = user;
                return true;
            }
            return false;
        }

        /// <summary>
        /// The logged in user is being set to null, meaning the user will be logged out. 
        /// </summary>
        public void LogOut()
        {
            loggedInUser = null;
        }

        public byte[] GetHashedPassword(string password)
        {
            HashAlgorithm algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

    }
}
