using System.Collections.Generic;
using System.Linq;
using InsiteTeamTask.LoggerService;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Internal;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        private ILoggerMessage _loggerMessage;

        public AttendanceController(IDataRepository dataRepository, ILoggerMessage loggerMessage)
        {
            _dataRepository = dataRepository;
            _loggerMessage = loggerMessage;
        }


        // GET api/values
        /// <summary>
        /// return attendance list  with prodId
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> GetProduct(string prodId)
        {
            var attendanceList = _dataRepository.GetAttendanceListForProduct(prodId);

            return Ok(attendanceList);
        }

        /// <summary>
        /// returns seasonId and gameId
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> GetGame(int gameId, int seasonId) 
        {
            var attendanceList = _dataRepository.GetAttendanceForGame(gameId, seasonId);

            return Ok(attendanceList);
        }
    }
}
