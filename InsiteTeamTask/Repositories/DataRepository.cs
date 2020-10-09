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

        public List<Attendance> GetAttendanceListFor(int gameNumber, int seasonNumber)
        {
            MockDataService service = new MockDataService();

            List<Member> members = service.Members().ToList();
            List<Ticket> tickets = service.Tickets().ToList();
            List<Product> products = service.Products().ToList();

            List<Attendance> attendanceList = new List<Attendance>();

            var filteredMembers = members.Where(member => {
                var filteredProduct = products.Single(product => product.Id == member.ProductId);

                return filteredProduct.GameId == gameNumber && filteredProduct.SeasonId == seasonNumber;
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

                return filteredProduct.GameId == gameNumber && filteredProduct.SeasonId == seasonNumber;
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

        public List<Attendance> GetAttendanceListFor(string productCode)
        {
            MockDataService service = new MockDataService();

            List<Member> members = service.Members().ToList();
            List<Ticket> tickets = service.Tickets().ToList();

            List<Attendance> attendanceList = new List<Attendance>();

            var filteredMembers = members
                .Where(member => member.ProductId == productCode)
                .Select(member => new Attendance
                {
                    Barcode = "N/A",
                    MemberId = member.Id
                });

            attendanceList.AddRange(filteredMembers);

            var filteredTickets = tickets
                .Where(ticket => ticket.ProductId == productCode)
                .Select(ticket => new Attendance
                {
                    Barcode = ticket.Barcode,
                    MemberId = 0
                });

            attendanceList.AddRange(filteredTickets);

            return attendanceList;
        }

        // I have removed the 2 methods that were here GetSeasons(EventId) and GetEvents() as they had no implementaions and there are no fields defined for Events so I couldn't link a season to an event or vice versa.

        // The below methods were created to allow me to load the initial data needed to populate the dropdowns
        public List<Season> GetSeasons()
        {
            return new MockDataService().Seasons().ToList();
        }

        public List<Product> GetProducts()
        {
            return new MockDataService().Products().ToList();
        }

        public List<Game> GetGames()
        {
            return new MockDataService().Games().ToList();
        }
    }
}
