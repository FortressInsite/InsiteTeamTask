using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Data.Store;
using InsiteTeamTask.Models;
using System;
using System.Collections;
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
            try
            {
                var attendance = new List<Attendance>();
                attendance = (from Product in _dataProvider.GetProducts()
                              join Ticket in _dataProvider.GetTickets() on Product.Id equals Ticket.ProductId into joinedModels
                              from Ticket1 in joinedModels.DefaultIfEmpty()
                              join Member in _dataProvider.GetMembers() on Product.Id equals Member.ProductId into joinedModels1
                              from Member1 in joinedModels1.DefaultIfEmpty()
                              select new Attendance
                              {
                                  AttendanceType = Ticket1 == null ? AttendanceType.SeasonTicket : AttendanceType.GameTicket,
                                  Barcode = Ticket1 != null ? Ticket1.Barcode : null,
                                  MemberId = Member1 != null ? Member1.Id : null,
                              }).ToList();
                return attendance;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public List<Attendance> GetAttendanceForGame(int seasonId, int gameNumber)
        {
            try
            {
                var attendance = new List<Attendance>();
                attendance = (from Product in _dataProvider.GetProducts()
                              join Ticket in _dataProvider.GetTickets() on Product.Id equals Ticket.ProductId into joinedModels
                              from Ticket1 in joinedModels.DefaultIfEmpty()
                              join Member in _dataProvider.GetMembers() on Product.Id equals Member.ProductId into joinedModels1
                              from Member1 in joinedModels1.DefaultIfEmpty()
                              where Product.SeasonId == seasonId && Product.GameId == gameNumber
                              select new Attendance
                              {
                                  AttendanceType = Ticket1 == null ? AttendanceType.SeasonTicket : AttendanceType.GameTicket,
                                  Barcode = Ticket1 != null ? Ticket1.Barcode : null,
                                  MemberId = Member1 != null ? Member1.Id : null,
                              }).ToList();
                return attendance;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<Attendance> GetAttendanceForProduct(string productCode)
        {
            try
            {
                var attendance = new List<Attendance>();
                attendance = (from Product in _dataProvider.GetProducts()
                              join Ticket in _dataProvider.GetTickets() on Product.Id equals Ticket.ProductId into joinedModels
                              from Ticket1 in joinedModels.DefaultIfEmpty()
                              join Member in _dataProvider.GetMembers() on Product.Id equals Member.ProductId into joinedModels1
                              from Member1 in joinedModels1.DefaultIfEmpty()
                              where Product.Id == productCode
                              select new Attendance
                              {
                                  AttendanceType = Ticket1 == null ? AttendanceType.SeasonTicket : AttendanceType.GameTicket,
                                  Barcode = Ticket1?.Barcode,
                                  MemberId = Member1?.Id,
                              }).ToList();
                return attendance;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
