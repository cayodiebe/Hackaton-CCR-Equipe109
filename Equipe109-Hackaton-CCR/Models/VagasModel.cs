using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Equipe109_Hackaton_CCR.Models
{
    public class VagasModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Data Expiração")]
        public DateTime DataExpiracao { get; set; }

        [Required]
        [Display(Name = "Data Criação")]
        public DateTime DataCriacao { get; set; }
        
        [Required]
        [Display(Name = "EmpresaModelID")]
        public Guid EmpresaModel { get; set; }

    }
}
