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
    public class IndexModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public IndexModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Usuarios> Usuarios { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuarios.ToListAsync();
        }
    }
}
