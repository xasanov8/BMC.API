using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMC.Domain;
using BMC.Domain.Entities.Models;

namespace BMC.Application.Abstraction
{
    public interface IBMCProjDbContext
    {
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Restoran> Restorans { get; set; }
        public DbSet<AboutWorker> AboutWorkers { get; set; }
        public DbSet<ClientModel> ClientModels { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
