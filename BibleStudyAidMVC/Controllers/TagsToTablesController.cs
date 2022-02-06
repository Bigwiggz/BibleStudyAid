using AutoMapper;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BibleStudyAidMVC.Controllers
{
    public class TagsToTablesController : Controller
    {
        private readonly ITagsToOtherTablesData _tagsToOtherTablesData;
        private readonly ILogger<TagsToOtherTables> _logger;
        private readonly IMapper _mapper;

        public TagsToTablesController(ITagsToOtherTablesData tagsToOtherTablesData,ILogger<TagsToOtherTables> logger, IMapper mapper)
        {
            _tagsToOtherTablesData = tagsToOtherTablesData;
            _logger = logger;
            _mapper = mapper;
        }
        // GET: TagsToTablesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TagsToTablesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagsToTablesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagsToTablesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("TagsId,FKTableIdandName")] TagsToOtherTablesViewModel viewModel)
        {
            try
            {
                var model= _mapper.Map<TagsToOtherTables>(viewModel);
                var Id=await _tagsToOtherTablesData.InsertAsync(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // POST: TagsToTablesController/CreateMultiple
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultipleAsync([Bind("TagsId,FKTableIdandName")] TagsToOtherTablesViewModelMultiple viewModel)
        {
            try
            {
                var tagsList = JsonSerializer.Deserialize<List<int>>(viewModel.TagsId);
                if(tagsList.Count > 0)
                {
                    foreach (var tag in tagsList)
                    {
                        var tagsToOtherTables = new TagsToOtherTables 
                        {
                            TagsId=tag,
                            FKTableIdandName=viewModel.FKTableIdandName,
                            IsDeleted=false
                        };

                        var Id = await _tagsToOtherTablesData.InsertAsync(tagsToOtherTables);
                    }
                }

                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsToTablesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagsToTablesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsToTablesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagsToTablesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync([Bind("TagsId,FKTableIdandName")] TagsToOtherTablesViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<TagsToOtherTables>(viewModel);
                var tagModel =await _tagsToOtherTablesData.GetByForeignKey(model);
                if (tagModel != null)
                {
                    var Id=await _tagsToOtherTablesData.DeleteAsync(tagModel);
                }
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        //POST: TagsToTablesController/DeleteMultiple
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMultipleAsync([Bind("TagsId,FKTableIdandName")] TagsToOtherTablesViewModelMultiple viewModel)
        {
            try
            {
                var tagsList = JsonSerializer.Deserialize<List<int>>(viewModel.TagsId);
                
                if (tagsList.Count > 0)
                {
                    foreach (var tag in tagsList)
                    {
                        var tagsToOtherTables = new TagsToOtherTables
                        {
                            TagsId = tag,
                            FKTableIdandName = viewModel.FKTableIdandName
                        };

                        var tagModel = await _tagsToOtherTablesData.GetByForeignKey(tagsToOtherTables);

                        if (tagModel != null)
                        {
                            var Id = await _tagsToOtherTablesData.DeleteAsync(tagModel.Id);
                        }
                    }
                }

                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }
    }
}
