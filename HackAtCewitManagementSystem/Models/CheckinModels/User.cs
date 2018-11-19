﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

    }
}
