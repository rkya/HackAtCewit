using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        public User() {

        }

        public User(string Id, string Username) {
            this.Username = Username;
            this.Id = Id;
        }

    }
}
