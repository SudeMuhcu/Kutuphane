using Kutuphane.Models;

namespace Kutuphane.Services
{
    public interface IUserService
    {
        AppUser? Login(UserRole role, string loginValue, string password);

        void AddUser(AppUser user);
    }
}
