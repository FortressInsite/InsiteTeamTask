using System.Collections.Generic;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Models;

namespace InsiteTeamTask.Services.List
{
    public interface IListViewService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        IEnumerable<GameViewModel> GetAllGames();
        IEnumerable<SeasonViewModel> GetAllSeasons();
    }
}