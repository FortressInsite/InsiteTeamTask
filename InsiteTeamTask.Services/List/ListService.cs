using System.Collections.Generic;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Repositories.Interfaces;

namespace InsiteTeamTask.Logic.List
{
    internal class ListService : IListService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IGamesRepository _gamesRepository;

        public ListService(IProductRepository productRepository, ISeasonRepository seasonRepository, IGamesRepository gamesRepository)
        {
            _productRepository = productRepository;
            _seasonRepository = seasonRepository;
            _gamesRepository = gamesRepository;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public IEnumerable<GameDto> GetAllGames()
        {
            return _gamesRepository.GetAllGames();
        }

        public IEnumerable<SeasonDto> GetAllSeasons()
        {
            return _seasonRepository.GetAllSeasons();
        }
    }
}