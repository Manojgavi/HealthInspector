using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInspector.Models;

namespace HealthInspector.IRepository
{
    public interface IPatientRecordRepository
    {
        List<PatientRecord> GetPatientRecords();
        PatientRecord GetPatientRecord(int Id);
        void PostPatientRecord(PatientRecord patient);
    }
}
