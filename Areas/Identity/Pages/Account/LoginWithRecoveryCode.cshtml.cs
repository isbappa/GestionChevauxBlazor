using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GestionChevauxBlazor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GestionChevauxBlazor.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginWithRecoveryCodeModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginWithRecoveryCodeModel> _logger;

        public LoginWithRecoveryCodeModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginWithRecoveryCodeModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [BindProperty]
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Code de récupération")]
            public string RecoveryCode { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"Impossible de charger l'utilisateur d'authentification à deux facteurs.");
            }

            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"Impossible de charger l'utilisateur d'authentification à deux facteurs.");
            }

            var recoveryCode = Input.RecoveryCode.Replace(" ", string.Empty);

            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                _logger.LogInformation("Utilisateur avec ID '{UserId}' connecté avec un code de récupération.", user.Id);
                return LocalRedirect(returnUrl ?? Url.Content("~/"));
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("Utilisateur avec ID '{UserId}' compte verrouillé.", user.Id);
                return RedirectToPage("./Lockout");
            }
            else
            {
                _logger.LogWarning("Code de récupération non valide saisi pour l'utilisateur avec ID '{UserId}' ", user.Id);
                ModelState.AddModelError(string.Empty, "Code de récupération non valide saisi.");
                return Page();
            }
        }
    }
}
