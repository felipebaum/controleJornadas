using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.BasesCrud
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

            return Page();
        }

        [BindProperty]
        public Bases Bases { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["Mensagem"] = "Linha 36Registro salvo com sucesso!";

                return Page();
            }

            try
            {
                _context.Bases.Add(Bases);

            }
            catch (Exception)
            {
                TempData["Mensagem"] = "Linha 47Erro ao salvar no banco de dados!";
            }
            

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }

    }
}
