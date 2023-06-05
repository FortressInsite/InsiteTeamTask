using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Store;
using System.Collections.Generic;

namespace InsiteTeamTask.Data.Providers
{
    public class DataProvider : IDataProvider
    {
        public DataProvider()
        {
                
        }
        public IEnumerable<Game> GetGames()
        {
            return DataStore.Games;
        }

        public IEnumerable<Member> GetMembers()
        {
            return DataStore.Members;
        }

        public IEnumerable<Product> GetProducts()
        {
            return DataStore.Products;
        }

        public IEnumerable<Season> GetSeasons()
        {
            return DataStore.Seasons;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return DataStore.Tickets;
        }
    }
}
