using AutoMapper;
using BibleStudyAidMVC.ViewModels;
using BibleStudyAidMVC.ViewModels.Enums;
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

            //Tags
            CreateMap<Tags,TagsViewModel>();
            CreateMap<TagsViewModel, Tags>();

            //TagsToOtherTables
            CreateMap<TagsToOtherTables, TagsToOtherTablesViewModel>();
            CreateMap<TagsToOtherTablesViewModel, TagsToOtherTables>();

            //Spiritual Gems
            CreateMap<SpiritualGems, SpiritualGemsViewModel>();
            CreateMap<SpiritualGemsViewModel,SpiritualGems>();

            //Spiritual Gems All
            CreateMap<SpiritualGemsAll, SpiritualGemsAllViewModel>();
            CreateMap<SpiritualGemsAllViewModel,SpiritualGemsAll>();

            //Talks
            CreateMap<Talks, TalksViewModel>();
            CreateMap<TalksViewModel, Talks>();

            //Talks All
            CreateMap<TalksAll,TalksAllViewModel>()
                .ForMember(dest => dest.MeetingType, opt => opt.MapFrom(src => src.MeetingType));
            CreateMap<TalksAllViewModel,TalksAll>()
                .ForMember(dest => dest.MeetingType, opt => opt.MapFrom(src => src.MeetingType));


            //FamilyStudyProjects
            CreateMap<FamilyStudyProjects, FamilyStudyProjectsViewModel>();
            CreateMap<FamilyStudyProjectsViewModel, FamilyStudyProjects>();

            //FamilyStudyProjectsAll
            CreateMap<FamilyStudyProjectsAll, FamilyStudyProjectsAllViewModel>();
            CreateMap<FamilyStudyProjectsAllViewModel, FamilyStudyProjectsAll>();

            //Enum Mapping
            CreateMap<BibleStudyDataAccessLibrary.Models.Enums.MeetingType, MeetingTypeViewModel>();
            CreateMap<MeetingTypeViewModel, BibleStudyDataAccessLibrary.Models.Enums.MeetingType>();

            

        }
    }
}
