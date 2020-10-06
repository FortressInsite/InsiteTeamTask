using InsiteTeamTask_A.MockData;
using InsiteTeamTask_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask_A.Repositories
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
            List<Product> ticketsAttended = new List<Product>();


            for(int i = 0; i < members.Count; i++)
            {
                attendanceList.Add(new Attendance()
                {
                    Barcode = "N/A",
                    MemberId = members[i].Id
                });
            }


            for (int i = 0; i < products.Count; i++)
            {
                if(gameNumber == products[i].GameId)
                {
                    ticketsAttended.Add(products[i]);
                }
            }


            for (int i = 0; i < ticketsAttended.Count; i++)
            {
                for (int j = 0; j < tickets.Count; j++)
                {
                    if(ticketsAttended[i].Id ==  tickets[j].ProductId)
                    {
                        attendanceList.Add(new Attendance()
                        {
                            Barcode = tickets[i].Barcode,
                            MemberId = 0
                        });
                    }
                }
            }

            //for (int i = 0; i < tickets.Count; i++)
            //{
            //    attendanceList.Add(new Attendance()
            //    {
                    
            //        Barcode = tickets[i].Barcode,
            //        MemberId = 0
            //    });
            //}

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
