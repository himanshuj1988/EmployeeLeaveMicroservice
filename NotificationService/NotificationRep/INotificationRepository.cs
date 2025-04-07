using NotificationService.DTO;
using System.Collections.Generic;

namespace NotificationService.NotificationRep
{
    public interface INotificationRepository
    {
        void AddNotification(NotificationDto notification);
        List<NotificationDto> GetAllNotifications();
    }
}
