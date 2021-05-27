using Core.Entites.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class ApplicationUser: IdentityUser
    {
        public string Country { get; set; }

        public string ProfilePic { get; set; }

    }
}
