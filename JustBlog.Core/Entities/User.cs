using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JustBlog.Core.Entities
{
    public class User : IdentityUser
    {
        [PersonalData]
        public int Age { get; set; }
        [PersonalData]
        public string AboutMe { get; set; }
    }
}
