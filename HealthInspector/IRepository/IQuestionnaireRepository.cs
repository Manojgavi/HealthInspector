using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInspector.ViewModels;

namespace HealthInspector.IRepository
{
    public interface IQuestionnaireRepository
    {
        void PostUser(QuestionnaireViewModel questionnaireViewModel);
    }
}
