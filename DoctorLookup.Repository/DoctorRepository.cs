using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorLookup.DTO;

namespace DoctorLookup.Repository
{
    public class InMemoryDoctorRepository : IDoctoryRepository
    {
        private List<Doctor> _doctors;

        public InMemoryDoctorRepository()
        {
            _doctors = new List<Doctor>();
        }

        public InMemoryDoctorRepository(List<Doctor> doctors)
        {
            _doctors = doctors;
        }

        public void Clear()
        {
            _doctors.Clear();
        }

        /// <summary>
        /// A Doctor is considered related when they are located in the same city, and have the same specialty
        /// Results are then ordered by rating and then by name
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public List<Doctor> GetRelatedDoctors(Doctor doctor)
        {
            return _doctors
            .OrderByDescending(doc => doc.Rating)
            .Where(doc => doc.Location.Equals(doctor.Location)
            && doc.Specialty == doctor.Specialty)
            .ToList();
        }

        public void InsertDoctors(List<Doctor> doctors)
        {
            _doctors.AddRange(doctors);
        }
    }
}
