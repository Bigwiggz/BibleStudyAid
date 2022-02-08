using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class SpiritualGemsController : Controller
    {
        private readonly ISpiritualGemsData _spiritualGemsData;
        private readonly ILogger<SpiritualGems> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;

        public SpiritualGemsController(ISpiritualGemsData spiritualGemsData, ILogger<SpiritualGems> logger, IMapper mapper, IHttpRequestService httpRequestService)
        {
            _spiritualGemsData = spiritualGemsData;
            _logger = logger;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
        }
        // GET: SpiritualGemsController
        public async Task<IActionResult> Index()
        {
            var modelList =await _spiritualGemsData.GetAllAsync();
            var viewModel = _mapper.Map<IEnumerable<SpiritualGemsViewModel>>(modelList);
            return View(viewModel);
        }

        // GET: SpiritualGemsController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: SpiritualGemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpiritualGemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BriefDescription,LongDescription")] SpiritualGemsViewModel viewModel)
        {
            try
            {
                var model=_mapper.Map<SpiritualGems>(viewModel);
                var Id=await _spiritualGemsData.InsertAsync(model);
                return View("Edit", Id);
            }
            catch
            {
                return View();
            }
        }

        // GET: SpiritualGemsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var spiritualGemsAll = await _spiritualGemsData.GetParentAndAllChildrenRecordsAsync(id.Value);
            var viewModel = _mapper.Map<SpiritualGemsAllViewModel>(spiritualGemsAll);
            if (viewModel is not null)
            {
                try
                {
                    foreach (var text in viewModel.ScripturesList)
                    {
                        var bibleCitation = text.Scripture.Split(':').First();
                        var bibleAPIModel = await _httpRequestService.GetBibleVersesText(bibleCitation);
                        text.ScriptureText = bibleAPIModel.text;
                    }

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

        // POST: SpiritualGemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
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

        // GET: SpiritualGemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpiritualGemsController/Delete/5
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
