using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Presto.DAL;
using Presto.Models;

namespace Presto.Controllers
{
    public class SimulacionesController : Controller
    {
        private PrestoContext db = new PrestoContext();

        // GET: Simulaciones
        public ActionResult Index()
        {
            ViewBag.ListaSim = "active";
            return View(db.Simulaciones.ToList());
        }

        public ActionResult Buscar(string texto) {
            var resultado = db.Simulaciones.Where(m => m.Nombre.IndexOf(texto) != -1);
            if (resultado.Count() == 1) {
                return View("Simulador", resultado.FirstOrDefault());
            } else {
                return View("Index", resultado.ToList());
            }
            return RedirectToAction("Index","Home");
        }

        public PartialViewResult _ultimasSim()
        {
            return PartialView(db.Simulaciones.OrderBy(m => m.FechaModificacion).Take(5));
        }

        public ActionResult Simulador(int? id, bool? nuevo)
        {
            ViewBag.Sim = "active";
            if (id == null || (nuevo != null && nuevo == true))
            {
                return View(new Simulacion());
            }
            Simulacion simulacion = db.Simulaciones.Find(id);
            if (simulacion == null)
            {
                return HttpNotFound();
            }
            return View(simulacion);
           
        }

        // POST: Simulaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Prestamo,Interes,Meses,FechaModificacion,Baja")] Simulacion simulacion)
        {
            ViewBag.Sim = "active";
            //creo
            if (simulacion.ID == 0)
            {
                simulacion.Nombre = "Sim_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond;
                if (ModelState.IsValid)
                {
                    db.Simulaciones.Add(simulacion);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Creado";
                    var idNuevo = simulacion.ID; //porque la visto no recibia bien los datos
                    simulacion = db.Simulaciones.Find(idNuevo);
                }
            }
            //actualizo
            else {
                if (ModelState.IsValid)
                {
                    db.Entry(simulacion).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Mensaje = "Actualizado";
                }
            }           

            return View("Simulador",simulacion);
        }

        // POST: Simulaciones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Simulacion simulacion = db.Simulaciones.Find(id);
            db.Simulaciones.Remove(simulacion);
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
