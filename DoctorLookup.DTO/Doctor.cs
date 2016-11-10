using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLookup.DTO
{
    public class Doctor : IComparable<Doctor>
    {
        public string Name { get; set; }
        public DrRating Rating { get; set; }
        public string Specialty { get; set; }
        public Location Location { get; set; }

        public int CompareTo(Doctor other)
        {
            if (other == null)
                return 1;

            else if (other.Rating > Rating)
                return 0;

            else if (other.Rating < Rating)
                return 1;

            else
                return other.Name.CompareTo(Name);

        }
    }


    public enum DrRating
    {
        OneStar = 1,
        TwoStars = 2,
        ThreeStars = 3,
        FourStars = 4,
        FiveStars = 5,

    }

   
}
