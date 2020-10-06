using System;

namespace InsiteTeamTask_A.Models
{

    public enum ProductType
    {
        Member = 1,
        Ticket = 2
    }

    public class Product
    {
        public string Id { get; set; }

        public DateTime ValidFrom { get; set; }

        public int SeasonId { get; set; }

        public ProductType Type { get; set; }

        public int GameId { get; set; }
    }
}