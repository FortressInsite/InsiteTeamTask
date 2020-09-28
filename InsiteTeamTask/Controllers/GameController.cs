using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IDataRepository _dataRepository;

        public GameController(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
			var games = _dataRepository.GetGames();
            return Ok(games);
        }
    }
}
