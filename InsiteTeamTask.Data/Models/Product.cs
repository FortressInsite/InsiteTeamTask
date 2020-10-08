using System;

namespace InsiteTeamTask.Data.Models
{

    public enum ProductType
    {
        Member = 1,
        Ticket = 2
    }

    internal class Product
    {
        public string Id { get; set; }

        public DateTime ValidFrom { get; set; }

        public int SeasonId { get; set; }

        public ProductType Type { get; set; }

        public int GameId { get; set; }
    }
}