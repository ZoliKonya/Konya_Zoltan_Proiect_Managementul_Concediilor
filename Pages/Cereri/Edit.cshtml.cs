using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;
using Microsoft.AspNetCore.Authorization;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Cereri
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public EditModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
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

            var cerere =  await _context.Cerere.FirstOrDefaultAsync(m => m.ID == id);
            if (cerere == null)
            {
                return NotFound();
            }
            Cerere = cerere;
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "FullName");
            ViewData["CategorieCerereID"] = new SelectList(_context.Set<CategorieCerere>(), "ID", "NumeCategorieCerere");
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "NumeDepartament");
            ViewData["FunctieID"] = new SelectList(_context.Set<Functie>(), "ID", "NumeFunctie");
            ViewData["StareCerereID"] = new SelectList(_context.Set<StareCerere>(), "ID", "NumeStareCerere");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cerere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CerereExists(Cerere.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CerereExists(int id)
        {
          return (_context.Cerere?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
