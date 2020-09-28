using System;
using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET api/values
        [HttpGet("season/{seasonNumber}/game/{gameNumber}")]
        public ActionResult<IEnumerable<Attendance>> GetBySeasonAndGame(int seasonNumber, int gameNumber)
        {
            try
            {
                List<Attendance> attendance = _attendanceService.GetAttendanceListFor(seasonNumber, gameNumber);
                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{productId}")]
        public ActionResult<IEnumerable<Attendance>> GetByProduct(string productId)
        {
            try
            {
                List<Attendance> attendance = _attendanceService.GetAttendanceListFor(productId);
                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
