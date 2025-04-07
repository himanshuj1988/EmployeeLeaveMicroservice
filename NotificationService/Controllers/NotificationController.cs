using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Context;
using NotificationService.DTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace NotificationService.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationDbContext _context;


        public NotificationController(NotificationDbContext context)
        {
            _context = context;
        }

        [HttpPost("send")]
        public IActionResult SendNotification([FromBody] NotificationDto notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            Console.WriteLine($"[{notification.Type}] Notification to User {notification.UserId}: {notification.Message}");
            return Ok("Notification Sent and Saved");
        }

        [HttpGet("all")]
        public IActionResult GetAllNotifications()
        {
            return Ok(_context.Notifications.ToList());
        }
    }





}
