using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class ReferencesController : Controller
    {
        // GET: ReferencesController
        public ActionResult Index()
        {
            return View();
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

        // GET: ReferencesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReferencesController/Edit/5
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
