using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    public class Checkin
    {
        public User participant { get; set; }

        public User admin { get; set; }

        public string timestamp { get; set; }

    }
}
