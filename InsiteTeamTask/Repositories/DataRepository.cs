using InsiteTeamTask.MockData;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.Repositories
{
	public class DataRepository : IDataRepository
	{
		private IDataService _dataService;

		public DataRepository(IDataService dataService)
		{
			_dataService = dataService;
		}

		public List<Attendance> GetAttendanceListFor(string productId)
		{
			var attendanceList = new List<Attendance>();

			attendanceList.AddRange(_dataService.Members()
					.Where(m => m.ProductId == productId)
					.Select(m => new Attendance
						{
						Barcode = "N/A",
						MemberId = m.Id
						}));

			attendanceList.AddRange(_dataService.Tickets()
					.Where(t => t.ProductId == productId)
					.Select(t => new Attendance
						{
						Barcode = t.Barcode,
						MemberId = 0
						}));

			return attendanceList;
		}

		public List<Season> GetSeasons()
		{
			return _dataService.Seasons().ToList();
		}

		public List<Event> GetEvents()
		{
			throw new NotImplementedException();
		}

		public List<Product> GetProducts()
		{
			return _dataService.Products().ToList();
		}

		public List<Game> GetGames()
		{
			return _dataService.Games().ToList();
		}
	}
}
