using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsiteTeamTask.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeasonController : ControllerBase
	{
		private IDataRepository _dataRepository;

		public SeasonController(IDataRepository dataRepository)
		{
			this._dataRepository = dataRepository;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<Season>> Get()
		{
			var seasons = _dataRepository.GetSeasons();
			return Ok(seasons);
		}
	}
}
