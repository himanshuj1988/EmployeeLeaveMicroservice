using System.Collections.Generic;
using System.Linq;
using UserService.Context;
using UserService.DTO;
using Common.Notification;

namespace UserService.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserDto user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public UserDto ValidateUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.IsActive && !u.IsDeleted);
        }

        public UserDto GetUserById(int id)
        {
            return _context.Users.Where(user => user.IsActive && !user.IsDeleted && user.Id == id).FirstOrDefault();
        }

        public List<RoleMaster> GetRoles()
        {
            return _context.Roles.Where(role => role.IsActive && !role.IsDeleted).ToList();
        }
    }
}
