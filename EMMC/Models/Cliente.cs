using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMMC.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Display(Name = "CPF")]
        public string ClienteCpf { get; set; }
        [Display(Name = "Nome Completo")]
        public string ClienteNome { get; set; }
        [Display(Name = "Endereço")]
        public string ClienteEndereco { get; set; }
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]   
        public string ClienteSenha { get; set; }
    }
}