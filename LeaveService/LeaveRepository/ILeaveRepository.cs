using LeaveService.Dto;
using System.Collections.Generic;

namespace LeaveService.LeaveRepository
{
    public interface ILeaveRepository
    {
        void ApplyLeave(LeaveDto leave);
        LeaveDto GetLastLeaveByUser(int userId);
        IEnumerable<LeaveDto> GetAllLeaves();
    }

}
