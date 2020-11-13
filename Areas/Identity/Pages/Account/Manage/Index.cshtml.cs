using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestionChevauxBlazor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GestionChevauxBlazor.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Prénom")]
            public string FirstName { get; set; }
            [Display(Name = "Nom")]
            public string LastName { get; set; }
            [Display(Name = "Numéro de license")]
            public string LicenseNumber { get; set; }
            [Phone]
            [Display(Name = "Numéro de téléphone")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Photo de profil")]
            public byte[] ProfilePicture { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            
            var licenseNumber = user.LicenseNumber;
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;

            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture,
                LicenseNumber = licenseNumber,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erreur inattendue lors de la tentative de définition du numéro de téléphone.";
                    return RedirectToPage();
                }
            }

            var firstName = user.FirstName;
            var lastName = user.LastName;
            var licenseNumber = user.LicenseNumber;
            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LicenseNumber != licenseNumber)
            {
                user.LicenseNumber = Input.LicenseNumber;
                await _userManager.UpdateAsync(user);
            }

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "votre profil a été mis a jour";
            return RedirectToPage();
        }
    }
}
