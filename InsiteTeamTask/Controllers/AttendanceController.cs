using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private IDataRepository _dataRepository;

        public AttendanceController(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> Get(string productId, int? seasonId, int? gameId)
        {
            if (productId == null && (seasonId == null || gameId == null))
            {
                return BadRequest("Requires either productId or both seasonId and gameId");
            }

            if (productId == null)
            {
                var product = _dataRepository.GetProducts().Find(p => p.SeasonId == seasonId && p.GameId == gameId);
                if (product == null)
                {
                    return NotFound();
                }
				productId = product.Id;
            }

            var attendance = _dataRepository.GetAttendanceListFor(productId);

            return Ok(attendance);
        }
    }
}
