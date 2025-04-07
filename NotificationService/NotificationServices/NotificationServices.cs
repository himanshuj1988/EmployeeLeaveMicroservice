using NotificationService.Context;
using NotificationService.DTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace NotificationService.NotificationRepository
{
    public class NotificationServices : INotificationServices
    {
        private readonly NotificationDbContext _context;


        public NotificationServices(NotificationDbContext context)
        {
            _context = context;


        }

        public void AddNotification(NotificationDto notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public List<NotificationDto> GetAllNotifications()
        {
            return _context.Notifications.ToList();
        }
    }
}
