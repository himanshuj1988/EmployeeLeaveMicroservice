using System;

namespace NotificationService.DTO
{
    public class NotificationDto
    {
         
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime SentDate { get; set; } = DateTime.Now;
    }


   

}
