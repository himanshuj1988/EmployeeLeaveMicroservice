using LeaveService.Dto;
using Microsoft.EntityFrameworkCore;

namespace LeaveService.Context
{
    public class LeaveDBContext : DbContext
    {
        public LeaveDBContext(DbContextOptions<LeaveDBContext> options) : base(options) { }
        public DbSet<LeaveDto> EmployeeLeaves { get; set; }
        public DbSet<LeaveStatusMaster> LeaveStatus { get; set; }
    }
}
