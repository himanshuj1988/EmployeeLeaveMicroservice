using LeaveService.Dto;
using LeaveService.LeaveRepository;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Text;
using MassTransit;
using MassTransit.Transports;
using System.Threading.Tasks;
using Common.Notification;

namespace LeaveService.LeaveServices
{
    public class LeaveServ : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepo;
        private readonly IPublishEndpoint _publishEndpoint;


        public LeaveServ(ILeaveRepository leaveRepo, IPublishEndpoint publishEndpoint)
        {
            _leaveRepo = leaveRepo;

            _publishEndpoint = publishEndpoint;
        }

        public async Task<string> ApplyLeave(LeaveDto leave)
        {
            int maxLeaves = 10;
            int takenLeaves = _leaveRepo.GetAllLeaves().Count(l => l.UserId == leave.UserId);
            int requestedDays = (leave.ToDate - leave.FromDate).Days + 1;

            if ((takenLeaves + requestedDays) > maxLeaves)
                return "Leave balance exceeded";

            _leaveRepo.ApplyLeave(leave);

            var message = new NotificationMessage
            {
                RecipientRole = "Staff",
                RecipientId = leave.UserId,
                Message = $"Leave request submitted from {leave.FromDate:yyyy-MM-dd} to {leave.ToDate:yyyy-MM-dd}.",
                Type = "LeaveRequest"
            };

            await _publishEndpoint.Publish(message);

            return "Leave Submitted for Approval";
        }

        public async Task<string> ApproveOrRejectLeave(int userId, bool approved)
        {
            var leave = _leaveRepo.GetLastLeaveByUser(userId);
            if (leave == null) return "Leave not found";

            var status = approved ? "Approved" : "Rejected";

            var message = new NotificationMessage
            {
                RecipientRole = "Patient",
                RecipientId = leave.UserId,
                Message = $"Your leave request from {leave.FromDate:yyyy-MM-dd} to {leave.ToDate:yyyy-MM-dd} has been {status}.",
                Type = $"Leave{status}"
            };

            await _publishEndpoint.Publish(message);

            return $"Leave {status}";
        }

        public IEnumerable<object> GetLeaveReport()
        {
            throw new System.NotImplementedException();
        }

       
    }
}
