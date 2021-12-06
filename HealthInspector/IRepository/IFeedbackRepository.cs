using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInspector.ViewModels;

namespace HealthInspector.IRepository
{
    public interface IFeedbackRepository
    {
        void PostUser(FeedbackViewModel feedbackViewModel);
        List<FeedbackDataViewModel> GetFeedbackList();
    }
}
