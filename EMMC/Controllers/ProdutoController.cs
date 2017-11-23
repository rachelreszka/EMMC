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
        private Entities db = Singleton.Instance.Entities;

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.categoria);
            return View(ProdutoDAO.RetornarListaDeProdutosDoAdministradorLogado());
        }

        // GET: Produto/Details/5
        public ActionResult Detalhes(int? id)
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
        }

        // GET: Produto/Create
        public ActionResult Cadastro()
        {
            List<Categoria> ListaCategoria = new List<Categoria>();
            ListaCategoria = CategoriaDAO.RetornarListaDeCategoriasDoAdministradorLogado();
            ViewBag.CategoriaId = new SelectList(ListaCategoria, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoQuantidade,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                Administrador a = new Administrador();
                a = LoginAdministradorDAO.RetornaAdminLogado();
                produto.AdministradorId = a.AdministradorId;
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Editar(int? id)
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
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoQuantidade,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Deletar(int? id)
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
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
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
