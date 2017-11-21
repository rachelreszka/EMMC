using EMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMMC.DAO
{
    public class AdministradorDAO
    {
        private static Entities entities = Singleton.Instance.Entities;


        public static List<Administrador> ListarAdministradores()
        {
            return entities.Administradores.ToList();
        }

        //VERIFICA CPF CADASTRADO
        public static bool VerificaCpfCadastro(string cpf)
        {
            try
            {
                foreach (Administrador temp in ListarAdministradores())
                {
                    if (temp.AdministradorCpf.Equals(cpf))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
