using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{
    [Route("api")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        // I created these endpoints so that the angular api service I created could load the needed data.

        [HttpGet]
        [Route("gameData")]
        public ActionResult<IEnumerable<Game>> GetGames()
        {
            var repo = new DataRepository();

            var attendance = repo.GetGames();

            return Ok(attendance);
        }

        [HttpGet]
        [Route("seasonData")]
        public ActionResult<IEnumerable<Season>> GetSeasons()
        {
            var repo = new DataRepository();

            var attendance = repo.GetSeasons();

            return Ok(attendance);
        }

        [HttpGet]
        [Route("productData")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var repo = new DataRepository();

            var attendance = repo.GetProducts();

            return Ok(attendance);
        }

        [HttpGet]
        [Route("{gameId}")]
        public ActionResult<IEnumerable<Attendance>> GetAttendanceByGame(int gameId)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListFor(gameId);

            return Ok(attendance);
        }

        [HttpGet]
        [Route("{gameId}/{seasonId}")]
        public ActionResult<IEnumerable<Attendance>> GetAttendanceByGameAndSeason(int gameId, int seasonId)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListFor(gameId, seasonId);

            return Ok(attendance);
        }

        [HttpGet]
        [Route("product/{productId}")]
        public ActionResult<IEnumerable<Attendance>> GetAttendanceByProduct(string productId)
        {
            var repo = new DataRepository();

            var attendance = repo.GetAttendanceListFor(productId);

            return Ok(attendance);
        }
    }
}
