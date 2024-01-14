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

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Pages.Stari
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext _context;

        public IndexModel(Konya_Zoltan_Proiect_Managementul_Concediilor.Data.Konya_Zoltan_Proiect_Managementul_ConcediilorContext context)
        {
            _context = context;
        }

        public IList<StareCerere> StareCerere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StareCerere != null)
            {
                StareCerere = await _context.StareCerere.ToListAsync();
            }
        }
    }
}
