using System.Collections.Generic;
using InsiteTeamTask.Services;
using InsiteTeamTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace InsiteTeamTask.Controllers
{
    [Route("api/Attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IDataService service;
        public AttendanceController(IDataService service)
        {
            this.service = service;
        
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var attendance = service.GetAttendance();
                return Ok(attendance);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("{seasonId}/{gameId}")]
        public IActionResult Get([FromRoute] int seasonId,int gameId)
        {
            try
            {
                var attendance = service.GetAttendanceForGame(seasonId, gameId);
                return Ok(attendance);
            }
            catch(Exception ex) 
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("{productCode}")]
        public IActionResult Get([FromRoute]string productCode) 
        {
            try
            {
                var attendance = service.GetAttendanceForProduct(productCode);
                return Ok(attendance);
            }
            catch(Exception ex) 
            {
                return BadRequest(); 
            }
            
        }
    }
}
