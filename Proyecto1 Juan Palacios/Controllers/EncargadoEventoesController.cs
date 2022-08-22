using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto1_Juan_Palacios.Models;

namespace Proyecto1_Juan_Palacios.Controllers
{
    public class EncargadoEventoesController : Controller
    {
        private PrimerParcial_JuanPalaciosEntities db = new PrimerParcial_JuanPalaciosEntities();

        // GET: EncargadoEventoes
        public ActionResult Index()
        {
            return View(db.EncargadoEventoes.ToList());
        }

        // GET: EncargadoEventoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncargadoEvento encargadoEvento = db.EncargadoEventoes.Find(id);
            if (encargadoEvento == null)
            {
                return HttpNotFound();
            }
            return View(encargadoEvento);
        }

        // GET: EncargadoEventoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EncargadoEventoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Encargado,NombreEncargado,TelefonoEncargado,EmailEncargado")] EncargadoEvento encargadoEvento)
        {
            if (ModelState.IsValid)
            {
                db.EncargadoEventoes.Add(encargadoEvento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encargadoEvento);
        }

        // GET: EncargadoEventoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncargadoEvento encargadoEvento = db.EncargadoEventoes.Find(id);
            if (encargadoEvento == null)
            {
                return HttpNotFound();
            }
            return View(encargadoEvento);
        }

        // POST: EncargadoEventoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Encargado,NombreEncargado,TelefonoEncargado,EmailEncargado")] EncargadoEvento encargadoEvento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encargadoEvento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encargadoEvento);
        }

        // GET: EncargadoEventoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncargadoEvento encargadoEvento = db.EncargadoEventoes.Find(id);
            if (encargadoEvento == null)
            {
                return HttpNotFound();
            }
            return View(encargadoEvento);
        }

        // POST: EncargadoEventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EncargadoEvento encargadoEvento = db.EncargadoEventoes.Find(id);
            db.EncargadoEventoes.Remove(encargadoEvento);
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
