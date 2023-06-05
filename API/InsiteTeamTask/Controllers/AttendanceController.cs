using System.Collections.Generic;
using InsiteTeamTask.Services;
using InsiteTeamTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IDataService _service;
        public AttendanceController(IDataService service)
        {
            _service = service;
        }

        [HttpGet]
        
        public IActionResult GetAttendance()
        {
            var attendance = _service.GetAttendance();
            return Ok(attendance);
        }

        [HttpGet]
        [Route("{productCode}")]
        public IActionResult GetAttendanceForProduct(string productCode)
        {
            var attendance = _service.GetAttendanceForProduct(productCode);
            return Ok(attendance);
        }

        [HttpGet]
        [Route("{seasonId}/{gameNumber}")]
        public IActionResult GetAttendanceForGame(int seasonId, int gameNumber)
        {
            var attendance = _service.GetAttendanceForGame(seasonId, gameNumber);
            return Ok(attendance);
        }
    }
}
