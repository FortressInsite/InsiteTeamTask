using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> GetByGame([FromQuery]int seasonId, [FromQuery]int gameId)
        {
            // Check valid arguments
            if (seasonId <= 0)
                return BadRequest("Season Id not valid");
            if (gameId <= 0)
                return BadRequest("Game Id not valid");

            var repo = new DataRepository();

            // Get and return data with 200 code
            var attendance = repo.GetAttendanceListForGame(seasonId: seasonId, gameId: gameId);

            return Ok(attendance);
        }

        [HttpGet("product")]
        public ActionResult<IEnumerable<Attendance>> GetByProduct([FromQuery]string productId)
        {

            if (string.IsNullOrWhiteSpace(productId))
                return BadRequest("Product Id not valid");

            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListForProduct(productId: productId);

            return Ok(attendance);
        }
    }
}
