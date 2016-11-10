using DoctorLookup.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLookup.Repository
{
    public interface IDoctoryRepository
    {
        IEnumerable<Doctor> GetDoctors();
        void InsertDoctors(IEnumerable<Doctor> doctors);
        void Clear();
    }
}
