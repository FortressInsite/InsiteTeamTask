using InsiteTeamTask.MockData;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.Repositories
{
    public class DataRepository
    {
        public List<Attendance> GetAttendanceListFor(int gameNumber, int seasonNumber, string productNumber)
        {
            MockDataService service = new MockDataService();

            List<Member> members = service.Members().ToList();
            List<Ticket> tickets = service.Tickets().ToList();
            List<Product> products = service.Products().ToList();

            List<Attendance> attendanceList = new List<Attendance>();

            foreach (var product in products)
            {
                for (int i = 0; i < members.Count; i++)
                {
                    if (product.GameId == gameNumber && product.SeasonId == seasonNumber && product.Id == productNumber && productNumber == members[i].ProductId)
                    {
                        attendanceList.Add(new Attendance()
                        {
                            Barcode = "N/A",
                            MemberId = members[i].Id
                        });
                    }
                }

                for (int i = 0; i < tickets.Count; i++)
                {
                    if (product.GameId == gameNumber && product.SeasonId == seasonNumber && product.Id == productNumber && productNumber == tickets[i].ProductId)
                    {
                        attendanceList.Add(new Attendance()
                        {
                            Barcode = tickets[i].Barcode,
                            MemberId = 0
                        });
                    }
                }
                
            }
            return attendanceList;
        }

        public List<Attendance> GetAttendanceListFor(int gameNumber, int seasonNumber)
        {
            MockDataService service = new MockDataService();

            List<Member> members = service.Members().ToList();
            List<Ticket> tickets = service.Tickets().ToList();
            List<Product> products = service.Products().ToList();

            List<Attendance> attendanceList = new List<Attendance>();

            foreach (var product in products)
            {
                for (int i = 0; i < members.Count; i++)
                {
                    if (product.GameId == gameNumber && product.SeasonId == seasonNumber && product.Id == members[i].ProductId)
                    {
                        attendanceList.Add(new Attendance()
                        {
                            Barcode = "N/A",
                            MemberId = members[i].Id
                        });
                    }
                }

                for (int i = 0; i < tickets.Count; i++)
                {
                    if (product.GameId == gameNumber && product.SeasonId == seasonNumber && product.Id == tickets[i].ProductId)
                    {
                        attendanceList.Add(new Attendance()
                        {
                            Barcode = tickets[i].Barcode,
                            MemberId = 0
                        });
                    }
                }
            }
            return attendanceList;
        }

        public List<Season> GetSeasons(int eventId)
        {
            MockDataService service = new MockDataService();
            List<Season> seasons = service.Seasons().ToList();
            
            return seasons;
        }

        public List<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            MockDataService service = new MockDataService();
            List<Product> products = service.Products().ToList();

            return products;
        }

        public List<Game> GetGames()
        {
            MockDataService service = new MockDataService();
            List<Game> games = service.Games().ToList();

            return games;
        }

    }
}
