using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class LeaderBoard
    {
        public string Username { get; set; }

        public long Score { get; set; }

        public string LastUpdated { get; set; }

        public long Rank { get; set; }
    }
}
