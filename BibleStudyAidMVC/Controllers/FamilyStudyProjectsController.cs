using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class FamilyStudyProjectsController : Controller
    {
        // GET: FamilyStudyProjectsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FamilyStudyProjectsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FamilyStudyProjectsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamilyStudyProjectsController/Create
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

        // GET: FamilyStudyProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FamilyStudyProjectsController/Edit/5
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

        // GET: FamilyStudyProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FamilyStudyProjectsController/Delete/5
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
