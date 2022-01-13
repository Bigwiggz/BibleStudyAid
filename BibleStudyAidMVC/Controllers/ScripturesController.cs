using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class ScripturesController : Controller
    {
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

        // GET: ScripturesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScripturesController/Edit/5
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
    }
}
