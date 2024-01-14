using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Cereri
{
    public class DetailsModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public DetailsModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        public Cerere Cerere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cerere == null)
            {
                return NotFound();
            }
            
            Cerere = await _context.Cerere
                .Include(c => c.Angajat)
                .Include(c => c.CategorieCerere)
                .Include(c => c.Departament)
                .Include(c => c.Functie)
                .Include(c => c.StareCerere)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Cerere == null)
            {
                return NotFound();
            }

            
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "FullName");
            ViewData["CategorieCerereID"] = new SelectList(_context.Set<CategorieCerere>(), "ID", "NumeCategorieCerere");
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "NumeDepartament");
            ViewData["FunctieID"] = new SelectList(_context.Set<Functie>(), "ID", "NumeFunctie");
            ViewData["StareCerereID"] = new SelectList(_context.Set<StareCerere>(), "ID", "NumeStareCerere");
            return Page();
        }
    }
}
