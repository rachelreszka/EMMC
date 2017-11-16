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

        public static List<Cliente> ListarClientes()
        {
            return entities.Clientes.ToList();
        }

        public static Cliente RetornarUsuarioLogado()
        {
            try
            {
                foreach (LoginCliente temp in LoginClienteDAO.RetornarListaLoginsClientes())
                {
                    if (temp.LoginClienteSessao.Equals(LoginClienteDAO.RetornarIdSessao()))
                    {
                        foreach (Cliente cli in ListarClientes())
                        {
                            if (temp.LoginClienteCli.ClienteId.Equals(cli.ClienteId))
                            {
                                return cli;
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


        //VERIFICA CPF EXISTENTE
        public static bool VerificaCpfCadastrado(string cpf)
        {
            try
            {
                foreach (Cliente temp in ListarClientes())
                {
                    if (temp.ClienteCpf.Equals(cpf))
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


        public static Cliente LoginCliente(Cliente cliente)
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
            catch (Exception)
            {
                return null;
            }
        }



    }
}