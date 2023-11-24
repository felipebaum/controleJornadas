using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.JornadasCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DetailsModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Jornadas Jornadas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornadas = await _context.Jornadas.FirstOrDefaultAsync(m => m.id == id);
            if (jornadas == null)
            {
                return NotFound();
            }
            else
            {
                Jornadas = jornadas;
            }
            return Page();
        }
    }
}
