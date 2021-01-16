using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Equipe109_Hackaton_CCR.Models
{
    public class EmpresaModel
    {
        [Key]
        public Guid IdEmpresa { get; set; }


        [Required]
        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        [Required]
        [Display(Name = "Ramo")]
        public string Ramo { get; set; }

        [Required]
        [Display(Name = "QtdeFuncionarios")]
        public string QtdeFuncionarios { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
        
        [Required]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Logo")]
        public string Logo { get; set; }

    }
}
