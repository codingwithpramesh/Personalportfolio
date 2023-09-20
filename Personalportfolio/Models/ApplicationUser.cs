﻿using Microsoft.AspNetCore.Identity;

namespace Personalportfolio.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string? ProfilePicture { get; set; }
    }
}
