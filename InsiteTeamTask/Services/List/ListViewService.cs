using System.Collections.Generic;
using AutoMapper;
using InsiteTeamTask.Logic.List;
using InsiteTeamTask.Models;

namespace InsiteTeamTask.Services.List
{
    public class ListViewService : IListViewService
    {
        private readonly IMapper _mapper;
        private readonly IListService _listService;

        public ListViewService(IMapper mapper, IListService listService)
        {
            _mapper = mapper;
            _listService = listService;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_listService.GetAllProducts());
        }

        public IEnumerable<GameViewModel> GetAllGames()
        {
            return _mapper.Map<IEnumerable<GameViewModel>>(_listService.GetAllGames());
        }

        public IEnumerable<SeasonViewModel> GetAllSeasons()
        {
            return _mapper.Map<IEnumerable<SeasonViewModel>>(_listService.GetAllSeasons());
        }
    }
}