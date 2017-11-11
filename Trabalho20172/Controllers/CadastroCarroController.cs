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
    public class CadastroCarroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CadastroCarro
        public ActionResult Index()
        {
            var carros = TopGearApiDataAccess<IEnumerable<Carro>>.Get("carro");
            return View(carros);
        }

        // GET: CadastroCarro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = TopGearApiDataAccess<Carro>.Get($"carro/porid/{id}");
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: CadastroCarro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroCarro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Modelo,Marca,Placa,Ano,UrlImagem,AgenciaId,CategoriaId")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                TopGearApiDataAccess<Carro>.Post(carro, "carro");
                return RedirectToAction("Index");
            }

            return View(carro);
        }

        // GET: CadastroCarro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = TopGearApiDataAccess<Carro>.Get($"carro/porid/{id}");
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: CadastroCarro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Modelo,Marca,Placa,Ano,UrlImagem,AgenciaId,CategoriaId")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                TopGearApiDataAccess<Carro>.Put(carro, carro.Id ,"carro");
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        // GET: CadastroCarro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = TopGearApiDataAccess<Carro>.Get($"carro/porid/{id}");
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: CadastroCarro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = TopGearApiDataAccess<Carro>.Get($"carro/porid/{id}");
            TopGearApiDataAccess<Carro>.Delete(id, "carro");
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
