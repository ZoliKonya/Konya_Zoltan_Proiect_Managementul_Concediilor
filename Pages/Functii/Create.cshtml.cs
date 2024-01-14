using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Models;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Functii
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
            return Page();
        }

        [BindProperty]
        public Functie Functie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Functie == null || Functie == null)
            {
                return Page();
            }

            _context.Functie.Add(Functie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
