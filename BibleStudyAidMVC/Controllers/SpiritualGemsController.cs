using AutoMapper;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class SpiritualGemsController : Controller
    {
        private readonly ISpiritualGemsData _spiritualGemsData;
        private readonly ILogger<SpiritualGems> _logger;
        private readonly IMapper _mapper;

        public SpiritualGemsController(ISpiritualGemsData spiritualGemsData, ILogger<SpiritualGems> logger, IMapper mapper)
        {
            _spiritualGemsData = spiritualGemsData;
            _logger = logger;
            _mapper = mapper;
        }
        // GET: SpiritualGemsController
        public ActionResult Index()
        {
            return View();
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

        // GET: SpiritualGemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpiritualGemsController/Edit/5
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
