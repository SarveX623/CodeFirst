using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext db;

        public EmpController(ApplicationDbContext db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Emp.ToList();
            return View(data);
        }
        public IActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Employee e)

        {
            db.Emp.Add(e);
            db.SaveChanges();
            TempData["msg"] = "User Succefully Insert Data";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmp(int id)
        {
            var d = db.Emp.Find(id);
            // var dd=db.Emp.Where(s=>s.Id==id).SingleOrDefault();

            if (d != null)
            {
                db.Emp.Remove(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return RedirectToAction("Index");
            }

        }
        public IActionResult EditEmp(int id)
        {
            var d = db.Emp.Find(id);
            // var dd=db.Emp.Where(s=>s.Id==id).SingleOrDefault();
            return View(d);


        }
        [HttpPost]
        public IActionResult EditEmp(Employee e)
        {
            db.Emp.Update(e);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
