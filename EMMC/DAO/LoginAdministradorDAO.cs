using EMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMMC.DAO
{
    public class LoginAdministradorDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        // ADD Login Admin
        public static bool AdicionaLoginAdmin(Administrador admin)
        {
            try
            {
                LoginAdministrador login = new LoginAdministrador();
                login.LoginAdministradorAdm = admin;
                login.LoginAdministradorSessao = RetornarIdSessao();
                entities.LoginAdministradores.Add(login);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //RETORNAR ADMINISTRADOR LOGADO
        public static Administrador RetornaAdminLogado()
        {
            try
            {
                foreach (LoginAdministrador temp in ListarLoginAdmin())
                {
                    if (temp.LoginAdministradorSessao.Equals(RetornarIdSessao()))
                    {
                        foreach (Administrador tempAdmin in AdministradorDAO.ListarAdministradores())
                        {
                            if (temp.LoginAdministradorAdm.AdministradorId.Equals(tempAdmin.AdministradorId))
                            {
                                return tempAdmin;
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


        // Lista de login de Administradores
        public static List<LoginAdministrador> ListarLoginAdmin()
        {
            try
            {
                return entities.LoginAdministradores.ToList();
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