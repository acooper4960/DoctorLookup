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
        List<Doctor> GetRelatedDoctors(Doctor doctor);
        void InsertDoctors(List<Doctor> doctors);
        void Clear();
    }
}
