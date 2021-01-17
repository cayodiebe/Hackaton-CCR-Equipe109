using Equipe109_Hackaton_CCR.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equipe109_Hackaton_CCR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<EmpresaModel> EmpresaModels { get; set; }
        public DbSet<VagasModel> VagasModel { get; set; }
        public DbSet<EmpresaLogin> EmpresaLogin { get; set; }
        public DbSet<VagasCandidatoModel> VagasCandidato { get; set; }
        public DbSet<Home> Home { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
