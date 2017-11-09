using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMMC.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Display(Name = "Nome da Categoria")]
        public string CategoriaNome { get; set; }
        [Display(Name = "Descrição da Categoria")]
        public string CategoriaDescricao { get; set; }
    }
}