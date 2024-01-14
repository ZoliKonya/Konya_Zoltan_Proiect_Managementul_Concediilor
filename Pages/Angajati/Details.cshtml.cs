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

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Angajati
{
    public class DetailsModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public DetailsModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

      public Angajat Angajat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Angajat = await _context.Angajat
                .Include(a => a.Departament)
                .Include(a => a.Functie)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Angajat == null)
            {
                return NotFound();
            }

            ;
            return Page();
        }
    }
}
