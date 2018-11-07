using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Resource
    {
        public string ProviderName { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public long Id { get; set; }

    }
}
