﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMMC.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; }
        [Display(Name = "Descrição do Produto")]
        public string ProdutoDescricao { get; set; }
        [Display(Name = "Quantidade")]
        public int ProdutoQuantidade { get; set; }
        public Categoria categoria { get; set; }

        public int CategoriaId { get; set; }

        public int AdministradorId { get; set; }
    }
}