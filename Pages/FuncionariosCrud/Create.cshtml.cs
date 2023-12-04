using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class CreateModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public CreateModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["fodase"] = new SelectList(_context.Bases, "Id", "Sigla");
            return Page();
        }

        [BindProperty]
        public funcionarios funcionarios { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
        

            _context.funcionarios.Add(funcionarios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
