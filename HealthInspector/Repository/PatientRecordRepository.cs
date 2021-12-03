using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;

namespace HealthInspector.Repository
{
    public class PatientRecordRepository : IPatientRecordRepository
    { 
    private readonly IMapper mapper;
    private readonly ApplicationDbContext dbContext;

    public PatientRecordRepository(IMapper mapper, ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public PatientRecord GetPatientRecord(int Id)
    {
            PatientRecord patient = new PatientRecord();
        patient = dbContext.patientRecords.FirstOrDefault(m => m.Id == Id);
        return patient;
    }

    public List<PatientRecord> GetPatientRecords()
    {
        List<PatientRecord> patient = new List<PatientRecord>();
        patient = dbContext.patientRecords.ToList();
        return patient;
    }

    public void PostPatientRecord(PatientRecord patient)
    {
        dbContext.patientRecords.Add(patient);
        dbContext.SaveChanges();
    }
}
}
