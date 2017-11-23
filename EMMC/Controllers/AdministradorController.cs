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
    public class AdministradorController : Controller
    {
        private Entities db = new Entities();

        // GET: Administradores
        public ActionResult Index()
        {

            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                return View(ProdutoDAO.RetornarListaDeProdutosDoAdministradorLogado());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Administradores/Details/5
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
                Administrador administrador = db.Administradores.Find(id);
                if (administrador == null)
                {
                    return HttpNotFound();
                }
                return View(administrador);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Administradores/Create
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "AdministradorId,AdministradorCpf,AdministradorNome,AdministradorSenha")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Administradores.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        // GET: Administradores/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "AdministradorId,AdministradorCpf,AdministradorNome,AdministradorSenha")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: Administradores/Delete/5
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
                Administrador administrador = db.Administradores.Find(id);
                if (administrador == null)
                {
                    return HttpNotFound();
                }
                return View(administrador);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = db.Administradores.Find(id);
            db.Administradores.Remove(administrador);
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

        //GET:LOGIN
        public ActionResult Login()
        {
            LoginAdministradorDAO.Logoff();
            Administrador a = new Administrador();
            a = LoginAdministradorDAO.RetornaAdminLogado();
            if (a != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // POST: Administrador/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "AdministradorCpf,AdministradorSenha")] Administrador administrador)
        {

            Administrador a = new Administrador();
            if (ModelState.IsValid)
            {
                a.AdministradorCpf = administrador.AdministradorCpf;
                a.AdministradorSenha = administrador.AdministradorSenha;

                a = LoginAdministradorDAO.LoginAdministrador(a);

                if (a != null)
                { // DIFERENTE DE 0 ENTAO É A ID DO USUARIO
                    LoginAdministradorDAO.AdicionaLoginAdmin(a);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Dados inválidos");
                }
            }
            return View();
        }

        public ActionResult Logoff()
        {
            Guid guid = Guid.NewGuid();
            Session["Sessao"] = guid.ToString();
            return RedirectToAction("Login");
        }


    }
}
