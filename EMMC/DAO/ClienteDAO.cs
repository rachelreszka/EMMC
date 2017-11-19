using EMMC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EMMC.DAO
{
    public class ClienteDAO
    {
        private static Entities entities = Singleton.Instance.Entities;


        public static bool AdicionarCliente(Cliente cliente)
        {
            try
            {
                entities.Clientes.Add(cliente);
                entities.SaveChanges();
                return true;
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

        //LISTAR
        public static List<Cliente> ListarClientes()
        {
            return entities.Clientes.ToList();
        }

        //BUSCAR POR ID
        public static Cliente BuscarClientePorId(int? id)
        {
            try
            {
                return entities.Clientes.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // Editar
        public static bool EditarCliente(Cliente cliente)
        {

            try
            {
                entities.Entry(cliente).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remover
        public static bool RemoverCliente(Cliente cliente)
        {
            try
            {
                entities.Clientes.Remove(cliente);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //RETORNAR USUARIO LOGADO
        public static Cliente RetornarClienteLogado()
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

    }
}