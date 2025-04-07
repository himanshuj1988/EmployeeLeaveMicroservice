using System;

namespace UserService.DTO
{

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public RoleMaster RoleId { get; set; }
        public string RoleName { get; set; }
    }


    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RoleMaster
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }


   

}
