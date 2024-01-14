﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Departamente
{
    public class DeleteModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public DeleteModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Departament Departament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament.FirstOrDefaultAsync(m => m.ID == id);

            if (departament == null)
            {
                return NotFound();
            }
            else 
            {
                Departament = departament;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }
            var departament = await _context.Departament.FindAsync(id);

            if (departament != null)
            {
                Departament = departament;
                _context.Departament.Remove(Departament);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
