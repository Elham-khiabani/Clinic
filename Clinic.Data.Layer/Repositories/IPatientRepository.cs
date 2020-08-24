using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.Layer.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatient();
        IEnumerable<Patient> GetPatientsByFilter(string parameter);
        Patient GetPatientsById(int patientId);
        bool InsertPatient(Patient patient);
        bool UpdatePatient(Patient patient);
        bool DeletePatient(int patientId);
        bool DeletePatient(Patient patient);
    }
}
