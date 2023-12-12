using controleJornadas.Data;
using controleJornadas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace controleJornadas.Pages
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }

        public string Usuario { get; set; }

        public string Email { get; set; }

        public bool Ativo { get; set; }
    }

    public class UsuariosModel(UserManager<Usuario> userManager, ApplicationDbContext applicationDbContext) : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        private readonly UserManager<Usuario> UserManager = userManager;

        public List<UsuarioViewModel> Usuarios { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            this.Usuarios =await this.UserManager.Users.Select(x => new UsuarioViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Usuario = x.UserName,
                Ativo = x.EmailConfirmed
            }).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            var usuario2 = this.UserManager.Users.First(x => x.Id == id);
            usuario2.EmailConfirmed = !usuario2.EmailConfirmed;
            await this.applicationDbContext.SaveChangesAsync();
            
            return RedirectToPage("./usuarios");
        }
    }
}
