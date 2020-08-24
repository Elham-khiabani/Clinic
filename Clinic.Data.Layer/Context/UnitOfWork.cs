using Clinic.Data.Layer.Repositories;
using Clinic.Data.Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.Layer.Context
{
    class UnitOfWork : IDisposable
    {
        ClinicDB_DBEntities db = new ClinicDB_DBEntities();
        private IPatientRepository _patientRepository;
        public IPatientRepository PatientRepository 
        {
            get
            {
                if (_patientRepository==null)
                {
                    _patientRepository = new PatientRepository(db);
                }
                return _patientRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
