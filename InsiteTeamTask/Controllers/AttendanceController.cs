using System;
using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendenceViewService _attendenceViewService;
        private readonly ILogger<AttendanceController> _logger;

        public AttendanceController(IAttendenceViewService attendenceViewService, ILogger<AttendanceController> logger)
        {
            _attendenceViewService = attendenceViewService;
            _logger = logger;
        }

        // GET api/values
        [HttpGet()]
        [Route("get/{gameNumber}/{seasonNumber}")]
        public ActionResult<AttendenceViewModel> Get(int gameNumber, int seasonNumber)
        {
            try
            {
                //Using a view service so the controller has minimal logic.
                var viewModel = _attendenceViewService.GetAttendence(gameNumber, seasonNumber);

                return Ok(viewModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while trying to retrieve game attendence");
                return StatusCode(500);
            }
        }

        [HttpGet("get/{productCode}")]
        public ActionResult<AttendenceViewModel> Get(string productCode)
        {
            try
            {
                //Using a view service so the controller has minimal logic.
                var viewModel = _attendenceViewService.GetAttendence(productCode);

                return Ok(viewModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while trying to retrieve game attendence");
                return StatusCode(500);
            }
        }
    }
}
