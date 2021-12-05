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
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public QuestionnaireRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        

        public void PostUser(QuestionnaireViewModel questionnaireViewModel)
        {
            Questionnaire questionnaire = new Questionnaire();
            questionnaire = mapper.Map<Questionnaire>(questionnaireViewModel);

            dbContext.Questionnaires.Add(questionnaire);
            dbContext.SaveChanges();
        }
    }
}
