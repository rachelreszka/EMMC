using EMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMMC.DAO
{
    public class CategoriaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        public static List<Categoria> ListarCategorias()
        {
            try
            {
                return entities.Categorias.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Categoria> RetornarListaDeCategoriasDoAdministradorLogado()
        {
            try
            {
                Administrador a = new Administrador();
                a = LoginAdministradorDAO.RetornaAdminLogado();
                return entities.Categorias.Where(x => x.AdministradorId.Equals(a.AdministradorId)).ToList();
            }
            catch
            {
                return null;
            }
        }




    }
}