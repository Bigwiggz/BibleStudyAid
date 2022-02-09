using AutoMapper;
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

        public TalksController(ITalksData talksData, ILogger<Talks> logger, IMapper mapper)
        {
            _talksData = talksData;
            _logger = logger;
            _mapper = mapper;
        }
        // GET: TalksController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TalksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TalksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalksController/Create
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

        // GET: TalksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TalksController/Edit/5
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
