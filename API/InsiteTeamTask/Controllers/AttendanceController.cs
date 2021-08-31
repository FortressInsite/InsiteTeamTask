using System.Collections.Generic;
using InsiteTeamTask.Services;
using InsiteTeamTask.Models;
using Microsoft.AspNetCore.Mvc;
using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Controllers
{
    [Route("api/Attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IDataService _service;

        public AttendanceController(IDataService service)
        {
            _service = service;
        }

        [HttpGet("{productCode}/{seasonId}/{gameNumber}")]
        public IEnumerable<Attendance> Get(string productCode, int seasonId, int gameNumber)
        {
            if (productCode != "0")
            {
                return _service.GetAttendanceForProduct(productCode);
            }
            if (seasonId != -1 || gameNumber != -1)
            {
                return _service.GetAttendanceForGame(seasonId, gameNumber);
            }
            return _service.GetAttendance();
        }

        [HttpGet("Members")]
        public IEnumerable<Member> GetMembers()
        {
            return _service.GetMembers();
        }

        [HttpGet("Tickets")]
        public IEnumerable<Ticket> GetTickets()
        {
            return _service.GetTickets();
        }

        [HttpGet("Games")]
        public IEnumerable<Game> GetGames()
        {
            return _service.GetGames();
        }

        [HttpGet("Seasons")]
        public IEnumerable<Season> GetSeasons()
        {
            return _service.GetSeasons();
        }

        [HttpGet("ProductCodes")]
        public IEnumerable<string> GetProductCodes()
        {
            return _service.GetProductCodes();
        }
    }
}
