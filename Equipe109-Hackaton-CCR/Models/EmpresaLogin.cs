using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Equipe109_Hackaton_CCR.Models
{
    public class EmpresaLogin 
    {
        [Key]
        public string Id { get; set; }


        [Required]
        public bool isEmpresa { get; set; }
    }
}
