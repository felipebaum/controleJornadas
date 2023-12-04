using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class DetailsModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DetailsModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public funcionarios funcionarios { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.funcionarios.FirstOrDefaultAsync(m => m.id == id);
            if (funcionarios == null)
            {
                return NotFound();
            }
            else
            {
                this.funcionarios = funcionarios;
            }
            return Page();
        }
    }
}
