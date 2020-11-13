using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionChevauxBlazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GestionChevauxBlazor.Areas.Identity.Pages.Account.Manage
{
    public class Disable2faModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(
            UserManager<ApplicationUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"Impossible de désactiver 2FA pour l'utilisateur avec ID '{_userManager.GetUserId(User)}' car il n'est pas activé actuellement.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"Une erreur inattendue s'est produite lors de la désactivation de 2FA pour l'utilisateur avec ID '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("Utilisateur avec ID '{UserId}' a désactivé 2fa.", _userManager.GetUserId(User));
            StatusMessage = "2fa a été désactivé. Vous pouvez réactiver 2fa lorsque vous configurez une application d'authentification";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}