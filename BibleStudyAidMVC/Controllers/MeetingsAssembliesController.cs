﻿using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyDataAccessLibrary.HelperMethods;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BibleStudyAidMVC.Controllers
{
    public class MeetingsAssembliesController : Controller
    {
        private readonly MeetingsAssemblies _meetingsAssemblies;
        private readonly ILogger<MeetingsAssemblies> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;

        public MeetingsAssembliesController(MeetingsAssemblies meetingsAssemblies, ILogger<MeetingsAssemblies> logger, IMapper mapper, IHttpRequestService httpRequestService, IDataAccessHelperMethods dataAccessHelperMethods)
        {
            _meetingsAssemblies = meetingsAssemblies;
            _logger = logger;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
            _dataAccessHelperMethods = dataAccessHelperMethods;
        }
        // GET: MeetingsAssembliesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MeetingsAssembliesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MeetingsAssembliesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingsAssembliesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MeetingsAssembliesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MeetingsAssembliesController/Edit/5
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

        // GET: MeetingsAssembliesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MeetingsAssembliesController/Delete/5
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
