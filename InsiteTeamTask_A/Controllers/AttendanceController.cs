using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsiteTeamTask_A.Models;
using InsiteTeamTask_A.Repositories;
using InsiteTeamTask_A.Filter;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsiteTeamTask_A.Controllers
{
    [ApiKeyAuth]
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


        
        [HttpGet("[action]/{seasonNumber}/{gameNumber}")]
        public ActionResult<IEnumerable<Attendance>> SeasonAndGame(int seasonNumber, int gameNumber)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListBySeasonAndGame(seasonNumber, gameNumber);

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


      
        
    }
}
