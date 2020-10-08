using System.Collections.Generic;
using InsiteTeamTask.Data.DTOs;

namespace InsiteTeamTask.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetProductByGameNumberAndSeasonNumber(int gameNumber, int seasonNumber);
        ProductDto GetProductByCode(string code);

        IEnumerable<ProductDto> GetAllProducts();
    }
}