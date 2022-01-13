using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class TabsController : Controller
    {
        // GET: TabsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TabsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TabsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabsController/Create
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

        // GET: TabsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TabsController/Edit/5
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

        // GET: TabsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TabsController/Delete/5
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
