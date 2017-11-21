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
    public class ProdutoController : Controller
    {
        private Entities db = new Entities();

        // GET: Produtos
        public ActionResult Index()
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                return View(db.Produtos.ToList());
            }else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // GET: Produtos/Details/5
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
                Produto produto = db.Produtos.Find(id);
                if (produto == null)
                {
                    return HttpNotFound();
                }
                return View(produto);
            }else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // GET: Produtos/Create
        public ActionResult Cadastro()
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                return View();
            }else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoQuantidade")] Produto produto)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                if (ModelState.IsValid)
                {
                    db.Produtos.Add(produto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            else
            {
                return RedirectToAction("Login", "Administrador");
            }
               
        }

        // GET: Produtos/Edit/5
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
                Produto produto = db.Produtos.Find(id);
                if (produto == null)
                {
                    return HttpNotFound();
                }
                return View(produto);
            }else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoQuantidade")] Produto produto)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(produto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // GET: Produtos/Delete/5
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
                Produto produto = db.Produtos.Find(id);
                if (produto == null)
                {
                    return HttpNotFound();
                }
                return View(produto);
            }else
            {
                return RedirectToAction("Login", "Administrador");
            }
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                Produto produto = db.Produtos.Find(id);
                db.Produtos.Remove(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }else
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
