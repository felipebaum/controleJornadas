using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using controleJornadas.Models;

namespace controleJornadas.Pages
{
    public class HomeModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;

        public HomeModel(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return RedirectToPage("/Index"); // Redirecionar para a página inicial ou outra página de sua escolha
        }
    }
}
