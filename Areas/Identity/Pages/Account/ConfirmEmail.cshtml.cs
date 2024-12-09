// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using OpDoc_Manager.Data;
using System.Text;

namespace OpDoc_Manager.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<OpDocUser> _userManager;

        public ConfirmEmailModel(UserManager<OpDocUser> userManager)
        {
            _userManager = userManager;
        }

        public string UserFullName;

        [BindProperty]
        public string UserRole { get; set; }

        public List<SelectListItem> RoleSelector { get; set; }


        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            UserFullName = $"{user.LastName} {user.FirstName}";

            RoleSelector = new(){
                new("Adminisztrátor", "Admin"),
                new("Technikus", "Technician"),
                new("Üzemeltető", "Operator")
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            UserFullName = $"{user.LastName} {user.FirstName}";

            RoleSelector = new(){
                new("Adminisztrátor", "Admin"),
                new("Technikus", "Technician"),
                new("Üzemeltető", "Operator")
            };

            if (UserRole == "")
            {
                StatusMessage = "Hiba! Felhasználói szerepkör megadása kötelező!";
                return Page();
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                StatusMessage = "Hiba! A felhasználó megerősítése sikertelen.";
                return Page();
            }

            var result2 = await _userManager.AddToRoleAsync(user, UserRole);
            StatusMessage = result2.Succeeded ? $"{user.LastName} {user.FirstName} regisztrációja sikeres!" : "Hiba! A felhasználói szerepkör hozzárendelése sikertelen.";

            return Page();
        }
    }
}
