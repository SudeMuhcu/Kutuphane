using Kutuphane.Context;
using Kutuphane.Models;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Services
{
    public class UserService : IUserService
    {
        private readonly LibraryContext _context;

        public UserService (LibraryContext context)
        {
            _context = context;
        }



        public void AddUser(AppUser user)
        {
            var existingUser = _context.AppUsers
                .FirstOrDefault(x => x.UserName == user.UserName);

            if (existingUser != null)
            {
                throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            _context.AppUsers.Add(user);
            _context.SaveChanges();
        }

        public AppUser? Login(UserRole role, string loginValue, string password)
        {
            AppUser? user;

            if (role == UserRole.User)
            {
                user = _context.AppUsers
                    .Include(x => x.Student)
                    .FirstOrDefault(x =>
                        x.Student != null &&
                        x.Student.SchoolNumber == loginValue);
            }
            else
            {
                user = _context.AppUsers
                    .FirstOrDefault(x => x.UserName == loginValue);
            }

            if (user == null)
            {
                return null;
            }

            if (user.Role != role)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            if (user.Student != null && !user.Student.Isactive)
            {
                return null;
            }

            return user;

        }
    }
}
