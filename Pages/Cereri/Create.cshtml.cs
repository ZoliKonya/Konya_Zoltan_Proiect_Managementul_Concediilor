using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Cereri
{
    public class CreateModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public CreateModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "FullName");
            ViewData["CategorieCerereID"] = new SelectList(_context.Set<CategorieCerere>(), "ID", "NumeCategorieCerere");
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "NumeDepartament");
            ViewData["FunctieID"] = new SelectList(_context.Set<Functie>(), "ID", "NumeFunctie");

            // Adaugă manual o instanță de StareCerere pentru a o preselecta
            var stareCerereList = _context.Set<StareCerere>()
                .Where(s => s.NumeStareCerere == "Nou")
                .ToList();
            ViewData["StareCerereID"] = new SelectList(stareCerereList, "ID", "NumeStareCerere");

            return Page();
        }

        [BindProperty]
        public Cerere Cerere { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cerere == null || Cerere == null)
            {
                return Page();
            }

            _context.Cerere.Add(Cerere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
