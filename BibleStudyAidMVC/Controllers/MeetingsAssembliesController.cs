using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class MeetingsAssembliesController : Controller
    {
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
