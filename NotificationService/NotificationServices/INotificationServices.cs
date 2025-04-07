using NotificationService.DTO;
using System.Collections.Generic;

namespace NotificationService.NotificationRepository
{
    public interface INotificationServices
    {
        void AddNotification(NotificationDto notification);
        List<NotificationDto> GetAllNotifications();
    }
}
