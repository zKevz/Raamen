using Raamen.Model;
using Raamen.Repository;

namespace Raamen.Handler
{
    public static class UserHandler
    {
        public static void UpdateUser(User user, string email, string gender, string username)
        {
            user.Email = email;
            user.Gender = gender;
            user.Username = username;

            UserRepository.SaveChanges();
        }
    }
}