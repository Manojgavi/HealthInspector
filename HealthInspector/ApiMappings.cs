using AutoMapper;

using HealthInspector.Models;
using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector
{
    public class ApiMappings:Profile
    {
        public ApiMappings()
        {
            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<Bmi, BmiViewModel>().ReverseMap();

            CreateMap<Clinic, ClinicViewModel>().ReverseMap();



            CreateMap<DoctorSpecality, DoctorSpecalityVm>().ReverseMap();

            CreateMap<DoctorAvailability, DoctorAvailabilityVm>().ReverseMap();


            CreateMap<Feedback, FeedbackViewModel>().ReverseMap();

            CreateMap<Questionnaire, QuestionnaireViewModel>().ReverseMap();

            CreateMap<PatientRecord, PatientRecordViewModel>().ReverseMap();
        }
    }
}
