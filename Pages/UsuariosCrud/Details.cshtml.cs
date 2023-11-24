using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.UsuariosCrud
{
    public class DetailsModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DetailsModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuarios Usuarios { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }
            else
            {
                Usuarios = usuarios;
            }
            return Page();
        }
    }
}
