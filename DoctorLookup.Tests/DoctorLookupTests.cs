using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoctorLookup;
using System.Collections.Generic;
using DoctorLookup.Repository;
using DoctorLookup.DTO;
using System.Linq;

namespace DoctorLookup.Tests
{
    [TestClass]
    public class DoctorLookupTests
    {
        private List<Doctor> testDoctors = new List<Doctor>()
        {
            new Doctor()
            {
                Name = "Dr. Test",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "San Francisco", State = "CA", ZipCode = 94111, Country = "USA" }
            },
             new Doctor()
            {
                Name = "Dr. Test",
                Rating = DrRating.FiveStars,
                Specialty = "Anesthesiology",
                Location = new Location() { City = "San Francisco", State = "CA", ZipCode = 94111, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "Santa Clara", State = "CA", ZipCode = 94111, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test0",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "San Ramon", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test1",
                    Rating = DrRating.FiveStars,
                    Specialty = "Immunology",
                    Location = new Location() { City = "San Ramon", State = "CA", ZipCode = 94583, Country = "USA" }
                },
                new Doctor()
            {
                Name = "Dr. Test2",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "San Ramon", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test3",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "San Ramon", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test0",
                Rating = DrRating.FourStars,
                Specialty = "Immunology",
                Location = new Location() { City = "Dublin", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test0",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "Dublin", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test1",
                Rating = DrRating.ThreeStars,
                Specialty = "Immunology",
                Location = new Location() { City = "Dublin", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test2",
                Rating = DrRating.TwoStars,
                Specialty = "Immunology",
                Location = new Location() { City = "Dublin", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test3",
                Rating = DrRating.OneStar,
                Specialty = "Immunology",
                Location = new Location() { City = "Dublin", State = "CA", ZipCode = 94583, Country = "USA" }
            },
            new Doctor()
            {
                Name = "Dr. Test",
                Rating = DrRating.FiveStars,
                Specialty = "Cardiology",
                Location = new Location() { City = "San Ramon", State = "CA", ZipCode = 94583, Country = "USA" }
            }

    };
        [TestMethod]
        public void EmptyDoctorRepo_ReturnsNoDoctors()
        {
            var directory = new DoctorDirectory();
            var testDoctor = new Doctor()
            {
                Name = "Dr. Test",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "San Francisco", State = "CA", ZipCode = 94111, Country = "USA" },

            };

            var doctors = directory.FindRelatedDoctors(testDoctor);
            
            Assert.AreEqual(0, doctors.Count);
        }

        [TestMethod]
        public void DoctorRepoWithOneDoctorInSameCity_ReturnsOneDoctor()
        {
            var directory = new DoctorDirectory();
            directory.LoadDoctors(testDoctors);
            var testDoctor = new Doctor()
            {
                Name = "Dr. Test",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "San Francisco", State = "CA", ZipCode = 94111, Country = "USA" },

            };

            var doctors = directory.FindRelatedDoctors(testDoctor);

            Assert.AreEqual(1, doctors.Count);
        }

        [TestMethod]
        public void RelatedDoctors_WithSameRating_SortedByName()
        {
            var directory = new DoctorDirectory();
            directory.LoadDoctors(testDoctors);
            var testDoctor = new Doctor()
            {
                Name = "Dr. Test0",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "San Ramon", State = "CA", ZipCode = 94583, Country = "USA" }
            };

            var doctors = directory.FindRelatedDoctors(testDoctor);

            Assert.AreEqual("Dr. Test2", doctors[2].Name);
        }

        [TestMethod]
        public void RelatedDoctors_Sorted_By_Rating()
        {
            var directory = new DoctorDirectory();
            directory.LoadDoctors(testDoctors);
            var testDoctor = new Doctor()
            {
                Name = "Dr. Test0",
                Rating = DrRating.FiveStars,
                Specialty = "Immunology",
                Location = new Location() { City = "Dublin", State = "CA", ZipCode = 94583, Country = "USA" }
            };

            var doctors = directory.FindRelatedDoctors(testDoctor);
            bool sorted = true;
            for (int i=1; i < doctors.Count; i++)
            {
                if (doctors[i].Rating > doctors[i - 1].Rating)
                    sorted = false;
            }

            Assert.AreEqual(true, sorted);
        }
    }

}
