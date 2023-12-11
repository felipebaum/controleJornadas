using controleJornadas.Data;
using controleJornadas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            var usuario = this.Usuarios.Where(x => x.Id == id).FirstOrDefault();
            if(usuario is null)
            {
                //erro
            }
            await this.applicationDbContext.Usuarios.ExecuteUpdateAsync(p => p.SetProperty(x => x.EmailConfirmed, !usuario.Ativo));
            await this.applicationDbContext.SaveChangesAsync();

            return Page();
        }
    }
}
