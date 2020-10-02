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
    public class SeasonController : ControllerBase
    {
        // GET: /<controller>/
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Season>> Get()
        {
            var repo = new DataRepository();

            var seasons = repo.GetSeasons(3);

            return Ok(seasons);
        }
    }
}
