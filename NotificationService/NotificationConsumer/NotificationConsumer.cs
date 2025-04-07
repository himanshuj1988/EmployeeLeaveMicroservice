using MassTransit;
using Microsoft.EntityFrameworkCore;
using NotificationService.Context;
using NotificationService.DTO;
using System.Threading.Tasks;
using System;
using Common.Notification;

namespace NotificationService.NotificationConsumer
{
    public class NotificationConsumer : IConsumer<NotificationMessage>
    {
        private readonly NotificationDbContext _context;

        public NotificationConsumer(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<NotificationMessage> context)
        {
            var msg = context.Message;

            _context.Notifications.Add(new NotificationDto
            {
                UserId = msg.RecipientId,
                Message = msg.Message,
                Type = msg.Type,
                SentDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            Console.WriteLine($"[NOTIFICATION] To {msg.RecipientRole} ({msg.RecipientId}): {msg.Message}");
        }
    }
}
