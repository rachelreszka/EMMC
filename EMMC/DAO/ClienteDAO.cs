using EMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMMC.DAO
{
    public class ClienteDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        // ADD Login Cli
        public static bool AdicionaLoginCli(Cliente cli)
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
            catch (Exception e)
            {
                return false;
            }
        }

        //LISTAR TODOS
        public static List<LoginCliente> ListarLoginCli()
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
                            if (temp.LoginClienteCli.ClienteCpf.Equals(tempCli.ClienteId))
                            {
                                return tempCli;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //RETORNA OU GERA ID PRA SESSÃO
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

        public static List<Cliente> ListarClientes()
        {
            return entities.Clientes.ToList();
        }


        // LOGIN
        public static Cliente LoginCli(Cliente cliente)
        {
            try
            {
                foreach (Cliente temp in entities.Clientes.ToList())
                {
                    if (temp.ClienteCpf.Equals(cliente.ClienteCpf))
                    {
                        if (temp.ClienteSenha.Equals(cliente.ClienteSenha))
                        {
                            return temp;
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
