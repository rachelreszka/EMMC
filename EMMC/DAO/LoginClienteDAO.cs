using EMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMMC.DAO
{
    public class LoginClienteDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        public static bool AdicionaLoginCliente(Cliente cliente)
        {
            try
            {
                LoginCliente login = new LoginCliente();
                login.LoginClienteCli = cliente;
                login.LoginClienteSessao = RetornarIdSessao();
                entities.LoginClientes.Add(login);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //LISTAR TODOS
        public static List<LoginCliente> ListarLoginCliente()
        {
            try
            {
                return entities.LoginClientes.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //RETORNAR CLIENTE LOGADO
        public static Cliente RetornaClienteLogado()
        {
            try
            {
                foreach (LoginCliente temp in ListarLoginCliente())
                {
                    if (temp.LoginClienteSessao.Equals(RetornarIdSessao()))
                    {
                        foreach (Cliente tempCliente in ClienteDAO.ListarClientes())
                        {
                            if (temp.LoginClienteCli.ClienteId.Equals(tempCliente.ClienteId))
                            {
                                return tempCliente;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        //RETORNAR LISTA DE LOGINS
        public static List<LoginCliente> RetornarListaLoginsClientes()
        {
            try
            {
                return entities.LoginClientes.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //RETORNA OU GERA ID PRA SESSão
        public static string RetornarIdSessao()
        {
            if (HttpContext.Current.Session["Sessao"] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["Sessao"] = guid.ToString();
            }
            return HttpContext.Current.Session["Sessao"].ToString();
        }
    }

}




