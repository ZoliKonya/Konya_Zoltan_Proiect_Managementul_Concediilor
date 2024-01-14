using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Cereri
{
    public class IndexModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public IndexModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        public IList<Cerere> Cerere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cerere != null)
            {
                Cerere = await _context.Cerere
                .Include(c => c.Angajat)
                .Include(c => c.CategorieCerere)
                .Include(c => c.Departament)
                .Include(c => c.Functie)
                .Include(c => c.StareCerere).ToListAsync();
            }
        }
    }
}
