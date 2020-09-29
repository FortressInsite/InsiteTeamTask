using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{
    [Route("api/values")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> Get()
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListFor(gameNumber: 3);

            return Ok(attendance);
        }
    }
}
