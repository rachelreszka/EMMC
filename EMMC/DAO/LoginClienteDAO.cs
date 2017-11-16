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


        public static bool AdicionaLogin(Cliente cliente)
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




        public static List<LoginCliente> RetornarListaLoginsClientes()
        {
            try
            {
                return entities.LoginClientes.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        //RETORNA OU GERA ID PRA SESSão
        public static string RetornarIdSessao()
        {
            if (HttpContext.Current.Session["Sessao"] == null)
            {
                //ESTE GUID GERA UMA SERIE ALFANUMERICA UNICA PARA CADA CARRINHO
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["Sessao"] = guid.ToString();
            }
            return HttpContext.Current.Session["Sessao"].ToString();
        }

    }
}