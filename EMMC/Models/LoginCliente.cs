using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMMC.Models
{
    [Table("LoginClientes")]
    public class LoginCliente
    {
        [Key]
        public int LoginClienteId { get; set; }

        public Cliente LoginClienteCli { get; set; }
        public string LoginClienteSessao { get; set; }
    }
}