using BibleStudyAidBusinessLogic.Models;
using BibleStudyDataAccessLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyAidBusinessLogic.ControllerLogic
{
    public class DashboardLogic
    {
        private readonly IDailyBibleReadingData _dailyBibleReadingdata;
        private readonly IFamilyStudyProjectsData _familyStudyProjectsData;
        private readonly IMeetingsAssembliesData _meetingsAssembliesData;
        private readonly ISpiritualGemsData _spiritualGemsData;
        private readonly ITalksData _talksData;
        private readonly ITagsData _tagsData;
        private readonly IScripturesData _scripturesData;
        private readonly IDocumentsData _documentsData;
        private readonly IReferencesData _referencesData;
        private readonly IWorldMapItemData _worldMapItemData;

        public DashboardLogic(
            IDailyBibleReadingData dailyBibleReadingdata, 
            IFamilyStudyProjectsData familyStudyProjectsData, 
            IMeetingsAssembliesData meetingsAssembliesData,
            ISpiritualGemsData spiritualGemsData,
            ITalksData talksData,
            ITagsData tagsData,
            IScripturesData scripturesData,
            IDocumentsData documentsData,
            IReferencesData referencesData,
            IWorldMapItemData worldMapItemData
            )
        {
            _dailyBibleReadingdata = dailyBibleReadingdata;
            _familyStudyProjectsData = familyStudyProjectsData;
            _meetingsAssembliesData = meetingsAssembliesData;
            _spiritualGemsData = spiritualGemsData;
            _talksData = talksData;
            _tagsData = tagsData;
            _scripturesData = scripturesData;
            _documentsData = documentsData;
            _referencesData = referencesData;
            _worldMapItemData = worldMapItemData;
        }

        public async Task<AllDashboardItems> LoadDashboardItems()
        {

            var allDailyBibleReading = await _dailyBibleReadingdata.GetAllAsync();
            var allFamilyStudyProjects= await _familyStudyProjectsData.GetAllAsync();
            var allMeetingsAssemblies = await _meetingsAssembliesData.GetAllAsync();
            var allSpiritualGems= await _spiritualGemsData.GetAllAsync();
            var allTalks=await _talksData.GetAllAsync();
            var allTags=await _tagsData.GetAllAsync();

            var allScriptures=await _scripturesData.GetAllAsync();
            var allReferences=await _referencesData.GetAllAsync();
            var allDocuments=await _documentsData.GetAllAsync();
            var allWorldMapItems=await _worldMapItemData.GetAllAsync();

            var allDashboardItems = new AllDashboardItems
            {
                DailyBibleReadingList = allDailyBibleReading.ToList(),
                FamilyStudyProjectsList = allFamilyStudyProjects.ToList(),
                MeetingsAssembliesList = allMeetingsAssemblies.ToList(),
                SpiritualGemsList = allSpiritualGems.ToList(),
                TalksList=allTalks.ToList(),
                TagsList=allTags.ToList(),

                ScripturesList=allScriptures.ToList(),
                ReferencesList=allReferences.ToList(),
                DocumentsList=allDocuments.ToList(),
                WorldMapItemList=allWorldMapItems.ToList(),
            };

            //Get Project Level Time Entries
            allDashboardItems.TimeEntryProjectsList = GetTimeEntryProjectsData(allDashboardItems);

            //Get Child Level Time Entries
            allDashboardItems.TimeChildEntryList = GetTimeEntryChildData(allDashboardItems);

            return allDashboardItems;   

        }

        private List<TimeEntry> GetTimeEntryChildData(AllDashboardItems allDashboardItems)
        {
            var timeEntries=new List<TimeEntry>();  
            
            foreach (var item in allDashboardItems.ScripturesList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.DateUpdated,
                    RecordDescription = item.Scripture,
                    RecordType = "Scripture"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.DocumentsList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.DateUploaded,
                    RecordDescription = item.FileName,
                    RecordType = "Document"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.ReferencesList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.DateUpdated,
                    RecordDescription = item.Reference,
                    RecordType = "Reference"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.WorldMapItemList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.UpdatedDate,
                    RecordDescription = item.Title,
                    RecordType = "Map Item"
                };

                timeEntries.Add(timeEntry);
            }

            return timeEntries;
        }

        private List<TimeEntry> GetTimeEntryProjectsData(AllDashboardItems allDashboardItems)
        {
            var timeEntries = new List<TimeEntry>();

            foreach (var item in allDashboardItems.DailyBibleReadingList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.DateRead,
                    RecordDescription = item.LessonLearnedDescription,
                    RecordType = "Daily Bible Reading"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.FamilyStudyProjectsList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.DateCreated,
                    RecordDescription = item.FamilyStudyDescription,
                    RecordType = "Family Study Projects"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.MeetingsAssembliesList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.CreatedDate,
                    RecordDescription = item.LessonLearnedDescription,
                    RecordType = "Meetings & Assemblies"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.SpiritualGemsList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.DateUpdated,
                    RecordDescription = item.BriefDescription,
                    RecordType = "Spiritual Gems"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.TalksList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.CreatedDate,
                    RecordDescription = item.Description,
                    RecordType = "Talks"
                };

                timeEntries.Add(timeEntry);
            }

            foreach (var item in allDashboardItems.TagsList)
            {
                var timeEntry = new TimeEntry
                {
                    DateOfRecord = item.TagCreatedDate,
                    RecordDescription = item.TagDescription,
                    RecordType = "Tags"
                };

                timeEntries.Add(timeEntry);
            }

            return timeEntries;
        }


    }
}
