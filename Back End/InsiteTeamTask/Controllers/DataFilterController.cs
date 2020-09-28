using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFilterController : ControllerBase
    {
        private readonly DataFilterService _dataFilterservice;

        public DataFilterController(DataFilterService dataFilterService)
        {
            _dataFilterservice = dataFilterService;
        }

        [HttpGet("seasons")]
        public ActionResult<IEnumerable<int>> GetAllSeasons()
        {
            try
            {
                List<int> seasons = _dataFilterservice.GetAllSeasonNumbers();
                return Ok(seasons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("games")]
        public ActionResult<IEnumerable<int>> GetAllGames()
        {
            try
            {
                List<int> games = _dataFilterservice.GetAllGameNumbers();
                return Ok(games);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<string>> GetAllProducts()
        {
            try
            {
                List<string> products = _dataFilterservice.GetAllProductIds();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
