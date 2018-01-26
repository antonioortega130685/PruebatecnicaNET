using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;

namespace WebApplication3.Controllers
{
    public class ClienteController : Controller
    {

        //Controlador de CRUD de Clientes

        
        Contexto db = new Contexto();


        //Listado principal de los clientes, página inicial

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = db.Clientes.ToList();

            return View(clientes);
        }


        //Lógica de creación de clientes

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Contexto())
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            

            return View(cliente);
        }


        //Lógica de modificación de datos

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(cliente);
        }


        //Lógica de eliminación 

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View(cliente);
        }


        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente ejemplar = db.Clientes.Find(id);
            db.Clientes.Remove(ejemplar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
