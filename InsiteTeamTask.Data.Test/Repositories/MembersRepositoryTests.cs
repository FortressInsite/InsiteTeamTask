using AutoMapper;
using InsiteTeamTask.Data.Configuration;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Repositories.Implementations;
using InsiteTeamTask.Data.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace InsiteTeamTask.Data.Test.Repositories
{
    [TestClass]
    public class MembersRepositoryTests
    {
        private Mock<IDataService> _dataService;
        private IMapper _mapper;
        private IMembersRepository _membersRepository;

        [TestInitialize]
        public void IntializeTest()
        {
            _dataService = new Mock<IDataService>();
            _dataService.Setup(x => x.Members()).Returns(new List<Member>() {new Member() {ProductId = "IT20"}});
            _mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile(new DataMappingProfile()); }));
            _membersRepository = new MembersRepository(_mapper, _dataService.Object);
        }

        [TestMethod]
        public void GetMembersByProductId_No_Member_Found_Returns_Null()
        {
            var productId = "";

            var result = _membersRepository.GetMembersByProductId(productId);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMembersByProductId_Products_Found_Returns_MemberDto()
        {
            var productId = "IT20";

            var result = _membersRepository.GetMembersByProductId(productId);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetMembersByProductId_Case_Sensitive_Product_Id_Returns_Empty_Null()
        {
            var productId = "it20";

            var result = _membersRepository.GetMembersByProductId(productId);

            Assert.IsNull(result);
        }
    }
}