using controleJornadas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace controleJornadas.Pages
{
    public class IndexModel(SignInManager<Usuario> signInManager) : PageModel
    {
        private readonly SignInManager<Usuario> signInManager = signInManager;

        [BindProperty]
        public string Usuario { get; set; }

        [BindProperty]
        public string Senha { get; set; }

        [BindProperty]
        public bool Erro { get; set; } = false;

        [BindProperty]
        public string? Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var result = await this.signInManager.PasswordSignInAsync(this.Usuario, this.Senha, false, false);
                if (result.Succeeded)
                {
                    return base.RedirectToPage("./Home");
                }

                if (result.IsNotAllowed)
                {
                    throw new Exception("Usuário inativado ou bloqueado");
                }

                throw new Exception("Usuario ou senha incorretos.");
            }
            catch (Exception ex)
            {
                this.Erro = true;
                this.Message = ex.Message;
                return Page();
            }
        }

    }

}


