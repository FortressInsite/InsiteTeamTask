using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InsiteTeamTask.Services
{
    public class DataService : IDataService
    {
        private readonly IDataProvider dataProvider;

        public DataService(IDataProvider dataProvider) 
        {
            this.dataProvider = dataProvider;
        
        }
        public List<GameSeasonView> GetGameSeasonViews()
        {
            List<GameSeasonView> GameSeasonViewList = new List<GameSeasonView>();
            var games = this.dataProvider.GetGames();
            var sessions = this.dataProvider.GetSeasons();
            foreach(var game in games) 
            {
                var sessionInfo = sessions.FirstOrDefault(s => s.Id == game.SeasonId);
                if(sessionInfo != null)
                {
                    GameSeasonViewList.Add(new GameSeasonView()
                    {
                        GameId= game.Id,
                        GameSeasonName = game.Description+" "+sessionInfo.Name,
                        SessionId = sessionInfo.Id,
                    });
                } 
            }
            return GameSeasonViewList;
        }
        public List<Attendance> GetAttendance()
        {
            var Tickets = this.dataProvider.GetTickets().ToList();
            var Members = this.dataProvider.GetMembers().ToList();
            var Attendances = new List<Attendance>();
            Tickets.ForEach(ticket =>
            {
                Attendances.Add(new Attendance()
                {
                    AttendanceType = AttendanceType.GameTicket,
                    MemberId = 0,
                    Barcode = ticket.Barcode
                });
            });
            Members.ForEach(member =>
            {
                Attendances.Add(new Attendance()
                {
                    AttendanceType = AttendanceType.SeasonTicket,
                    MemberId = member.Id,
                    Barcode = ""
                });
            });
            return Attendances;
        }

        public List<Attendance> GetAttendanceForGame(int seasonId, int gameNumber)
        {
            var Product = this.dataProvider.GetProducts().FirstOrDefault(p => p.SeasonId == seasonId && p.GameId == gameNumber);
            return GetAttendanceForProduct(Product.Id);
        }
        
        public List<Attendance> GetAttendanceForProduct(string productCode)
        {
            var Product = this.dataProvider.GetProducts().FirstOrDefault(p => p.Id.Equals(productCode));
            if(Product == null)
            {
                return null;
            }
            var Attendances = new List<Attendance>();
            if(Product.Type == ProductType.Member)
            {
                var Productmembers = this.dataProvider.GetMembers().Where(m => m.ProductId.Equals(Product.Id)).ToList();
                Productmembers.ForEach(member =>
                {
                    Attendances.Add(new Attendance()
                    {
                        AttendanceType = AttendanceType.SeasonTicket,
                        MemberId = member.Id,
                        Barcode = ""
                    });
                });
            }
            else
            {
                var Producttickets = this.dataProvider.GetTickets().Where(m => m.ProductId.Equals(Product.Id)).ToList();
                Producttickets.ForEach(ticket =>
                {
                    Attendances.Add(new Attendance()
                    {
                        AttendanceType = AttendanceType.SeasonTicket,
                        MemberId = 0,
                        Barcode = ticket.Barcode
                    });
                });
            }
            return Attendances;
        }
    }
}
