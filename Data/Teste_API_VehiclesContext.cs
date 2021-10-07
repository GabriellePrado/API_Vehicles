using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_API_Vehicles.Models;

namespace Teste_API_Vehicles.Data
{
    public class Teste_API_VehiclesContext : DbContext
    {
        public Teste_API_VehiclesContext (DbContextOptions<Teste_API_VehiclesContext> options)
            : base(options)
        {
        }

        public DbSet<Teste_API_Vehicles.Models.Vehicle> Vehicle { get; set; }
    }
}
