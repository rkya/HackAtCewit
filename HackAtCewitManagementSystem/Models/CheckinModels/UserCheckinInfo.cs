using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class UserCheckinInfo
    {
        public List<Checkin> checkins { get; set; }

        public List<User> nonCheckedinUsers { get; set; }

        public UserCheckinInfo(List<Checkin> checkins, List<User> nonCheckedinUsers)
        {
            this.checkins = checkins;
            this.nonCheckedinUsers = nonCheckedinUsers;
        }

    }
}
