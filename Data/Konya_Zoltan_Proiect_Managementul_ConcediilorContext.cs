using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Data
{
    public class Konya_Zoltan_Proiect_Managementul_ConcediilorContext : DbContext
    {
        public Konya_Zoltan_Proiect_Managementul_ConcediilorContext (DbContextOptions<Konya_Zoltan_Proiect_Managementul_ConcediilorContext> options)
            : base(options)
        {
        }

        public DbSet<Konya_Zoltan_Proiect_Managementul_Concediilor.Models.Cerere> Cerere { get; set; } = default!;

        public DbSet<Konya_Zoltan_Proiect_Managementul_Concediilor.Models.Angajat>? Angajat { get; set; }

        public DbSet<Konya_Zoltan_Proiect_Managementul_Concediilor.Models.CategorieCerere>? CategorieCerere { get; set; }

        public DbSet<Konya_Zoltan_Proiect_Managementul_Concediilor.Models.Departament>? Departament { get; set; }

        public DbSet<Konya_Zoltan_Proiect_Managementul_Concediilor.Models.Functie>? Functie { get; set; }

        public DbSet<Konya_Zoltan_Proiect_Managementul_Concediilor.Models.StareCerere>? StareCerere { get; set; }
    }
}
