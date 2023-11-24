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
    public class DeleteModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DeleteModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                funcionarios = funcionarios;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.funcionarios.FindAsync(id);
            if (funcionarios != null)
            {
                funcionarios = funcionarios;
                _context.funcionarios.Remove(funcionarios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
