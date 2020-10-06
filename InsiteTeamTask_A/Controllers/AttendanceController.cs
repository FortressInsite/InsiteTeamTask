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
        //GET api/Values
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> Get()
        {

            var repo = new DataRepository();

            var attendance = repo.GetAll();

            return Ok(attendance);
           
        }


        
        [HttpGet("[action]/{seasonNumber}")]
        public ActionResult<IEnumerable<Attendance>> Season(int seasonNumber)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListBySeason(seasonNumber);

            return Ok(attendance);
        }

        // GET api/Attendance/ProductCode/MN319A
        [HttpGet("[action]/{productId}")]
        public ActionResult<IEnumerable<Attendance>> ProductCode(string productId)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListByProductCode(productId);

            return Ok(attendance);
        }

        [HttpGet("[action]/{gameId}")]
        public ActionResult<IEnumerable<Attendance>> Game(int gameId)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListByGameNumber(gameId);

            return Ok(attendance);
        }

      
        
    }
}
