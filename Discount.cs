using GeoCoordinatePortable;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SZR
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public int BusinessCategory { get; set; }
        public string DiscountName { get; set; }
        public DateTime ValidTill { get; set; }

        public decimal Price { get; set; }

        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        public int? Propagations { get; set; }

        [JsonIgnore]
        public GeoCoordinate Geolocation
        {
            get
            {
                return new GeoCoordinate((double)this.Lat, (double)this.Lng);
            }

        }

        public double GetDistance(GeoCoordinate coordinate)
        {

            return this.Geolocation.GetDistanceTo(coordinate);
        }


    }
}
