using System.Linq;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Repositories.Interfaces;
using InsiteTeamTask.Logic.Attendence.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InsiteTeamTask.Services.Test.Attendence.Atctions
{
    [TestClass]
    public class MemberActionTests
    {
        private Mock<IMembersRepository> _mockMemebersRepository;
        private MemberAction _memberAction;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _mockMemebersRepository = new Mock<IMembersRepository>();
            _memberAction = new MemberAction(_mockMemebersRepository.Object);
        }

        [TestMethod]
        public void DoAction_Member_Found_Members_List_Updated()
        {
            var productId = "";
            _mockMemebersRepository.Setup(x => x.GetMembersByProductId(productId)).Returns(new MemberDto());
            var productDto = new ProductDto(){Id = productId};
            var attendenceDto = new AttendenceDto();

            var result = _memberAction.DoAction(productDto, attendenceDto);

            Assert.IsTrue(attendenceDto.Members.Any());
        }

        [TestMethod]
        public void DoAction__No_Member_Found_Members_Not_List_Updated()
        {
            var productId = "";
            _mockMemebersRepository.Setup(x => x.GetMembersByProductId(productId)).Returns((MemberDto)null);
            var productDto = new ProductDto() { Id = productId };
            var attendenceDto = new AttendenceDto();

            var result = _memberAction.DoAction(productDto, attendenceDto);

            Assert.IsFalse(attendenceDto.Members.Any());
        }
    }
}