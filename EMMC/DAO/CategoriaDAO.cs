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
    }
}