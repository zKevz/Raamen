using Raamen.Model;
using Raamen.Repository;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Raamen.Controller
{
    public class UserController
    {
        public static string ValidateLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "Username or password cannot be empty!";
            }

            if (UserRepository.GetUserByNamePassword(username, password) == null)
            {
                return "Username or password is wrong!";
            }

            return "Success!";
        }

        public static string ValidateRegister(string username, string password, string confirmationPassword, string email, string gender)
        {
            if (username.Length < 5 || username.Length > 15 || username.Any(x => !char.IsLetter(x) && x != ' '))
            {
                return "Username must be between 5 and 15 and alphabet with space only.";
            }

            if (password != confirmationPassword)
            {
                return "Password must match with confirmation password";
            }

            if (!email.EndsWith(".com"))
            {
                return "Email must ends with .com";
            }

            if (string.IsNullOrEmpty(gender))
            {
                return "Gender must be chosen";
            }

            if (UserRepository.GetUserByName(username) != null)
            {
                return "Username already exists!";
            }

            return "Success!";
        }

        public static string ValidateUpdate(string username, string oldUsername, string password, string oldPassword, string email, string gender)
        {
            if (username.Length < 5 || username.Length > 15 || username.Any(x => !char.IsLetter(x) && x != ' '))
            {
                return "Username must be between 5 and 15 and alphabet with space only.";
            }

            if (password != oldPassword)
            {
                return "Password must match with current password";
            }

            if (!email.EndsWith(".com"))
            {
                return "Email must ends with .com";
            }

            if (string.IsNullOrEmpty(gender))
            {
                return "Gender must be chosen";
            }

            if (username != oldUsername && UserRepository.GetUserByName(username) != null)
            {
                return "Username already exists!";
            }

            return "Success!";
        }

        public static User CheckSessionOrCookie(HttpSessionState session, HttpRequest request)
        {
            if (session["User"] != null)
            {
                return session["User"] as User;
            }

            if (request.Cookies["Cookie_Username"] != null && request.Cookies["Cookie_Password"] != null)
            {
                var username = request.Cookies["Cookie_Username"].Value;
                var password = request.Cookies["Cookie_Password"].Value;

                var user = UserRepository.GetUserByNamePassword(username, password);
                if (!(user is null))
                {
                    session["User"] = user;
                }
            }

            return null;
        }
    }
}