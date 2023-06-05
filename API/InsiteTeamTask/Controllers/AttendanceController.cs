using System.Collections.Generic;
using InsiteTeamTask.Services;
using InsiteTeamTask.Models;
using Microsoft.AspNetCore.Mvc;
using InsiteTeamTask.API.Extentions;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [AuthorizedUI]
    public class AttendanceController : ControllerBase
    {
        private readonly IDataService _service;

        // Constructor injection to inject the data service dependency
        public AttendanceController(IDataService service)
        {
            _service = service;
        }

        // GET: api/Attendance
        // Retrieves attendance for all products
        [HttpGet]
        public IActionResult GetAttendance()
        {
            var attendance = _service.GetAttendance();
            return Ok(attendance);
        }

        // GET: api/Attendance/{productCode}
        // Retrieves attendance for a specific product based on the provided product code
        [HttpGet]
        [Route("{productCode}")]
        public IActionResult GetAttendanceForProduct(string productCode)
        {
            var attendance = _service.GetAttendanceForProduct(productCode);
            return Ok(attendance);
        }

        // GET: api/Attendance/{seasonId}/{gameNumber}
        // Retrieves attendance for a specific game based on the provided season ID and game number
        [HttpGet]
        [Route("{seasonId}/{gameNumber}")]
        public IActionResult GetAttendanceForGame(int seasonId, int gameNumber)
        {
            var attendance = _service.GetAttendanceForGame(seasonId, gameNumber);
            return Ok(attendance);
        }
    }
}
