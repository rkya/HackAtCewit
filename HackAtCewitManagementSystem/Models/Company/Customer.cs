using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactName { get; set; }

        public int EmployeeCount { get; set; }

    }
}
