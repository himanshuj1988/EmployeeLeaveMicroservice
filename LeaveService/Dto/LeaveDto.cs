using System;

namespace LeaveService.Dto
{
    public class LeaveDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public int LeaveStatusId { get; set; }
        public int NotificationTypeId { get; set; }
    }

    public class LeaveStatusMaster
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }

    public class NotificationTypeMaster
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }


   

}
