using InsiteTeamTask.MockData;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask
{
    public class MockDataService : IDataService
    {
        public IEnumerable<Member> Members()
        {
            return new List<Member>
                       {
                           new Member() { Id = 958432, ProductId = "IT20" },
                           new Member() { Id = 875415, ProductId = "IT93" },
                           new Member() { Id = 344174, ProductId = "IT49" },
                           new Member() { Id = 447874, ProductId = "IT52" },
                           new Member(){ Id = 1000114, ProductId = "IT68" }
                       };
        }

        public IEnumerable<Ticket> Tickets()
        {
            return new List<Ticket>
                       {
                           new Ticket() { Barcode = "969312288", ProductId = "MN319A" },
                           new Ticket() { Barcode = "939453763", ProductId = "LV302S" },
                           new Ticket() { Barcode = "946423612", ProductId = "BM1249" },
                           new Ticket() { Barcode = "906290698", ProductId = "AR3942" },
                           new Ticket() { Barcode = "964412136", ProductId = "CH5490" },
                           new Ticket() { Barcode = "934414901", ProductId = "CH5490" },
                           new Ticket() { Barcode = "969341288", ProductId = "MN319A" },
                           new Ticket() { Barcode = "966223434", ProductId = "CH5490" },
                           new Ticket() { Barcode = "962421512", ProductId = "CH5490" },
                           new Ticket() { Barcode = "964422511", ProductId = "CH5490" },
                           new Ticket() { Barcode = "916394028", ProductId = "CH5490" },
                           new Ticket() { Barcode = "901970287", ProductId = "CH5490" },
                           new Ticket() { Barcode = "969345292", ProductId = "MN319A" },
                           new Ticket() { Barcode = "927976084", ProductId = "LV302S" },
                           new Ticket() { Barcode = "926340037", ProductId = "CH5490" },
                           new Ticket() { Barcode = "912133969", ProductId = "CH5490" },
                           new Ticket() { Barcode = "901223783", ProductId = "CH5490" },
                           new Ticket() { Barcode = "941640424", ProductId = "LV302S" },
                           new Ticket() { Barcode = "951434130", ProductId = "CH5490" },
                           new Ticket() { Barcode = "923093162", ProductId = "CH5490" }
                       };
        }

        public IEnumerable<Product> Products()
        {
            return new List<Product>
                       {
                           new Product() { Id = "MN319A", SeasonId = 12, ValidFrom = new DateTime(2012, 1, 18), Type = ProductType.Ticket, GameId = 3 },
                           new Product() { Id = "LV302S", SeasonId = 19, ValidFrom = new DateTime(2019, 10, 9), Type = ProductType.Ticket, GameId = 5 },
                           new Product() { Id = "BM1249", SeasonId = 19, ValidFrom = new DateTime(2019, 6, 13), Type = ProductType.Ticket, GameId = 3 },
                           new Product() { Id = "AR3942", SeasonId = 16, ValidFrom = new DateTime(2016, 5, 10), Type = ProductType.Ticket, GameId = 12 },
                           new Product() { Id = "CH5490", SeasonId = 19, ValidFrom = new DateTime(2019, 3, 28), Type = ProductType.Ticket, GameId = 4 },
                           new Product() { Id = "IT20", SeasonId = 12, ValidFrom = new DateTime(2011, 7, 1), Type = ProductType.Member, GameId = 0 },
                           new Product() { Id = "IT93", SeasonId = 19, ValidFrom = new DateTime(2018, 7, 1), Type = ProductType.Member, GameId = 0 },
                           new Product() { Id = "IT52", SeasonId = 19, ValidFrom = new DateTime(2018, 7, 1), Type = ProductType.Member, GameId = 0 },
                           new Product() { Id = "IT49", SeasonId = 19, ValidFrom = new DateTime(2018, 7, 1), Type = ProductType.Member, GameId = 0 },
                           new Product() { Id = "IT68", SeasonId = 19, ValidFrom = new DateTime(2018, 7, 1), Type = ProductType.Member, GameId = 0 },
                       };
        }

        public IEnumerable<Game> Games()
        {
            return new List<Game>
                       {
                           new Game() { Id = 3, Description = "Manchester City v Liverpool", SeasonId = 12 },
                           new Game() { Id = 4, Description = "Bournemouth v Arsenal", SeasonId = 19 },
                           new Game() { Id = 5, Description = "Liverpool vs Aston Villa", SeasonId = 19 } ,
                           new Game() { Id = 12, Description = "Arsenal v Manchester United", SeasonId = 16 } ,
                           new Game() { Id = 3, Description = "Crystal Palace v Everton", SeasonId = 19 }
                       };
        }

        public IEnumerable<Season> Seasons()
        {
            return new List<Season>
                       {
                           new Season(12),
                           new Season(16),
                           new Season(19),
                       };
        }

    }
}
