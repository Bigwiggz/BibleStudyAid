using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class FamilyStudyProjectsController : Controller
    {
        private readonly IFamilyStudyProjectsData _familyStudyProjectsData;
        private readonly ILogger<FamilyStudyProjects> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;

        public FamilyStudyProjectsController(IFamilyStudyProjectsData familyStudyProjectsData, ILogger<FamilyStudyProjects> logger, IMapper mapper, IHttpRequestService httpRequestService)
        {
            _familyStudyProjectsData = familyStudyProjectsData;
            _logger = logger;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
        }
        // GET: FamilyStudyProjectsController
        public async Task<IActionResult> Index()
        {
            var modelList = await _familyStudyProjectsData.GetAllAsync();
            var viewModelList = _mapper.Map<IEnumerable<FamilyStudyProjectsViewModel>>(modelList);
            return View(viewModelList);
        }

        // GET: FamilyStudyProjectsController/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var dailyBibleReadingAll = await _familyStudyProjectsData.GetParentAndAllChildrenRecordsAsync(id.Value);
            var viewModel = _mapper.Map<FamilyStudyProjectsAllViewModel>(dailyBibleReadingAll);
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

        // GET: FamilyStudyProjectsController/Create
        public ActionResult Create()
        {
            var viewModel = new FamilyStudyProjectsViewModel();
            return View();
        }

        // POST: FamilyStudyProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FamilyStudyProjects viewModel)
        {
            try
            {
                if(viewModel.FamilyStudyFindings is null) 
                {
                    viewModel.FamilyStudyFindings = "";
                }
                var model = _mapper.Map<FamilyStudyProjects>(viewModel);
                var Id = await _familyStudyProjectsData.InsertAsync(model);
                return View("Edit", Id);
            }
            catch
            {
                return View();
            }
        }

        // GET: FamilyStudyProjectsController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var spiritualGemsAll = await _familyStudyProjectsData.GetParentAndAllChildrenRecordsAsync(id.Value);
            var viewModel = _mapper.Map<FamilyStudyProjectsAllViewModel>(spiritualGemsAll);
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

        // GET: FamilyStudyProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FamilyStudyProjectsController/Delete/5
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
