using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using College.Models;
using System.Data.Objects;

namespace College.Controllers
{
    public class DemoController : Controller
    {
        private CollegeEntities db = new CollegeEntities();

        // GET: /Demo/
        public ActionResult Index()
        {
            //return View(db.Students.ToList());
            //IEnumerable<Students> model = new st_select_Result 
           
            return View(db.st_select(null));



        }

        // GET: /Demo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Students students = db.Students.Find(id);
            Students students = db.st_select(id).FirstOrDefault();

            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: /Demo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Demo/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,FirstName")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.st_insert(students.id, students.FirstName);
                

                //db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        // GET: /Demo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.st_select(id).FirstOrDefault();

            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: /Demo/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,FirstName")] Students students)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(students).State = EntityState.Modified;
                db.st_update(students.id, students.FirstName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: /Demo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.st_select(id).FirstOrDefault();
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: /Demo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.st_select(id).FirstOrDefault();

            db.st_delete(id);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
