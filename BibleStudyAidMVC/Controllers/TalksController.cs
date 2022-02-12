using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class TalksController : Controller
    {
        private readonly ITalksData _talksData;
        private readonly ILogger<Talks> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;

        public TalksController(ITalksData talksData, ILogger<Talks> logger, IMapper mapper, IHttpRequestService httpRequestService)
        {
            _talksData = talksData;
            _logger = logger;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
        }
        // GET: TalksController
        public async Task<IActionResult> Index()
        {
            var modelList= await _talksData.GetAllAsync();
            var viewModelList = _mapper.Map<IEnumerable<TalksViewModel>>(modelList);
            return View(viewModelList);
        }

        // GET: TalksController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model=await _talksData.GetParentAndAllChildrenRecordsAsync(id);
            var viewModel=_mapper.Map<TalksAllViewModel>(model);
            return View(viewModel);
        }

        // GET: TalksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TalksViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<Talks>(viewModel);
                var Id = await _talksData.InsertAsync(model);

                return View("Edit", Id);
            }
            catch
            {
                return View();
            }
        }

        // GET: TalksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var talksAll = await _talksData.GetParentAndAllChildrenRecordsAsync(id.Value);
            var viewModel = _mapper.Map<TalksAllViewModel>(talksAll);
            if (viewModel is not null)
            {
                try
                {
                    foreach (var text in viewModel.ScripturesList)
                    {
                        var bibleCitation = text.Scripture;
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

        // GET: TalksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TalksController/Delete/5
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
