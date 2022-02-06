using AutoMapper;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagsData _tagsData;
        private readonly ILogger<Tags> _logger;
        private readonly IMapper _mapper;

        public TagsController(ITagsData tagsData, ILogger<Tags> logger, IMapper mapper)
        {
            _tagsData = tagsData;
            _logger = logger;
            _mapper = mapper;
        }
        // GET: TabsController
        public async Task<IActionResult> Index()
        {
            var model=await _tagsData.GetAllAsync();

            return View(model);
        }

        // GET: TabsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model=await _tagsData.GetByIdAsync(id);
            var viewModel = _mapper.Map<TagsViewModel>(model);
            return View(viewModel);
        }

        // GET: TabsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("TagName,TagDescription")] TagsViewModel viewModel)
        {
            try
            {
                var model=_mapper.Map<Tags>(viewModel);
                var result=await _tagsData.InsertAsync(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: TabsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TabsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([Bind("Id,TagName,TagDescription, IsDeleted")] TagsViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<Tags>(viewModel);
                var result=await _tagsData.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TabsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TabsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(object Id)
        {
            try
            {
                var result =await _tagsData.DeleteAsync(Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
