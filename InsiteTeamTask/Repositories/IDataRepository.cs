using System.Collections.Generic;
using InsiteTeamTask.Models;

namespace InsiteTeamTask.Repositories
{
	public interface IDataRepository
	{
		List<Attendance> GetAttendanceListFor(string productId);
		List<Season> GetSeasons();
		List<Product> GetProducts();
		List<Game> GetGames();
	}
}

