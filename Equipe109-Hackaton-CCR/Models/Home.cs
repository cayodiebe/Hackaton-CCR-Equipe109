using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Equipe109_Hackaton_CCR.Models
{
    public class Home
    {
        [Key]
        public Guid Id { get; set; }

        public IEnumerable<VagasModel> vagasModels { get; set; }
    }
}
