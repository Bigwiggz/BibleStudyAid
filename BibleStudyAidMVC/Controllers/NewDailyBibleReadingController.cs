using AutoMapper;
using BibleStudyAidBusinessLogic.ControllerLogic;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class NewDailyBibleReadingController : Controller
    {
        private readonly IDailyBibleReadingData _dailyBibleReadingData;
        private readonly ILogger<DailyBibleReadingData> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IWorldMapItemBusinessLogic _worldMapItemBusinessLogic;

        public NewDailyBibleReadingController(IDailyBibleReadingData dailyBibleReadingData,
            ILogger<DailyBibleReadingData> logger,
            IMapper mapper,
            IHttpRequestService httpRequestService,
            IWorldMapItemBusinessLogic worldMapItemBusinessLogic)
        {
            _dailyBibleReadingData = dailyBibleReadingData;
            _logger = logger;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
            _worldMapItemBusinessLogic = worldMapItemBusinessLogic;
        }

        // GET: DailyBibleReadingController
        public async Task<IActionResult> IndexAsync()
        {
            var dailyBibleReadingList = await _dailyBibleReadingData.GetAllAsync();
            var viewModel = _mapper.Map<IEnumerable<DailyBibleReadingViewModel>>(dailyBibleReadingList);
            return View(viewModel);
        }

        // GET: DailyBibleReadingController/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var dailyBibleReadingAll = await _dailyBibleReadingData.GetParentAndAllChildrenRecordsAsync(id.Value);
            var viewModel = _mapper.Map<DailyBibleReadingAllViewModel>(dailyBibleReadingAll);
            viewModel.WorldMapItems = await _worldMapItemBusinessLogic.GetGeoJSONbyForeignKey(viewModel.PKIdtblDailyBibleReadings);
            if (viewModel is not null)
            {
                try
                {

                    var bibleCitation = dailyBibleReadingAll.ScriptureStartPoint.Split(':').First();
                    var bibleAPIModel = await _httpRequestService.GetBibleVersesText(bibleCitation);
                    viewModel.BibleText = bibleAPIModel.text;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"There was an error returning the Bible Text: {ex.Message}");
                    throw;
                }

            }
            if (viewModel is null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: DailyBibleReadingController/Create
        public ActionResult Create()
        {
            var viewModel = new DailyBibleReadingViewModel();
            return View(viewModel);
        }

        // POST: DailyBibleReadingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(DailyBibleReadingViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<DailyBibleReading>(viewModel);
                var Id = await _dailyBibleReadingData.InsertAsync(model);

                return View("Edit", (int)Id);
            }
            catch
            {
                return View();
            }
        }

        // GET: DailyBibleReadingController/Edit/5
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var dailyBibleReadingAll = await _dailyBibleReadingData.GetParentAndAllChildrenRecordsAsync(id.Value);
            var viewModel = _mapper.Map<DailyBibleReadingAllViewModel>(dailyBibleReadingAll);
            if (viewModel is not null)
            {
                try
                {
                    var bibleCitation = dailyBibleReadingAll.ScriptureStartPoint.Split(':').First();
                    var bibleAPIModel = await _httpRequestService.GetBibleVersesText(bibleCitation);
                    viewModel.WorldMapItems = await _worldMapItemBusinessLogic.GetGeoJSONbyForeignKey(viewModel.PKIdtblDailyBibleReadings);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"There was an error returning the Bible Text: {ex.Message}");
                    throw;
                }

            }
            if (viewModel is null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: DailyBibleReadingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DailyBibleReadingController/Delete/5
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
    }
}
