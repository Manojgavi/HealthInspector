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

        public FeedbackRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
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
