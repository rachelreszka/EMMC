using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMMC.Models;
using EMMC.DAO;

namespace EMMC.Controllers
{
    public class CategoriaController : Controller
    {
        private Entities db = new Entities();

        // GET: Categorias
        public ActionResult Index()
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                return View(CategoriaDAO.RetornarListaDeCategoriasDoAdministradorLogado());
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // GET: Categorias/Details/5
        public ActionResult Detalhes(int? id)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Categoria categoria = db.Categorias.Find(id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // GET: Categorias/Create
        public ActionResult Cadastro()
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "CategoriaId,CategoriaNome,CategoriaDescricao, AdministradorId")] Categoria categoria)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                if (ModelState.IsValid)
                {
                    Administrador admin = new Administrador();
                    a = LoginAdministradorDAO.RetornaAdminLogado();
                    categoria.AdministradorId = a.AdministradorId;
                    db.Categorias.Add(categoria);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(categoria);
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Editar(int? id)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Categoria categoria = db.Categorias.Find(id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CategoriaId,CategoriaNome,CategoriaDescricao")] Categoria categoria)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                if (ModelState.IsValid)
                {
                    categoria.AdministradorId = a.AdministradorId;
                    db.Entry(categoria).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Deletar(int? id)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Categoria categoria = db.Categorias.Find(id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                Categoria categoria = db.Categorias.Find(id);
                categoria.AdministradorId = a.AdministradorId;
                db.Categorias.Remove(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
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
