using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;
using BEUEjercicio.Transactions;

namespace PryEjercicio.Controllers
{
    public class MatriculasController : Controller
    {        

        // GET: Matriculas
        public ActionResult Index()
        {            
            return View(MatriculaBLL.List());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.tipo = new SelectList( new List<string> {"Primera", "Segunda", "Tercera" });
            ViewBag.idalumno = new SelectList(AlumnoBLL.ListToNames(), "idalumno", "nombres");
            ViewBag.idmateria = new SelectList(MateriaBLL.ListToNames(), "idmateria", "nombre");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmatricula,tipo,idalumno,idmateria")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {                
                MatriculaBLL.Create(matricula);                
                return RedirectToAction("Index");
            }

            ViewBag.idalumno = new SelectList(AlumnoBLL.ListToNames(), "idalumno", "nombres", matricula.idalumno);
            ViewBag.idmateria = new SelectList(MateriaBLL.ListToNames(), "idmateria", "nombre", matricula.idmateria);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.idalumno = new SelectList(AlumnoBLL.ListToNames(), "idalumno", "nombres", matricula.idalumno);
            ViewBag.idmateria = new SelectList(MateriaBLL.ListToNames(), "idmateria", "nombre", matricula.idmateria);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmatricula,tipo,idalumno,idmateria")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                MatriculaBLL.Update(matricula);
                return RedirectToAction("Index");
            }
            ViewBag.idalumno = new SelectList(AlumnoBLL.ListToNames(), "idalumno", "nombres", matricula.idalumno);
            ViewBag.idmateria = new SelectList(MateriaBLL.ListToNames(), "idmateria", "nombre", matricula.idmateria);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatriculaBLL.Delete(id);
            return RedirectToAction("Index");
        }
       
    }
}
