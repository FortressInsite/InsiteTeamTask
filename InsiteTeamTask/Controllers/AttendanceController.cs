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
        // GET api/values
        [HttpGet("{gameNumber}/{seasonNumber}/{productNumber}")]
        public ActionResult<IEnumerable<Attendance>> Get(int gameNumber, int seasonNumber, string productNumber)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListFor(gameNumber: gameNumber, seasonNumber: seasonNumber, productNumber: productNumber);

            return Ok(attendance);
        }

        [HttpGet("{gameNumber}/{seasonNumber}")]
        public ActionResult<IEnumerable<Attendance>> Get(int gameNumber, int seasonNumber)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListFor(gameNumber: gameNumber, seasonNumber: seasonNumber);

            return Ok(attendance);
        }
    }
}
