using EMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EMMC.DAO
{
    public class ProdutoDAO
    {

        private static Entities entities = Singleton.Instance.Entities;

        //LISTAR TODOS
        public static List<Produto> ListarProdutos()
        {
            try
            {
                return entities.Produtos.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }



    }
}