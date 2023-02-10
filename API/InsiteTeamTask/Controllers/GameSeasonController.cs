using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InsiteTeamTask.API.Controllers
{
    [Route("api/GameSeason")]
    [ApiController]
    public class GameSeasonController : ControllerBase
    {
        private readonly IDataService service;
        public GameSeasonController(IDataService service)
        {
            this.service = service;

        }
        public List<GameSeasonView> Get()
        {
            return service.GetGameSeasonViews();
        }
    }
}
