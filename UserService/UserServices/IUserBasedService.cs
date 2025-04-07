using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.DTO;

namespace UserService.UserServices
{
    public interface IUserBasedService
    {
        Task RegisterUser(UserDto user);
        UserDto AuthenticateUser(LoginDto login);
        string GenerateJwtToken(UserDto user, string username);
        UserDto GetUserById(int id);
        List<RoleMaster> GetRoles();
    }
}
