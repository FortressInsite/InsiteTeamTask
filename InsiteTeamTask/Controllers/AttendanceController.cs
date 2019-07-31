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
        public ActionResult<IEnumerable<Attendance>> GetByGame(int seasonId, int gameId)
        {
            if (seasonId <= 0)
                return BadRequest("Season Id not valid");
            if (gameId <= 0)
                return BadRequest("Game Id not valid");

            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListForGame(seasonId: seasonId, gameId: gameId);

            return Ok(attendance);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> GetByProduct(string productId)
        {

            if (string.IsNullOrWhiteSpace(productId))
                return BadRequest("Product Id not valid");

            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListForProduct(productId: productId);

            return Ok(attendance);
        }
    }
}
