using AutoMapper;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.Extensions
{
    public class Automapping:Profile
    {
        public Automapping()
        {
            //DailyBibleReading
            CreateMap<DailyBibleReading, DailyBibleReadingVM>();
        }
    }
}
