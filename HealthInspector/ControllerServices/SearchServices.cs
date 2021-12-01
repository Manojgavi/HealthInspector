using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ControllerServices
{
    public class SearchServices : ISearchServices
    {
        private readonly ILocalityRepository localityRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IUserRepository userRepository;
        private readonly IClinicRepository clinicRepository;

        public SearchServices(IClinicRepository clinicRepository,ILocalityRepository localityRepository,IDoctorRepository doctorRepository,IUserRepository userRepository)
        {
            this.localityRepository = localityRepository;
            this.doctorRepository = doctorRepository;
            this.userRepository = userRepository;
            this.clinicRepository = clinicRepository;
        }
        public Search CreateSearch()
        {
            Search search = new Search();
            search.Localities = localityRepository.GetLocalities();
            return search;
        }

        public List<SearchDataVm> GetSearchData(Search search)
        {
            List<SearchDataVm> searchDataVms = new List<SearchDataVm>();
            List<SearchDataVm> searchDataVms2 = new List<SearchDataVm>();
            List<Locality> localities = new List<Locality>();
            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            List<DoctorSpecality> doctorSpecalities = new List<DoctorSpecality>();
            List<Clinic> clinics = new List<Clinic>();

            List<User> users = new List<User>();

            users = userRepository.GetDoctors();

            clinics = clinicRepository.GetClinics();

            localities = localityRepository.GetLocalities();
            doctorAvailabilities = doctorRepository.GetDoctorAvailabilities();
            doctorSpecalities = doctorRepository.GetDoctorSpecialities();

            var result = (from user in users
                          join speciality in doctorSpecalities on user.Id equals speciality.UserId
                          join availability in doctorAvailabilities on user.Id equals availability.UserId
                          join clinic in clinics on availability.ClinicId equals clinic.Id
                          join locality in localities on clinic.LocalityId equals locality.Id
                          select new
                          {
                              Id = user.Id,
                              DoctorName = user.FirstName + " " + user.LastName,
                              Speciality = speciality.Speciality,
                              Day = availability.Day,
                              StartTime = availability.StartTime,
                              EndTime = availability.EndTime,
                              ClinicName = clinic.ClinicName,
                              Locality = locality.Zipcode
,
                          }
                        );
            foreach(var obj in result)
            {
                SearchDataVm searchDataVm = new SearchDataVm()
                {
                    Id = obj.Id,
                    DoctorName = obj.DoctorName,
                    Speciality = obj.Speciality,
                    Day = obj.Day,
                    StartTime = obj.StartTime,
                    EndTime = obj.EndTime,
                    ClinicName = obj.ClinicName,
                    Locality = obj.Locality
                };
                searchDataVms.Add(searchDataVm);
            }


            if(search.Speciality!=null && search.Locality!=null)
            {
                searchDataVms2 = searchDataVms.Where(m => m.Speciality == search.Speciality && m.Locality==search.Locality).ToList();

            }
            else if (search.Speciality != null && search.Locality == null)
            {
                searchDataVms2 = searchDataVms.Where(m => m.Speciality == search.Speciality ).ToList();
            }
            else if (search.Speciality == null && search.Locality != null)
            {
                searchDataVms2 = searchDataVms.Where(m => m.Locality == search.Locality).ToList();
            }
            else
            {
                return searchDataVms;
            }

            return searchDataVms2;
        }
    }
}
