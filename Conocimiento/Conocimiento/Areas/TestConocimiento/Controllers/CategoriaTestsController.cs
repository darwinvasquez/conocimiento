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
    public class CategoriaTestsController : Controller
    {
        private ContextTest db = new ContextTest();

        // GET: TestConocimiento/CategoriaTests
        public ActionResult Index()
        {
            return View(db.CategoriaTest.ToList());
        }

        // GET: TestConocimiento/CategoriaTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTest categoriaTest = db.CategoriaTest.Find(id);
            if (categoriaTest == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTest);
        }

        // GET: TestConocimiento/CategoriaTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestConocimiento/CategoriaTests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaTestId,Nombre,Estado")] CategoriaTest categoriaTest)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaTest.Add(categoriaTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaTest);
        }

        // GET: TestConocimiento/CategoriaTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTest categoriaTest = db.CategoriaTest.Find(id);
            if (categoriaTest == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTest);
        }

        // POST: TestConocimiento/CategoriaTests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaTestId,Nombre,Estado")] CategoriaTest categoriaTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaTest);
        }

        // GET: TestConocimiento/CategoriaTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTest categoriaTest = db.CategoriaTest.Find(id);
            if (categoriaTest == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTest);
        }

        // POST: TestConocimiento/CategoriaTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaTest categoriaTest = db.CategoriaTest.Find(id);
            db.CategoriaTest.Remove(categoriaTest);
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
