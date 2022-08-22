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
    public class ShowsController : Controller
    {
        private PrimerParcial_JuanPalaciosEntities db = new PrimerParcial_JuanPalaciosEntities();

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Artista).Include(s => s.EncargadoEvento).Include(s => s.Grupos);
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.ID_Artista = new SelectList(db.Artistas, "ID_Artista", "NombreArtista");
            ViewBag.ID_Encargado = new SelectList(db.EncargadoEventoes, "ID_Encargado", "NombreEncargado");
            ViewBag.ID_Grupo = new SelectList(db.Grupos, "ID_Grupo", "NombreGrupo");
            return View();
        }

        // POST: Shows/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Show,NombreShow,Fecha_Evento,HoraEvento,Cantidad,ID_Artista,ID_Encargado,ID_Grupo")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Artista = new SelectList(db.Artistas, "ID_Artista", "NombreArtista", show.ID_Artista);
            ViewBag.ID_Encargado = new SelectList(db.EncargadoEventoes, "ID_Encargado", "NombreEncargado", show.ID_Encargado);
            ViewBag.ID_Grupo = new SelectList(db.Grupos, "ID_Grupo", "NombreGrupo", show.ID_Grupo);
            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Artista = new SelectList(db.Artistas, "ID_Artista", "NombreArtista", show.ID_Artista);
            ViewBag.ID_Encargado = new SelectList(db.EncargadoEventoes, "ID_Encargado", "NombreEncargado", show.ID_Encargado);
            ViewBag.ID_Grupo = new SelectList(db.Grupos, "ID_Grupo", "NombreGrupo", show.ID_Grupo);
            return View(show);
        }

        // POST: Shows/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Show,NombreShow,Fecha_Evento,HoraEvento,Cantidad,ID_Artista,ID_Encargado,ID_Grupo")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Artista = new SelectList(db.Artistas, "ID_Artista", "NombreArtista", show.ID_Artista);
            ViewBag.ID_Encargado = new SelectList(db.EncargadoEventoes, "ID_Encargado", "NombreEncargado", show.ID_Encargado);
            ViewBag.ID_Grupo = new SelectList(db.Grupos, "ID_Grupo", "NombreGrupo", show.ID_Grupo);
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
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
