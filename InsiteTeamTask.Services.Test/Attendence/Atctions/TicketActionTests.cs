using System.Collections.Generic;
using System.Linq;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Repositories.Interfaces;
using InsiteTeamTask.Logic.Attendence.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InsiteTeamTask.Services.Test.Attendence.Atctions
{
    public class TicketActionTests
    {
        private Mock<ITicketRepository> _mockTicektsRepository;
        private TicketAction _ticketAction;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTicektsRepository = new Mock<ITicketRepository>();
            _ticketAction = new TicketAction(_mockTicektsRepository.Object);
        }

        [TestMethod]
        public void DoAction_Tickets_Found_Tickets_List_Updated()
        {
            var productId = "";
            _mockTicektsRepository.Setup(x => x.GetTicketsByProductId(productId)).Returns(new List<TicketDto>() { new TicketDto() });
            var productDto = new ProductDto() { Id = productId };
            var attendenceDto = new AttendenceDto();

            var result = _ticketAction.DoAction(productDto, attendenceDto);

            Assert.IsTrue(attendenceDto.Tickets.Any());
        }

        [TestMethod]
        public void DoAction_No_Tickets_Found_Tickets_List_Updated()
        {
            var productId = "";
            _mockTicektsRepository.Setup(x => x.GetTicketsByProductId(productId)).Returns(new List<TicketDto>());
            var productDto = new ProductDto() { Id = productId };
            var attendenceDto = new AttendenceDto();

            var result = _ticketAction.DoAction(productDto, attendenceDto);

            Assert.IsFalse(attendenceDto.Tickets.Any());
        }
    }
}