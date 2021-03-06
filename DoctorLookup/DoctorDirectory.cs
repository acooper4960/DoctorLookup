﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorLookup.Repository;
using DoctorLookup.DTO;

namespace DoctorLookup
{

    public class DoctorDirectory
    {
        IDoctoryRepository _repo;
        public DoctorDirectory()
        {
            _repo = new InMemoryDoctorRepository();
        }

        public DoctorDirectory(IDoctoryRepository repo)
        {
            _repo = repo;
        }

        public void LoadDoctors(List<Doctor> doctors)
        {
            _repo.InsertDoctors(doctors);
        }

        public void Clear()
        {
            _repo.Clear();
        }

        /// <summary>
        /// A Doctor is considered related when they are located in the same city, and have the same specialty
        /// Results are then ordered by rating and then by name
        /// </summary>
        /// <param name="doctor"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<Doctor> FindRelatedDoctors(Doctor doctor, int num = 100)
        {
            return _repo.GetDoctors()
            .Where(doc => doc.Location.Equals(doctor.Location) && doc.Specialty == doctor.Specialty)
            .OrderByDescending(doc => doc.Rating)
            .ThenBy(doc => doc.Name)
            .Take(num)
            .ToList();
        }
    }
}
