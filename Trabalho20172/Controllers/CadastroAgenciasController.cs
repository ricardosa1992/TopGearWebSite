using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class CadastroAgenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CadastroAgencias
        public ActionResult Index()
        {
            var agencias = TopGearApiDataAccess<IEnumerable<Agencia>>.Get("agencia");
            return View(agencias);
        }

        // GET: CadastroAgencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{id}");
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // GET: CadastroAgencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroAgencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Rua,Numero,Bairro,Cidade,Estado")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                TopGearApiDataAccess<Agencia>.Post(agencia, "agencia");
                return RedirectToAction("Index");
            }

            return View(agencia);
        }

        // GET: CadastroAgencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{id}");
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: CadastroAgencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Rua,Numero,Bairro,Cidade,Estado")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                TopGearApiDataAccess<Agencia>.Put(agencia, agencia.Id, "agencia");
                return RedirectToAction("Index");
            }
            return View(agencia);
        }

        // GET: CadastroAgencias/Delete/5
        public ActionResult Delete(int? id)
        {
            List<int> lista = new List<int>() {7,8,9,10,11,12,13,14,15 };
            foreach (var item in lista)
            {
                TopGearApiDataAccess<Cliente>.Delete(item, "cliente");

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{id}");
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: CadastroAgencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agencia agencia = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{id}");
            TopGearApiDataAccess<Agencia>.Delete(id, "agencia");
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
