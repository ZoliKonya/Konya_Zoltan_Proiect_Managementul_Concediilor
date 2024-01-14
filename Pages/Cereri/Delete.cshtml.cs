using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;
using Microsoft.AspNetCore.Authorization;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Cereri
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public DeleteModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cerere Cerere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cerere == null)
            {
                return NotFound();
            }

            var cerere = await _context.Cerere.FirstOrDefaultAsync(m => m.ID == id);

            if (cerere == null)
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
            {
                Cerere = cerere;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cerere == null)
            {
                return NotFound();
            }
            var cerere = await _context.Cerere.FindAsync(id);

            if (cerere != null)
            {
                Cerere = cerere;
                _context.Cerere.Remove(Cerere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
