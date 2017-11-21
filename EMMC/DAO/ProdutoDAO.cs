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

        public static List<Produto> RetornarListaDeProdutosDoAdministradorLogado()
        {
            try
            {
                Administrador a = new Administrador();
                a = LoginAdministradorDAO.RetornaAdminLogado();
                return entities.Produtos.Where(x => x.AdministradorId.Equals(a.AdministradorId)).ToList();
            }catch
            {
                return null;
            }
        }




    }
}