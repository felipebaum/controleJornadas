using controleJornadas.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class IndexModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public IndexModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<funcionarios> funcionarios { get;set; } = default!;

        public async Task OnGetAsync()
        {
            this.funcionarios = await _context.funcionarios.Include(a =>a.Bases).ToListAsync();
        }
    }
}
