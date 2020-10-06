using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsiteTeamTask_A.Models;
using InsiteTeamTask_A.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsiteTeamTask_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> Get()
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListByProductCode("IT49");

            return Ok(attendance);
        }
    }
}
