﻿using Common.Enumerations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public string Bio { get; set; }

        public ColorTheme CurrentTheme { get; set; }
    }
}