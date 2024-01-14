﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Categorii
{
    public class DeleteModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public DeleteModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CategorieCerere CategorieCerere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CategorieCerere == null)
            {
                return NotFound();
            }

            var categoriecerere = await _context.CategorieCerere.FirstOrDefaultAsync(m => m.ID == id);

            if (categoriecerere == null)
            {
                return NotFound();
            }
            else 
            {
                CategorieCerere = categoriecerere;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CategorieCerere == null)
            {
                return NotFound();
            }
            var categoriecerere = await _context.CategorieCerere.FindAsync(id);

            if (categoriecerere != null)
            {
                CategorieCerere = categoriecerere;
                _context.CategorieCerere.Remove(CategorieCerere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
