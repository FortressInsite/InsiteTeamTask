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

    // Retrieves attendance for all products
    public IEnumerable<Attendance> GetAttendance()
    {
        var Attendance = new List<Attendance>();
        Attendance = (from Product in _dataProvider.GetProducts()
                      join Ticket in _dataProvider.GetTickets() on Product.Id equals Ticket.ProductId into joinedModels
                      from TicketEmpty in joinedModels.DefaultIfEmpty()
                      join Member in _dataProvider.GetMembers() on Product.Id equals Member.ProductId into joinedModels1
                      from MemberEmpty in joinedModels1.DefaultIfEmpty()
                      select new Attendance
                      {
                          AttendanceType = TicketEmpty == null ? AttendanceType.SeasonTicket : AttendanceType.GameTicket,
                          Barcode = TicketEmpty?.Barcode,
                          MemberId = MemberEmpty?.Id,
                      }).ToList();
        return Attendance;
    }

    // Retrieves attendance for a specific game based on the provided season ID and game number
    public IEnumerable<Attendance> GetAttendanceForGame(int seasonId, int gameNumber)
    {
        var Attendance = new List<Attendance>();
        Attendance = (from Product in _dataProvider.GetProducts()
                      join Ticket in _dataProvider.GetTickets() on Product.Id equals Ticket.ProductId into joinedModels
                      from TicketEmpty in joinedModels.DefaultIfEmpty()
                      join Member in _dataProvider.GetMembers() on Product.Id equals Member.ProductId into joinedModels1
                      from MemberEmpty in joinedModels1.DefaultIfEmpty()
                      where Product.SeasonId == seasonId && Product.GameId == gameNumber
                      select new Attendance
                      {
                          AttendanceType = TicketEmpty == null ? AttendanceType.SeasonTicket : AttendanceType.GameTicket,
                          Barcode = TicketEmpty?.Barcode,
                          MemberId = MemberEmpty?.Id,
                      }).ToList();
        return Attendance;
    }

    // Retrieves attendance for a specific product based on the provided product code
    public IEnumerable<Attendance> GetAttendanceForProduct(string productCode)
    {
        var Attendance = new List<Attendance>();
        Attendance = (from Product in _dataProvider.GetProducts()
                      join Ticket in _dataProvider.GetTickets() on Product.Id equals Ticket.ProductId into joinedModels
                      from TicketEmpty in joinedModels.DefaultIfEmpty()
                      join Member in _dataProvider.GetMembers() on Product.Id equals Member.ProductId into joinedModels1
                      from MemberEmpty in joinedModels1.DefaultIfEmpty()
                      where Product.Id == productCode
                      select new Attendance
                      {
                          AttendanceType = TicketEmpty == null ? AttendanceType.SeasonTicket : AttendanceType.GameTicket,
                          Barcode = TicketEmpty?.Barcode,
                          MemberId = MemberEmpty?.Id,
                      }).ToList();
        return Attendance;
    }
}
}
