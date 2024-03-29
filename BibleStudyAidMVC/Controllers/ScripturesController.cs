﻿using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.HelperMethods;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class ScripturesController : Controller
    {
        private readonly IScripturesData _scripturesData;
        private readonly ILogger<Scriptures> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;

        public ScripturesController(IScripturesData scripturesData,ILogger<Scriptures> logger, IMapper mapper, IHttpRequestService httpRequestService, IDataAccessHelperMethods dataAccessHelperMethods)
        {
            _scripturesData = scripturesData;
            _logger = logger;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
            _dataAccessHelperMethods = dataAccessHelperMethods;
        }
        // GET: ScripturesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ScripturesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScripturesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScripturesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Scripture,Book,Chapter,Verse,FKTableIdandName,Description")] Scriptures viewModel)
        {
            try
            {
                if(viewModel.Chapter is null)
                {
                    viewModel.Scripture = $"{viewModel.Book} {viewModel.Verse}";
                }
                else
                {
                    viewModel.Scripture = $"{viewModel.Book} {viewModel.Chapter}:{viewModel.Verse}";
                }
                var model=_mapper.Map<Scriptures>(viewModel);
                var id=_scripturesData.InsertAsync(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: ScripturesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScripturesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Scripture,Book,Chapter,Verse,FKTableIdandName,Description,IsDeleted")] Scriptures viewModel)
        {
            try
            {
                var model = _mapper.Map<Scriptures>(viewModel);
                var id=_scripturesData.UpdateAsync(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: ScripturesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScripturesController/Delete/5
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
