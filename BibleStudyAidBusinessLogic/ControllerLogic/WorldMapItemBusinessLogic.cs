using BibleStudyAidBusinessLogic.GeoFunctions;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.HelperMethods;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyAidBusinessLogic.ControllerLogic
{
    public class WorldMapItemBusinessLogic
    {
        private readonly IWorldMapItemData _worldMapItemsData;
        private readonly ILogger<WorldMapItem> _logger;
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;
        private readonly GeoServices _geoServices;

        public WorldMapItemBusinessLogic(IWorldMapItemData worldMapItemsData, ILogger<WorldMapItem> logger, IDataAccessHelperMethods dataAccessHelperMethods, GeoServices geoServices)
        {
            _worldMapItemsData = worldMapItemsData;
            _logger = logger;
            _dataAccessHelperMethods = dataAccessHelperMethods;
            _geoServices = new GeoServices();
        }

        //Index Get
        public async Task<string> IndexBusinessLogic()
        {
            var allWorldMapsModelsList= await _worldMapItemsData.GetAllAsync();

            string allWorldMapGeoJSON= _geoServices.CreateFeatureCollectionGeoJSONFromModel<WorldMapItem>(allWorldMapsModelsList.ToList());  
            
            return allWorldMapGeoJSON;  
        }

        //Create Post
        public async Task CreatePostBusinessLogic(string geoJSON)
        {
            var createWorldMapModelList= _geoServices.CreateModelsFromGeoJSON(geoJSON);
            
            foreach(var model in createWorldMapModelList)
            {
                var Id = await _worldMapItemsData.InsertAsync(model);
            }
        }

        //Edit Post
        public async Task EditPostBusinessLogic(string geoJSON)
        {
            var createWorldMapModelList = _geoServices.CreateModelsFromGeoJSON(geoJSON);

            foreach (var model in createWorldMapModelList)
            {
                var Id = await _worldMapItemsData.UpdateAsync(model);
            }
        }

        //Primary Project Edit
        public async Task PrimaryProjectEditBusinessLogic(string foreignKey)
        {
            var topLevelTableSelectorModel = await _dataAccessHelperMethods.SelectTopLevelTableGivenForiegnKey(foreignKey);

        }

        //Delete
        public async Task DeletePostBusinessLogic(string geoJSON)
        {
            var createWorldMapModelList = _geoServices.CreateModelsFromGeoJSON(geoJSON);

            foreach (var model in createWorldMapModelList)
            {
                var Id = await _worldMapItemsData.DeleteAsync(model.Id);
            }
        }

        //
    }
}
