using AutoMapper;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyInfoAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.Extensions
{
    public class Automapping: Profile
    {
        public Automapping()
        {
            //Create DailyBibleReading Mapping
            CreateMap<DailyBibleReading, DailyBibleReadingDTO>();
            CreateMap<DailyBibleReadingDTO, DailyBibleReading>();

            //Create FamilyStudyProjects Mapping
            CreateMap<FamilyStudyProjects, FamilyStudyProjectsDTO>();
            CreateMap<FamilyStudyProjectsDTO, FamilyStudyProjects>();
        }
    }
}
