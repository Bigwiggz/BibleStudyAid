using BibleStudyDataAccessLibrary.HelperMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class WorldMapController : Controller
    {
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;

        public WorldMapController(IDataAccessHelperMethods dataAccessHelperMethods)
        {
            _dataAccessHelperMethods = dataAccessHelperMethods;
        }
        // GET: WorldMapController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorldMapController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorldMapController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorldMapController/Create
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

        // GET: WorldMapController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorldMapController/Edit/5
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

        // GET: WorldMapController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorldMapController/Delete/5
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
