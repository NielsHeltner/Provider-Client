using System;
using System.Security.Cryptography;
using System.Text;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Provider.domain.users
{
    public class UserManager : IUserManager
    {
        public User loggedInUser { get; set; }
        private UsermanagerApi usermanagerApi;

        public UserManager()
        {
            usermanagerApi = new UsermanagerApi("http://tek-sb3-glo0a.tek.sdu.dk:16832");
        }

        /// <summary>
        /// Skal logge brugeren ind. Kontrollerer først med Validate() metoden, som returnerer en bruger. 
        /// Den bruger bliver sat til loggedInUser, og så indlæses alle leverandører og opslag.
        /// </summary>
        /// <param name="userName">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns> If the user gets validated the user will be set as the logged in user
        /// and the boolean returns true. If the user is not validated, the boolean returns false. 
        /// </returns>
        public bool LogIn(string userName, string password)
        {
            User user = usermanagerApi.Validate(userName, password);
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

        private byte[] GetHash(string password)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public string GetHashedPassword(string password)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte b in GetHash(password))
            {
                builder.Append(b.ToString("X2"));
            }
            return builder.ToString();
        }

    }
}
