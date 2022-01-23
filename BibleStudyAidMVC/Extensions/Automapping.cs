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
            CreateMap<DailyBibleReading, DailyBibleReadingViewModel>();
            CreateMap<DailyBibleReadingViewModel, DailyBibleReading>();

            //DailyBibleReadingAll
            CreateMap<DailyBibleReadingAll, DailyBibleReadingAllViewModel>();
            CreateMap<DailyBibleReadingAllViewModel,DailyBibleReadingAll>();

            //References
            CreateMap<References, ReferencesViewModel>();
            CreateMap<ReferencesViewModel, References>();

            //Scriptures
            CreateMap<Scriptures, ScripturesViewModel>();
            CreateMap<ScripturesViewModel, Scriptures>(); 
            
            //Documents
            CreateMap<Documents, DocumentsViewModel>();
            CreateMap<DocumentsViewModel, Documents>(); 
        }
    }
}
