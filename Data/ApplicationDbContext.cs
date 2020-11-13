using System;
using System.Collections.Generic;
using System.Text;
using GestionChevauxBlazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionChevauxBlazor.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<AjoutChevauxModel> GestionChevauxModel { get; set; }
        
        public virtual DbSet<AjoutPlanningReprisesModel> PlanningReprisesModel { get; set; }
        
        public virtual DbSet<ValidationPlanningRepriseModel> ValidationPlanningRepriseModel { get; set; }


    }
}
