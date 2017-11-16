using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMMC.Models
{
    [Table("LoginAdministradores")]
    public class LoginAdministrador
    {
        [Key]
        public int LoginAdministradorId { get; set; }
        public Administrador LoginAdministradorAdm { get; set; }

        public string LoginAdministradorSessao { get; set; }
    }
}