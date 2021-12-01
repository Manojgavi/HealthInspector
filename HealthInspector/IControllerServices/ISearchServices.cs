using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IControllerServices
{
    public interface ISearchServices
    {
        Search CreateSearch();
        List<SearchDataVm> GetSearchData(Search search);
    }
}
