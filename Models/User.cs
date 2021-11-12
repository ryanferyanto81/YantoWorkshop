using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace YantoWorkshop.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Avatar { get; set; }

        public virtual List<Workshop> Workshops { get; set; }
    }
}