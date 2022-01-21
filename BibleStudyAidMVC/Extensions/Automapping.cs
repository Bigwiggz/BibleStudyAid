using AutoMapper;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;

namespace BibleStudyAidMVC.Extensions
{
    public class Automapping:Profile
    {
        public Automapping()
        {
            //DailyBibleReading
            CreateMap<DailyBibleReading, DailyBibleReadingVM>();
            CreateMap<DailyBibleReadingVM, DailyBibleReading>();

            //DailyBibleReadingAll
            CreateMap<DailyBibleReadingAll, DailyBibleReadingAllVM>();
            CreateMap<DailyBibleReadingAllVM,DailyBibleReadingAll>();

            //References
            CreateMap<References, ReferencesViewModel>();
            CreateMap<ReferencesViewModel, References>();
        }
    }
}
