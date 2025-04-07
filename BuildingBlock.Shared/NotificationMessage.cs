using System;

namespace Common.Notification
{
    public class NotificationMessage
    {
        public string RecipientRole { get; set; }
        public int RecipientId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}