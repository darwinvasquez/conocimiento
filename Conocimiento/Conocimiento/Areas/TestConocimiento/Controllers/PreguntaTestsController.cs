using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conocimiento.Areas.TestConocimiento.Models;

namespace Conocimiento.Areas.TestConocimiento.Controllers
{
    public class PreguntaTestsController : Controller
    {
        private ContextTest db = new ContextTest();

        // GET: TestConocimiento/PreguntaTests
        public ActionResult Index()
        {
            var preguntaTest = db.PreguntaTest.Include(p => p.CategoriaTest);
            return View(preguntaTest.ToList());
        }

        // GET: TestConocimiento/PreguntaTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntaTest preguntaTest = db.PreguntaTest.Find(id);
            if (preguntaTest == null)
            {
                return HttpNotFound();
            }
            return View(preguntaTest);
        }

        // GET: TestConocimiento/PreguntaTests/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaTestId = new SelectList(db.CategoriaTest, "CategoriaTestId", "Nombre");
            return View();
        }

        // POST: TestConocimiento/PreguntaTests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreguntaTestId,CategoriaTestId,Pregunta,Estado")] PreguntaTest preguntaTest)
        {
            if (ModelState.IsValid)
            {
                db.PreguntaTest.Add(preguntaTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaTestId = new SelectList(db.CategoriaTest, "CategoriaTestId", "Nombre", preguntaTest.CategoriaTestId);
            return View(preguntaTest);
        }

        // GET: TestConocimiento/PreguntaTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntaTest preguntaTest = db.PreguntaTest.Find(id);
            if (preguntaTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaTestId = new SelectList(db.CategoriaTest, "CategoriaTestId", "Nombre", preguntaTest.CategoriaTestId);
            return View(preguntaTest);
        }

        // POST: TestConocimiento/PreguntaTests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreguntaTestId,CategoriaTestId,Pregunta,Estado")] PreguntaTest preguntaTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntaTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaTestId = new SelectList(db.CategoriaTest, "CategoriaTestId", "Nombre", preguntaTest.CategoriaTestId);
            return View(preguntaTest);
        }

        // GET: TestConocimiento/PreguntaTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntaTest preguntaTest = db.PreguntaTest.Find(id);
            if (preguntaTest == null)
            {
                return HttpNotFound();
            }
            return View(preguntaTest);
        }

        // POST: TestConocimiento/PreguntaTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreguntaTest preguntaTest = db.PreguntaTest.Find(id);
            db.PreguntaTest.Remove(preguntaTest);
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
