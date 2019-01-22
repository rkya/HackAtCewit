using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    public class LeaderBoard
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public long Score { get; set; }

        public string LastUpdated { get; set; }
    }
}
