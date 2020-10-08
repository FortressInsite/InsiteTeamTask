using System;
using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public int SeasonId { get; set; }
        public int GameId { get; set; }
        public ProductType Type { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}