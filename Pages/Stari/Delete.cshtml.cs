using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Stari
{
    public class DeleteModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public DeleteModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public StareCerere StareCerere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StareCerere == null)
            {
                return NotFound();
            }

            var starecerere = await _context.StareCerere.FirstOrDefaultAsync(m => m.ID == id);

            if (starecerere == null)
            {
                return NotFound();
            }
            else 
            {
                StareCerere = starecerere;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StareCerere == null)
            {
                return NotFound();
            }
            var starecerere = await _context.StareCerere.FindAsync(id);

            if (starecerere != null)
            {
                StareCerere = starecerere;
                _context.StareCerere.Remove(StareCerere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
