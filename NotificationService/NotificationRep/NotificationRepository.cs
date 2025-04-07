using NotificationService.Context;
using NotificationService.DTO;
using System.Collections.Generic;
using System.Linq;

namespace NotificationService.NotificationRep
{
    public class NotificationRepository
    {
        private readonly NotificationDbContext _context;

        public NotificationRepository(NotificationDbContext context)
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
