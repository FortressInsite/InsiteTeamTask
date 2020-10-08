using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Repositories.Interfaces;
using InsiteTeamTask.Logic.Attendence.Actions;

namespace InsiteTeamTask.Logic.Attendence
{
    class AttendenceService : IAttendenceService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAttendenceActionFactory _attendenceActionFactory;

        public AttendenceService(IProductRepository productRepository, IAttendenceActionFactory attendenceActionFactory)
        {
            _productRepository = productRepository;
            _attendenceActionFactory = attendenceActionFactory;
        }

        public AttendenceDto GetAttendenceForGameNumberAndSeasonNumber(int gameNumber, int seasonNumber)
        {
            var attendenceDto = new AttendenceDto();
            var productDtos = _productRepository.GetProductByGameNumberAndSeasonNumber(gameNumber, seasonNumber);

            //While this can be done in a single linq expression, that would close it for modification. Also make it harder to read.
            foreach (var productDto in productDtos)
            {
                attendenceDto = GetAttendenceFromProductDto(productDto, attendenceDto);
            }

            return attendenceDto;
        }

        public AttendenceDto GetAttendanceForProductCode(string productCode)
        {
            var attendenceDto = new AttendenceDto();
            var productDto = _productRepository.GetProductByCode(productCode);

            if (productDto != null)
            {
                attendenceDto = GetAttendenceFromProductDto(productDto, attendenceDto);
            }

            return attendenceDto;
        }

        private AttendenceDto GetAttendenceFromProductDto(ProductDto productDto, AttendenceDto attendenceDto)
        {
            //Instead of using a switch statement use a dictionary of actions that can easily be expanded
            attendenceDto = _attendenceActionFactory.GetAction(productDto.Type).DoAction(productDto, attendenceDto);

            return attendenceDto;
        }
    }
}
