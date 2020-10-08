using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsiteTeamTask.Repositories
{
    public class DataRepository
    {
        public List<Attendance> GetAttendanceListFor(int gameNumber)
        {
            MockDataService service = new MockDataService();

            List<Member> members = service.Members().ToList();
            List<Ticket> tickets = service.Tickets().ToList();
            List<Product> products = service.Products().ToList();

            List<Attendance> attendanceList = new List<Attendance>();            

            var filteredMembers = members.Where(member => {
                    var filteredProduct = products.Single(product => product.Id == member.ProductId);
                
                    return filteredProduct.GameId == gameNumber;
                })
                .Select(member =>
                {
                    return new Attendance
                    {
                        Barcode = "N/A",
                        MemberId = member.Id
                    };
                });

            attendanceList.AddRange(filteredMembers);

            var filteredTickets = tickets.Where(ticket => {
                    var filteredProduct = products.Single(product => product.Id == ticket.ProductId);

                    return filteredProduct.GameId == gameNumber;
                })
                .Select(ticket =>
                {
                    return new Attendance
                    {
                        Barcode = ticket.Barcode,
                        MemberId = 0
                    };  
                });

            attendanceList.AddRange(filteredTickets);

            return attendanceList;
        }

        public List<Season> GetSeasons(int eventId)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
