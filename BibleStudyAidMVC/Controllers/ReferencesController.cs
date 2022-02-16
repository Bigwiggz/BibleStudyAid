using AutoMapper;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.HelperMethods;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class ReferencesController : Controller
    {
        private readonly IReferencesData _referencesData;
        private readonly ILogger<References> _logger;
        private readonly IMapper _mapper;
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;

        public ReferencesController(IReferencesData referencesData,ILogger<References> logger, IMapper mapper, IDataAccessHelperMethods dataAccessHelperMethods)
        {
            _referencesData = referencesData;
            _logger = logger;
            _mapper = mapper;
            _dataAccessHelperMethods = dataAccessHelperMethods;
        }

        // GET: ReferencesController
        public async Task<IActionResult> IndexAsync()
        {
            var modelList=await _referencesData.GetAllAsync();   
            var viewModel=_mapper.Map<IEnumerable<ReferencesViewModel>>(modelList);
            return View(viewModel);
        }

        // GET: ReferencesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReferencesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferencesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Reference,Description,FKTableIdandName")] ReferencesViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<References>(viewModel);
                var id = _referencesData.InsertAsync(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferencesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReferencesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Reference,Description,FKTableIdandName,IsDeleted")] ReferencesViewModel viewModel)
        {
            try
            {

                var model=_mapper.Map<References>(viewModel);
                var id= await _referencesData.UpdateAsync(model);  
                return Redirect(HttpContext.Request.Headers["Referer"]); 
            }
            catch
            {
                return View();
            }
        }

        //POST: ReferenceController/PrimaryProjectEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrimaryProjectEdit(string foreignKey)
        {
            try
            {
                var topLevelTableSelectorModel=await _dataAccessHelperMethods.SelectTopLevelTableGivenForiegnKey(foreignKey);
                return RedirectToAction("Edit", topLevelTableSelectorModel.ControllerName, topLevelTableSelectorModel.Id);
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferencesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReferencesController/Delete/5
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
