using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Equipe109_Hackaton_CCR.Models
{
    public class VagasCandidatoModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid VagasId { get; set; }

        public string UserId { get; set; }

    }
}
