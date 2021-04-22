using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using To_Do.Data;
using To_Do.Models;
using SpotifyAPI.Web;

namespace To_Do.Controllers
{
    public class YapılacaklarController : Controller
    {
        private readonly ToDoDbContext _db;

        public YapılacaklarController(ToDoDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var val = _db.Items.Where(x => x.isFinished == true).ToList();
            return View(val);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDo t)
        {
            t.isFinished = true;
            _db.Items.Add(t);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var z = _db.Items.Find(id);
            z.isFinished = false;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ToDoGetir(int id)
        {
           
            var x = _db.Items.Find(id);
            //List<SelectListItem> deger1 = (from i in _db.Items.ToList()
            //    select new SelectListItem
            //    {
            //        Text = i.isFinished.ToString(),
            //        Value = i.isFinished.ToString()
            //    }).ToList();
            //ViewBag.dgr = deger1;
            return View("ToDoGetir", x);
        }

        public ActionResult Update(ToDo t)
        {
            var x = _db.Items.Find(t.Id);
            x.Describe = t.Describe;
            x.isFinished = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
