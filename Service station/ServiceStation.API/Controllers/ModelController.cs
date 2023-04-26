/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceStation.API.Controllers
{
    public class ModelController : Controller
    {
        // GET: ModelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelController/Create
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

        // GET: ModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelController/Edit/5
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

        // GET: ModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelController/Delete/5
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
*/