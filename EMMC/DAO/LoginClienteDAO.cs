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

        // ADD Login Cli
        public static bool AdicionaLogin(Cliente cli)
        {
            try
            {
                LoginCliente login = new LoginCliente();
                login.LoginClienteCli = cli;
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

        //RETORNAR CLIENTE LOGADO
        public static Cliente RetornaCliLogado()
        {
            try
            {
                foreach (LoginCliente temp in ListarLoginCli())
                {
                    if (temp.LoginClienteSessao.Equals(RetornarIdSessao()))
                    {
                        foreach (Cliente tempCli in ClienteDAO.ListarClientes())
                        {
                            if (temp.LoginClienteCli.ClienteId.Equals(tempCli.ClienteId))
                            {
                                return tempCli;
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


        // Lista de login de Clientes
        public static List<LoginCliente> ListarLoginCli()
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
                //ESTE GUID GERA UMA SERIE ALFANUMERICA UNICA PARA CADA CARRINHO
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["Sessao"] = guid.ToString();
            }
            return HttpContext.Current.Session["Sessao"].ToString();
        }

    }
}