using System.Collections.Generic;
using UserService.DTO;

namespace UserService.UserRepository
{
    public interface IUserRepository
    {
        void AddUser(UserDto user);
        UserDto ValidateUser(string username, string password);
        UserDto GetUserById(int id);
        List<RoleMaster> GetRoles();
    }
}

