using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Services.List;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListViewService _listViewService;

        public ListController(IListViewService listViewService)
        {
            _listViewService = listViewService;
        }

        // GET
        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> Products()
        {
            return Ok(_listViewService.GetAllProducts());
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameViewModel>> Games()
        {
            return Ok(_listViewService.GetAllGames());
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeasonViewModel>> Seasons()
        {
            return Ok(_listViewService.GetAllSeasons());
        }
    }
}