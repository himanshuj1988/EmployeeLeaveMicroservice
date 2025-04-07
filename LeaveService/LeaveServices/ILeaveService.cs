using LeaveService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveService.LeaveServices
{
    public interface ILeaveService
    {
        Task<string> ApplyLeave(LeaveDto leave);
        //string ApproveOrRejectLeave(int userId, bool approved);
        IEnumerable<object> GetLeaveReport();

        Task<string> ApproveOrRejectLeave(int userId, bool approved);

    }
}
