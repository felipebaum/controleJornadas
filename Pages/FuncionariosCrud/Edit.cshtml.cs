using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class EditModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public EditModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcionarios funcionarios { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios =  await _context.funcionarios.FirstOrDefaultAsync(m => m.id == id);
            if (funcionarios == null)
            {
                return NotFound();
            }
            this.funcionarios = funcionarios;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["Mensagem"] = "Erro ao salvar Funcionário";
                return Page();
            }
            try
            {
            _context.funcionarios.Update(this.funcionarios);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!funcionariosExists(funcionarios.id))
                {
                    return Page();

                }
                else
                {
                    throw;
                }
            }
            TempData["Mensagem"] = "Funcionário salvo com sucesso!";

            return RedirectToPage("./Index");
        }

        private bool funcionariosExists(int id)
        {
            return _context.funcionarios.Any(e => e.id == id);
        }
    }
}
