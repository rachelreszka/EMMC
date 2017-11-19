using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMMC.DAO;
using EMMC.Models;


namespace EMMC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Usuario *
        public ActionResult Index()
        {
            Cliente c = new Cliente();
           c = ClienteDAO.RetornarClienteLogado();

            if (c != null)
            {
                return View(c);
            }
            else
            {
                ModelState.AddModelError("", "É necessário fazer Login para acessar o site");
            }
            return RedirectToAction("Login", "Cliente");
        }

        
        // GET: Clientes/Details/5 *
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = ClienteDAO.BuscarClientePorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Clientes/Create * 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "ClienteCpf,ClienteNome,ClienteEndereco,ClienteSenha")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Cliente c = new Cliente();

                c.ClienteNome = cliente.ClienteNome;
                c.ClienteCpf = cliente.ClienteCpf;
                c.ClienteEndereco = cliente.ClienteEndereco;
                c.ClienteSenha = cliente.ClienteSenha;

                if (ClienteDAO.VerificaCpfCadastrado(c.ClienteCpf))
                {
                    ViewBag.Mensagem = "CPF já existe!";
                    return View();
                }
                else
                {
                    if (ClienteDAO.AdicionarCliente(cliente))
                    {
                        return RedirectToAction("Login", "Cliente");
                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }
                }
            }

            return View(cliente);
        }


        // GET: Clientes/Edit/5 * 
        public ActionResult Editar(int? id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = ClienteDAO.BuscarClientePorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5 * 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ClienteCpf,ClienteNome,ClienteEndereco,ClienteSenha")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Cliente c = ClienteDAO.BuscarClientePorId(cliente.ClienteId);
                c.ClienteNome = cliente.ClienteNome;
                c.ClienteEndereco = cliente.ClienteEndereco;
                c.ClienteSenha = cliente.ClienteSenha;

                if (ClienteDAO.EditarCliente(c))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }


        // GET: Clientes/Delete/5 *
        public ActionResult Deletar(int? id)
        {

            if (LoginClienteDAO.RetornaClienteLogado() != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cliente cliente = ClienteDAO.BuscarClientePorId(id);
                if (cliente == null)
                {
                    return HttpNotFound();
                }
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Login", "Cliente");
            }
        }


        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Cliente cliente = ClienteDAO.BuscarClientePorId(id);
            if (ClienteDAO.RemoverCliente(cliente))
            {
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        
        //GET:LOGIN
        public ActionResult Login()
        {
            Cliente c = new Cliente();
            c = LoginClienteDAO.RetornaClienteLogado();
            if (c != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // POST: Cliente/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "ClienteCpf,ClienteSenha")] Cliente cliente)
        {
            Cliente c = new Cliente();
            if (ModelState.IsValid)
            {
                c.ClienteCpf = cliente.ClienteCpf;
                c.ClienteSenha = cliente.ClienteSenha;

                c = ClienteDAO.LoginCliente(c);

                if (c != null)
                { // DIFERENTE DE 0 ENTAO É A ID DO USUARIO
                    LoginClienteDAO.AdicionaLoginCliente(c);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Dados inválidos");
                }
            }
            return View();
        }

        // Logoff
        public ActionResult Logoff()
        {
            Guid guid = Guid.NewGuid();
            Session["Sessao"] = guid.ToString();
            return RedirectToAction("Login");
        }

    }
}
