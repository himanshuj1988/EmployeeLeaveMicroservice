using LeaveService.Context;
using LeaveService.Dto;
using System.Collections.Generic;
using System.Linq;

namespace LeaveService.LeaveRepository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly LeaveDBContext _context;
        public LeaveRepository(LeaveDBContext context)
        {
            _context = context;
        }
        public void ApplyLeave(LeaveDto leave)
        {
            _context.EmployeeLeaves.Add(leave);
            _context.SaveChanges();
        }
        public LeaveDto GetLastLeaveByUser(int userId)
        {
            return _context.EmployeeLeaves.Where(l => l.UserId == userId).OrderByDescending(l => l.Id).FirstOrDefault();
        }
        public IEnumerable<LeaveDto> GetAllLeaves()
        {
            return _context.EmployeeLeaves.ToList();
        }
    }
}
