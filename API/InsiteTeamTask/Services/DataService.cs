using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsiteTeamTask.Services
{
    public class DataService : IDataService
    {
        private readonly IDataProvider _dataProvider;

        public DataService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public List<Attendance> GetAttendance()
        {
            return _dataProvider.GetProducts().Select(s => new Attendance
            {
                AttendanceType = (s.Type == ProductType.Member ? AttendanceType.SeasonTicket : AttendanceType.GameTicket),
                Barcode = _dataProvider.GetTickets().FirstOrDefault(t => t.ProductId == s.Id)?.Barcode,
                MemberId = _dataProvider.GetMembers().FirstOrDefault(m => m.ProductId == s.Id)?.Id
            }).ToList();
        }

        public List<Attendance> GetAttendanceForGame(int seasonId, int gameNumber)
        {
            return _dataProvider.GetProducts()
                .Where(p => p.SeasonId == seasonId && p.GameId == gameNumber)
                .Select(s => new Attendance
                {
                    AttendanceType = (s.Type == ProductType.Member ? AttendanceType.SeasonTicket : AttendanceType.GameTicket),
                    Barcode = _dataProvider.GetTickets().FirstOrDefault(t => t.ProductId == s.Id)?.Barcode,
                    MemberId = _dataProvider.GetMembers().FirstOrDefault(m => m.ProductId == s.Id)?.Id
                }).ToList();
        }

        public List<Attendance> GetAttendanceForProduct(string productCode)
        {
            return _dataProvider.GetProducts()
                .Where(p => p.Id == productCode)
                .Select(s => new Attendance
                {
                    AttendanceType = (s.Type == ProductType.Member ? AttendanceType.SeasonTicket : AttendanceType.GameTicket),
                    Barcode = _dataProvider.GetTickets().FirstOrDefault(t => t.ProductId == s.Id)?.Barcode,
                    MemberId = _dataProvider.GetMembers().FirstOrDefault(m => m.ProductId == s.Id)?.Id
                }).ToList();
        }

        public List<Game> GetGames()
        {
            return _dataProvider.GetGames().ToList();
        }

        public List<Member> GetMembers()
        {
            return _dataProvider.GetMembers().ToList();
        }

        public List<string> GetProductCodes()
        {
            return _dataProvider.GetProducts().Select(p => p.Id).ToList();
        }

        public List<Season> GetSeasons()
        {
            return _dataProvider.GetSeasons().ToList();
        }

        public List<Ticket> GetTickets()
        {
            return _dataProvider.GetTickets().ToList();
        }
    }
}
