using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Demo.DAL.Models
{
    public class ApplicatioUser : IdentityUser
    {
        public bool IsAgree { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
