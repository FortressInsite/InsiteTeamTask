using InsiteTeamTask.MockData;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.Repositories
{
    public class AttendanceService
    {
        private readonly MockDataService _service;

        public AttendanceService()
        {
            _service = new MockDataService();
        }

        public List<Attendance> GetAttendanceListFor(int seasonNumber, int gameNumber)
        {
            List<Product> seasonPasses = GetSeasonPasses(seasonNumber);
            List<Member> membersWithSeasonPasses = GetMembersWithSeasonPass(seasonPasses);

            Product gameProduct = GetProduct(seasonNumber, gameNumber);
            List<Ticket> tickets = new List<Ticket>();

            if (gameProduct != null)
                tickets = GetTicketsByProduct(gameProduct.Id);

            return CompileAttendanceByTicketsAndMembers(membersWithSeasonPasses, tickets);
        }

        public List<Attendance> GetAttendanceListFor(string productId)
        {
            Product gameProduct = GetProduct(productId);
            List<Ticket> tickets = new List<Ticket>();
            List<Member> membersWithSeasonPasses = new List<Member>();

            if (gameProduct != null)
            {
                if (gameProduct.Type == ProductType.Ticket)
                    tickets = GetTicketsByProduct(gameProduct.Id);
                else if (gameProduct.Type == ProductType.Member)
                    membersWithSeasonPasses = GetMembersWithSeasonPass(new List<Product>() { gameProduct });
            }

            return CompileAttendanceByTicketsAndMembers(membersWithSeasonPasses, tickets);
        }     

        List<Attendance> CompileAttendanceByTicketsAndMembers(List<Member> members, List<Ticket> tickets)
        {
            List<Attendance> attendanceList = new List<Attendance>();

            foreach (Member member in members)
            {
                attendanceList.Add(new Attendance()
                {
                    Barcode = "N/A",
                    MemberId = member.Id
                });
            }

            foreach (Ticket ticket in tickets)
            {
                attendanceList.Add(new Attendance()
                {
                    Barcode = ticket.Barcode,
                    MemberId = 0
                });
            }

            return attendanceList;
        }

        Product GetProduct(int seasonNumber, int gameNumber)
        {
            return _service.Products().FirstOrDefault(product => product.SeasonId == seasonNumber && product.GameId == gameNumber);
        }

        Product GetProduct(string productId)
        {
            return _service.Products().FirstOrDefault(product => product.Id == productId);
        }

        List<Product> GetSeasonPasses(int seasonNumber)
        {
            return _service.Products().Where(product => product.SeasonId == seasonNumber && product.Type == ProductType.Member).ToList();
        }

        List<Ticket> GetTicketsByProduct(string productId)
        {
            return _service.Tickets().Where(ticket => ticket.ProductId == productId).ToList();
        }

        List<Member> GetMembersWithSeasonPass(List<Product> seasonPasses)
        {
            List<Member> members = new List<Member>();
            foreach (Product seasonPass in seasonPasses)
            {
                members.Add(_service.Members().FirstOrDefault(member => member.ProductId == seasonPass.Id));
            }
            return members;
        }
    }
}
