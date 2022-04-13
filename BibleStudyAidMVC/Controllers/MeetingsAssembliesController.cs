using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.HelperMethods;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BibleStudyAidMVC.Controllers
{
    public class MeetingsAssembliesController : Controller
    {
        private readonly IMeetingsAssembliesData _meetingsAssembliesData;
        private readonly ILogger<MeetingsAssemblies> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpRequestService _httpRequestService;
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;

        public MeetingsAssembliesController(IMeetingsAssembliesData meetingsAssembliesData, ILogger<MeetingsAssemblies> logger, IMapper mapper, IHttpRequestService httpRequestService, IDataAccessHelperMethods dataAccessHelperMethods)
        {
            _meetingsAssembliesData = meetingsAssembliesData;
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
    }
}
