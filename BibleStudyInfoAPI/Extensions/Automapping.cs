using AutoMapper;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
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

            //Create DailyBibleReading Mapping
            CreateMap<DailyBibleReadingAll, DailyBibleReadingAllDTO>();
            CreateMap<DailyBibleReadingAllDTO, DailyBibleReadingAll>();

            //Create FamilyStudyProjects Mapping
            CreateMap<FamilyStudyProjects, FamilyStudyProjectsDTO>();
            CreateMap<FamilyStudyProjectsDTO, FamilyStudyProjects>();

            //Create Documents Mapping
            CreateMap<Documents, DocumentsDTO>();
            CreateMap<DocumentsDTO, Documents>();

            //Create References Mapping
            CreateMap<References, ReferencesDTO>();
            CreateMap<ReferencesDTO, References>();

            //Create Scriptures Mapping
            CreateMap<Scriptures, ScripturesDTO>();
            CreateMap<ScripturesDTO, Scriptures>();

            //Create MeetingAssemblies Mapping
            CreateMap<MeetingAssemblies, MeetingAssembliesDTO>();
            CreateMap<MeetingAssembliesDTO, MeetingAssemblies>();
        }
    }
}
