using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using UserService.DTO;
using UserService.UserRepository;
using System.Collections.Generic;
using System.Linq;
using UserService.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json;
using MassTransit;
using MassTransit.Transports;
using System.Threading.Tasks;
using Common.Notification;

public class UserBasedServices : IUserBasedService
{
    private readonly IUserRepository _repository;
    private readonly IModel _channel;

    private readonly IPublishEndpoint _publishEndpoint;

    public UserBasedServices(IPublishEndpoint publishEndpoint, IUserRepository repository)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;

    }


    public async Task RegisterUser(UserDto user)
    {
        var message = new NotificationMessage
        {
            RecipientRole = user.RoleName,
            RecipientId = user.Id,
            Message = $"Hello {user.Username}, you are now registered as a {user.RoleName}.",
            Type = "Registration"
        };

        await _publishEndpoint.Publish(message);
        _repository.AddUser(user);
    }

    public UserDto AuthenticateUser(LoginDto login)
    {
        return _repository.ValidateUser(login.Username, login.Password);
    }

    public string GenerateJwtToken(UserDto user, string username)
    {
        var roleName = _repository.GetRoles().FirstOrDefault(r => r.Id == user.Id)?.RoleName ?? "Employee";
        var configuration = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json")
       .Build();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, roleName)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public UserDto GetUserById(int id)
    {
        return _repository.GetUserById(id);
    }

    public List<RoleMaster> GetRoles()
    {
        return _repository.GetRoles();
    }

}
