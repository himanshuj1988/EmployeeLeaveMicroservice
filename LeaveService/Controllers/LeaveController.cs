using LeaveService.Dto;
using LeaveService.LeaveServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LeaveService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpPost("apply")]
        public IActionResult ApplyLeave([FromBody] LeaveDto leave)
        {
            var result = _leaveService.ApplyLeave(leave);
            if (!result.IsCompleted)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("decision")]
        [Authorize(Roles = "Manager")]
        public IActionResult ApproveOrReject(int userId, bool approved)
        {
            var result = _leaveService.ApproveOrRejectLeave(userId, approved);
            if (result.Id > 0) return NotFound();
            return Ok(result);
        }

        [HttpGet("report")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllLeaveBalances()
        {
            return Ok(_leaveService.GetLeaveReport());
        }
    }

}
