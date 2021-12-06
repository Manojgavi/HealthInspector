using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;

namespace HealthInspector.Repository
{
    public class FeedbackRepository : IFeedbackRepository
        
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        private readonly IClinicRepository clinicRepository;

        public FeedbackRepository(IClinicRepository clinicRepository,IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.clinicRepository = clinicRepository;
        }

        public List<FeedbackDataViewModel> GetFeedbackList()
        {
            List<Feedback> feedbacks = new List<Feedback>();
            feedbacks = dbContext.Feedbacks.ToList();
            List<Clinic> clinics = new List<Clinic>();
            clinics = clinicRepository.GetClinics();
            var result = (from feedback in feedbacks
                          join clinic in clinics
                          on feedback.DoctorId equals clinic.Id
                          select new
                          {
                              Id = feedback.Id,
                              ClinicName = clinic.ClinicName,
                              UserId = feedback.UserId,
                              Review = feedback.Review
                          });
            List<FeedbackDataViewModel> feedbackDataViewModels = new List<FeedbackDataViewModel>();
            foreach(var obj in result)
            {
                FeedbackDataViewModel feedbackDataViewModel = new FeedbackDataViewModel()
                {
                    Id = obj.Id,
                    ClinicName = obj.ClinicName,
                    UserId = obj.UserId,
                    Review = obj.Review
                };

                feedbackDataViewModels.Add(feedbackDataViewModel);
            }
            return feedbackDataViewModels;
        }

        public void PostUser(FeedbackViewModel feedbackViewModel)
        {
            Feedback feedback = new Feedback();
            feedback = mapper.Map<Feedback>(feedbackViewModel);

            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
        }
    }
}
