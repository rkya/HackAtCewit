using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    public class Resource
    {
        [Display(Name = "Provider")]
        public string ProviderName { get; set; }

        [Required(ErrorMessage = "Please enter the resource title.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the resource URL.")]
        [Display(Name = "Link")]
        public string Link { get; set; }

        public string Description { get; set; }

        public long Id { get; set; }

    }
}
