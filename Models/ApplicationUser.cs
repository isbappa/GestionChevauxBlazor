using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionChevauxBlazor.Models
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public byte[] ProfilePicture { get; set; }
        //public string Role { get; set; }

    }
}
