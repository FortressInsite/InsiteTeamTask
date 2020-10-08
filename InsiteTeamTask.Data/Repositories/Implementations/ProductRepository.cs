using System.Collections.Generic;
using AutoMapper;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Repositories.Interfaces;
using System.Linq;

namespace InsiteTeamTask.Data.Repositories.Implementations
{
    internal class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(IDataService dataService, IMapper mapper) : base(mapper, dataService)
        {
        }

        public IEnumerable<ProductDto> GetProductByGameNumberAndSeasonNumber(int gameNumber, int seasonNumber)
        {
            //Members dont belong to a single game, so will have a GameId of 0.
            var product = DataService.Products().Where(x => (x.GameId == gameNumber || x.GameId == 0) && x.SeasonId == seasonNumber);

            return Mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public ProductDto GetProductByCode(string code)
        {
            var product = DataService.Products().FirstOrDefault(x => x.Id == code);

            return product == null ? null : Mapper.Map<ProductDto>(product);
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return Mapper.Map<IEnumerable<ProductDto>>(DataService.Products());
        }
    }
}