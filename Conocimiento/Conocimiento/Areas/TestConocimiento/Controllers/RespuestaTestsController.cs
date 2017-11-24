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
    public class RespuestaTestsController : Controller
    {
        private ContextTest db = new ContextTest();

        // GET: TestConocimiento/RespuestaTests
        public ActionResult Index()
        {
            var respuestaTest = db.RespuestaTest.Include(r => r.PreguntaTest);
            return View(respuestaTest.ToList());
        }

        // GET: TestConocimiento/RespuestaTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespuestaTest respuestaTest = db.RespuestaTest.Find(id);
            if (respuestaTest == null)
            {
                return HttpNotFound();
            }
            return View(respuestaTest);
        }

        // GET: TestConocimiento/RespuestaTests/Create
        public ActionResult Create()
        {
            ViewBag.PreguntaTestId = new SelectList(db.PreguntaTest, "PreguntaTestId", "Pregunta");
            return View();
        }

        // POST: TestConocimiento/RespuestaTests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RespuestaTestId,PreguntaTestId,Respuesta,Correcta,Estado")] RespuestaTest respuestaTest)
        {
            if (ModelState.IsValid)
            {
                db.RespuestaTest.Add(respuestaTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PreguntaTestId = new SelectList(db.PreguntaTest, "PreguntaTestId", "Pregunta", respuestaTest.PreguntaTestId);
            return View(respuestaTest);
        }

        // GET: TestConocimiento/RespuestaTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespuestaTest respuestaTest = db.RespuestaTest.Find(id);
            if (respuestaTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.PreguntaTestId = new SelectList(db.PreguntaTest, "PreguntaTestId", "Pregunta", respuestaTest.PreguntaTestId);
            return View(respuestaTest);
        }

        // POST: TestConocimiento/RespuestaTests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RespuestaTestId,PreguntaTestId,Respuesta,Correcta,Estado")] RespuestaTest respuestaTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuestaTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PreguntaTestId = new SelectList(db.PreguntaTest, "PreguntaTestId", "Pregunta", respuestaTest.PreguntaTestId);
            return View(respuestaTest);
        }

        // GET: TestConocimiento/RespuestaTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespuestaTest respuestaTest = db.RespuestaTest.Find(id);
            if (respuestaTest == null)
            {
                return HttpNotFound();
            }
            return View(respuestaTest);
        }

        // POST: TestConocimiento/RespuestaTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RespuestaTest respuestaTest = db.RespuestaTest.Find(id);
            db.RespuestaTest.Remove(respuestaTest);
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
