using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InsiteTeamTask.Data.Configuration;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Repositories.Implementations;
using InsiteTeamTask.Data.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InsiteTeamTask.Data.Test.Repositories
{
    [TestClass]
    public class TicketRepositoryTest
    {
        private Mock<IDataService> _dataService;
        private IMapper _mapper;
        private ITicketRepository _ticketRepository;

        [TestInitialize]
        public void IntializeTest()
        {
            _dataService = new Mock<IDataService>();
            _dataService.Setup(x => x.Tickets()).Returns(new List<Ticket>() {new Ticket() {ProductId = "IT20"}});
            _mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile(new DataMappingProfile()); }));
            _ticketRepository = new TicketRepository(_mapper, _dataService.Object);
        }

        [TestMethod]
        public void GetMembersByProductId_No_Member_Found_Returns_Empty_List()
        {
            var productId = "";

            var result = _ticketRepository.GetTicketsByProductId(productId);

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetMembersByProductId_Products_Found_Returns_MemberDto_List()
        {
            var productId = "IT20";

            var result = _ticketRepository.GetTicketsByProductId(productId);

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetMembersByProductId_Case_Sensitive_Product_Id_Returns_Empty_List()
        {
            var productId = "it20";

            var result = _ticketRepository.GetTicketsByProductId(productId);

            Assert.IsFalse(result.Any());
        }
    }
}