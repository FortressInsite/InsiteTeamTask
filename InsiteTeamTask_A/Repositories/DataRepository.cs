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
        
        private static MockDataService service = new MockDataService();
        private List<Member> members = service.Members().ToList();
        private List<Ticket> tickets = service.Tickets().ToList();
        private List<Product> products = service.Products().ToList();
       

        public List<Attendance> GetAttendanceListBySeasonAndGame(int seasonNumber, int gameNumber)
        {
            List<Attendance> attendanceList = new List<Attendance>();

            var seasonMembers =  products.Where(products => products.SeasonId <= seasonNumber).Where(products => products.Type == ProductType.Member).ToList();

            for (int i = 0; i < members.Count; i++)
            {
                for (int j = 0; j < seasonMembers.Count; j++)
                {
                    if (seasonMembers[j].Id == members[i].ProductId)
                    {
                        attendanceList.Add(new Attendance() { Barcode = "N/A", MemberId = members[i].Id });
                    }
                }
            }


            var ticketMembers = products.Where(products => products.SeasonId == seasonNumber).Where(products => products.GameId == gameNumber).Where(products => products.Type == ProductType.Ticket).ToList();

            for (int i = 0; i < tickets.Count; i++)
            {
                for (int j = 0; j < ticketMembers.Count; j++)
                {
                    if (tickets[i].ProductId == ticketMembers[j].Id)
                    {
                        attendanceList.Add(new Attendance() { Barcode = tickets[i].Barcode, MemberId = 0 });
                    }
                }
            }


            return attendanceList;
          
        }


        public List<Attendance> GetAttendanceListByProductCode(string productCode)
        {
            List<Attendance> attendanceList = new List<Attendance>();

            var memberProductCodes = products.Where(product => product.Id == productCode).Where(product => product.Type == ProductType.Member).ToList();

            for (int i = 0; i < members.Count; i++)
            {
                for (int j = 0; j < memberProductCodes.Count; j++)
                {
                    if (members[i].ProductId == memberProductCodes[j].Id)
                    {
                        attendanceList.Add(new Attendance() { Barcode = "N/A", MemberId = members[i].Id });
                    }
                }
            }


            var ticketMemberProductCodes = products.Where(product => product.Id == productCode).Where(product => product.Type == ProductType.Ticket).ToList();

            for (int i = 0; i < tickets.Count; i++)
            {
                for (int j = 0; j < ticketMemberProductCodes.Count ; j++)
                {
                    if (ticketMemberProductCodes[j].Id == tickets[i].ProductId)
                    {
                        attendanceList.Add(new Attendance() { Barcode = tickets[i].Barcode, MemberId = 0 });
                    }
                }
            }

            return attendanceList;

        }

        public List<Attendance> GetAll()
        {
            List<Attendance> attendanceList = new List<Attendance>();

            for (int i = 0; i < members.Count; i++)
            {
                attendanceList.Add(new Attendance() { MemberId = members[i].Id, Barcode = "N/A" });
            }

            for (int i = 0; i < tickets.Count; i++)
            {
                attendanceList.Add(new Attendance() { Barcode = tickets[i].Barcode, MemberId = 0 });
            }

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
