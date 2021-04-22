using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Data;

namespace To_Do.Controllers
{
    public class YapılanlarController : Controller
    {
        private readonly ToDoDbContext _db;

        public YapılanlarController(ToDoDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //for (int i = 0; i < _db.Items.Count(); i++)
            //{
            //    ViewBag.dgr = i;
            //}
            var val = _db.Items.Where(x => x.isFinished == false).ToList();
            return View(val);
        }
        //public ActionResult Delete(int id)
        //{
        //    var z = _db.Items.Find(id);

        //    if (z.Id == 0)
        //    {
        //        var item =_db.Items.Find(id);
        //        _db.Items.Remove(item);
        //        _db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
        //public ActionResult ToDoGetir(int id)
        //{

        //    var x = _db.Items.Find(id);
        //    //List<SelectListItem> deger1 = (from i in _db.Items.ToList()
        //    //    select new SelectListItem
        //    //    {
        //    //        Text = i.isFinished.ToString(),
        //    //        Value = i.isFinished.ToString()
        //    //    }).ToList();
        //    //ViewBag.dgr = deger1;
        //    return View("ToDoGetir", x);
        //}

    }
}
