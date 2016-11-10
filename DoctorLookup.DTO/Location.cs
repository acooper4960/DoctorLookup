using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLookup.DTO
{
    public class Location : IEquatable<Location>
    {
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public bool Equals(Location other)
        {
            if (other == null)
                return false;

            return (City == other.City
                && State == other.State
                && ZipCode == other.ZipCode
                && Country == other.Country);
        }

        public override int GetHashCode()
        {
            return City.GetHashCode() ^ State.GetHashCode() ^ ZipCode ^ Country.GetHashCode();
        }
    }
}
