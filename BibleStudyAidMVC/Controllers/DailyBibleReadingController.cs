﻿using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class DailyBibleReadingController : Controller
    {
        private readonly IDailyBibleReadingData _dailyBibleReadingData;
        private readonly ILogger<DailyBibleReadingData> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;

        public DailyBibleReadingController(IDailyBibleReadingData dailyBibleReadingData, ILogger<DailyBibleReadingData> logger, IMapper mapper, IHttpRequestService httpRequestService)
        {
            _dailyBibleReadingData = dailyBibleReadingData;
            _logger = logger;
            _mapper = mapper;
            _httpRequestService = httpRequestService;
        }

        // GET: DailyBibleReadingController
        public async Task<IActionResult> IndexAsync()
        {
            var dailyBibleReadingList = await _dailyBibleReadingData.GetAllAsync();
            var viewModel = _mapper.Map<IEnumerable<DailyBibleReadingVM>>(dailyBibleReadingList);
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
            var viewModel = _mapper.Map<DailyBibleReadingAllVM>(dailyBibleReadingAll);
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
            var viewModel = new DailyBibleReadingVM();
            return View(viewModel);
        }

        // POST: DailyBibleReadingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(DailyBibleReadingVM viewModel)
        {
            try
            {
                var model=_mapper.Map<DailyBibleReading>(viewModel);
                var Id=await _dailyBibleReadingData.InsertAsync(model);
                
                return View("EditAsync", Id);
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
            var viewModel = _mapper.Map<DailyBibleReadingAllVM>(dailyBibleReadingAll);
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

        // POST: DailyBibleReadingController/Edit/5
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
