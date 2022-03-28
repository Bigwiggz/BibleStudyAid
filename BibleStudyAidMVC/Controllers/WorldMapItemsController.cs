using AutoMapper;
using BibleStudyAidBusinessLogic.ControllerLogic;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.HelperMethods;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class WorldMapItemsController : Controller
    {
        private readonly IWorldMapItemBusinessLogic _worldMapItemBusinessLogic;
        private readonly IWorldMapItemData _worldMapItemsData;
        private readonly ILogger<WorldMapItem> _logger;
        private readonly IMapper _mapper;
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;

        public WorldMapItemsController(IWorldMapItemBusinessLogic worldMapItemBusinessLogic, IWorldMapItemData worldMapItemsData, ILogger<WorldMapItem> logger, IMapper mapper, IDataAccessHelperMethods dataAccessHelperMethods)
        {
            _worldMapItemBusinessLogic = worldMapItemBusinessLogic;
            _worldMapItemsData = worldMapItemsData;
            _logger = logger;
            _mapper = mapper;
            _dataAccessHelperMethods = dataAccessHelperMethods;
        }
        // GET: WorldMapController
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var allWorldMapData = await _worldMapItemBusinessLogic.GetAllIndexBusinessLogic();
            return View(allWorldMapData);
        }

        // GET: WorldMapController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // GET: WorldMapController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorldMapController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("GeoJsonString")] WorldMapItemStringViewModel viewModel)
        {
            try
            {
                await _worldMapItemBusinessLogic.CreatePostBusinessLogic(viewModel.GeoJsonString);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorldMapController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorldMapController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorldMapController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorldMapController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //POST PrimaryProjectEdit to Primary Table
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrimaryProjectEdit(string foreignKey)
        {
            try
            {
                var topLevelTableSelectorModel = await _dataAccessHelperMethods.SelectTopLevelTableGivenForiegnKey(foreignKey);
                return RedirectToAction("Edit", topLevelTableSelectorModel.ControllerName, topLevelTableSelectorModel.Id);
            }
            catch
            {
                return View();
            }
        }
    }
}
