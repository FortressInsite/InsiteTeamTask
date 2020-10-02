using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: /<controller>/
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            var repo = new DataRepository();

            var games = repo.GetGames();

            return Ok(games);
        }
    }
}
