using AutoMapper;
using InsiteTeamTask.Data.Configuration;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Repositories.Implementations;
using InsiteTeamTask.Data.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsiteTeamTask.Data.Test.Repositories
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private Mock<IDataService> _dataService;
        private IMapper _mapper;
        private IProductRepository _productRepository;

        [TestInitialize]
        public void IntializeTest()
        {
            _dataService = new Mock<IDataService>();
            _mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile(new DataMappingProfile()); }));
            _productRepository = new ProductRepository(_dataService.Object, _mapper);

            _dataService.Setup(x => x.Products()).Returns(new List<Product>()
            {
                new Product()
                {
                    Id = "MN319A", SeasonId = 12, ValidFrom = new DateTime(2012, 1, 18), Type = ProductType.Ticket, GameId = 3
                },
            });
        }

        [TestMethod]
        public void GetMembersByProductId_No_Product_Found_Invalid_Game_Returns_Null()
        {
            var gameNumber = 0;
            var seasonNumber = 12;

            _dataService.Setup(x => x.Products()).Returns(new List<Product>() {new Product()});

            var result = _productRepository.GetProductByGameNumberAndSeasonNumber(gameNumber, seasonNumber);

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetMembersByProductId_No_Product_Found_Invalid_Season_Returns_Null()
        {
            var gameNumber = 3;
            var seasonNumber = 1;

            _dataService.Setup(x => x.Products()).Returns(new List<Product>() { new Product() });

            var result = _productRepository.GetProductByGameNumberAndSeasonNumber(gameNumber, seasonNumber);

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetMembersByProductId_Products_With_GameNumber_Zero_Return_Independent_Of_GameNumber_Only_Season()
        {
            var gameNumber = 3;
            var seasonNumber = 0;

            _dataService.Setup(x => x.Products()).Returns(new List<Product>() { new Product() });

            var result = _productRepository.GetProductByGameNumberAndSeasonNumber(gameNumber, seasonNumber);

            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public void GetMembersByProductId_Products_Found_Returns_List_ProductDto()
        {
            var expectedProductDto = new List<ProductDto>
            {
                new ProductDto
                    {Id = "MN319A", SeasonId = 12, ValidFrom = new DateTime(2012, 1, 18), Type = ProductType.Ticket, GameId = 3}
            };

            var gameNumber = 3;
            var seasonNumber = 12;

            var result = _productRepository.GetProductByGameNumberAndSeasonNumber(gameNumber, seasonNumber).ToList();

            CollectionAssert.AreEqual(expectedProductDto, result);
        }

        [TestMethod]
        public void GetByProductCode_No_ProductFound_Returns_Null()
        {
            var code = "123";
            
            var result = _productRepository.GetProductByCode(code);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByProductCode_ProductFound_Returns_ProductDto()
        {
            var expectedProductDto = new ProductDto() { Id = "MN319A", SeasonId = 12, ValidFrom = new DateTime(2012, 1, 18), Type = ProductType.Ticket, GameId = 3 };
            var productCode = "MN319A";

            var result = _productRepository.GetProductByCode(productCode);

            Assert.AreEqual(expectedProductDto, result);
        }

        [TestMethod]
        public void GetByProductCode_Product_Code_CaseSensetive_Returns_Null()
        {
            var code = "mN319A";

            var result = _productRepository.GetProductByCode(code);

            Assert.IsNull(result);
        }
    }
}