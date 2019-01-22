using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    public class UserCheckinInfo
    {
        public List<Checkin> checkins { get; set; }

        public List<User> nonCheckedinUsers { get; set; }

        public UserCheckinInfo() {

        }

        public UserCheckinInfo(List<Checkin> checkins, List<User> nonCheckedinUsers)
        {
            this.checkins = checkins;
            this.nonCheckedinUsers = nonCheckedinUsers;
            this.userToBeCheckedin = new User();
        }

        public UserCheckinInfo(List<Checkin> checkins, List<User> nonCheckedinUsers, User user)
        {
            this.checkins = checkins;
            this.nonCheckedinUsers = nonCheckedinUsers;
            this.userToBeCheckedin = user;
        }

        public User userToBeCheckedin { get; set; }
        public string usercheckin;
    }
}
