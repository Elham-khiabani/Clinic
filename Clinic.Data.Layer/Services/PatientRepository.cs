using Clinic.Data.Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.Layer.Services
{
    class PatientRepository : IPatientRepository
    {
        private ClinicDB_DBEntities db;
        public  PatientRepository(ClinicDB_DBEntities context)
        {
            db = context;
        }
        
        public bool DeletePatient(int patientId)
        {
            try
            {
                var patient= GetPatientsById(patientId);
                DeletePatient(patient);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool DeletePatient(Patient patient)
        {
            try
            {
                db.Entry(patient).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<Patient> GetAllPatient()
        {
            return db.Patients.ToList();
        }

        public IEnumerable<Patient> GetPatientsByFilter(string parameter)
        {
            return db.Patients.Where(p => p.FirstName.Contains(parameter) ||
                p.LastName.Contains(parameter) || p.Mobile.Contains(parameter) ||
                p.NationalCode.Contains(parameter)).ToList();
        }

        public Patient GetPatientsById(int patientId)
        {
            return db.Patients.Find(patientId);
        }

        public bool InsertPatient(Patient patient)
        {
            try
            {
                db.Patients.Add(patient);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool UpdatePatient(Patient patient)
        {
            try
            {
                db.Entry(patient).State = EntityState.Modified;
                return true;
            }
            catch 
            {

                return false;
            }
        }
    }
}
