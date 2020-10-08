using System.Collections.Generic;
using InsiteTeamTask.Data.DTOs;

namespace InsiteTeamTask.Logic.List
{
    public interface IListService
    {
        IEnumerable<ProductDto> GetAllProducts();
        IEnumerable<GameDto> GetAllGames();
        IEnumerable<SeasonDto> GetAllSeasons();
    }
}