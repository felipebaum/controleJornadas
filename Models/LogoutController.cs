using controleJornadas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace controleJornadas.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;

        public LogoutController(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return RedirectToPage("/Home/Index"); ; // Redirecionar para a página inicial ou outra página de sua escolha
        }
    }
}
