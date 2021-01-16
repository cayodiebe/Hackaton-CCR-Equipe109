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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
