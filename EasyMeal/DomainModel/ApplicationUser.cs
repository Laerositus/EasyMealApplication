using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyMealCore.DomainModel
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public DateTime DOB { get; set; }
    }

}
