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

        public List<Doctor> GetDoctors()
        {
            return _doctors;
        }

        public void InsertDoctors(IEnumerable<Doctor> doctors)
        {
            _doctors.AddRange(doctors);
        }

        IEnumerable<Doctor> IDoctoryRepository.GetDoctors()
        {
            return _doctors;
        }
    }
}
