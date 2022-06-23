using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace BibleStudyAidMVC.Extensions.DataAdaptors
{
    public class DailyBibleReadingDataAdaptor:DataAdaptor
    {
        private readonly DailyBibleReadingData _dailyBibleReadingData;

        public DailyBibleReadingDataAdaptor(DailyBibleReadingData dailyBibleReadingData)
        {
            _dailyBibleReadingData = dailyBibleReadingData;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest,string key=null)
        {
            int count = 0;
            var data=await _dailyBibleReadingData.GetAllAsync();
            count = data.Count();
            return dataManagerRequest.RequiresCounts ? new DataResult()
            {
                Result = data,
                Count = count
            } : count;

        }

        public override async Task<object> InsertAsync(DataManagerRequest dataManagerRequest, object data, string key)
        {
            await _dailyBibleReadingData.InsertAsync(data as DailyBibleReading);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManagerRequest dataManagerRequest, object data, string key)
        {
            await _dailyBibleReadingData.UpdateAsync(data as DailyBibleReading);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            var Id=Convert.ToInt32(primaryKeyValue);
            await _dailyBibleReadingData.DeleteAsync(Id);
            return primaryKeyValue;
        }
    }
}
