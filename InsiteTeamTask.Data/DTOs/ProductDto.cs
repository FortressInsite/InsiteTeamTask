using System;
using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Data.DTOs
{
    public class ProductDto : IEquatable<ProductDto>
    {
        public string Id { get; set; }
        public int SeasonId { get; set; }
        public int GameId { get; set; }
        public ProductType Type { get; set; }
        public DateTime ValidFrom { get; set; }

        public bool Equals(ProductDto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && SeasonId == other.SeasonId && GameId == other.GameId && Type == other.Type && ValidFrom.Equals(other.ValidFrom);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SeasonId;
                hashCode = (hashCode * 397) ^ GameId;
                hashCode = (hashCode * 397) ^ (int) Type;
                hashCode = (hashCode * 397) ^ ValidFrom.GetHashCode();
                return hashCode;
            }
        }
    }
}