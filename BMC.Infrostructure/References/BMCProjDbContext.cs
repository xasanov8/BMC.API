using BMC.Application.Abstraction;
using BMC.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Infrostructure.References
{
    public class BMCProjDbContext : DbContext, IBMCProjDbContext
    {
        public BMCProjDbContext(DbContextOptions<BMCProjDbContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Worker> Worker { get; set; }
        public DbSet<Restoran> Restorans { get; set; }
        public DbSet<AboutWorker> AboutWorkers { get; set; }
        public DbSet<ClientModel> ClientModels { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
