using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Schedule
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string EventDescription { get; set; }

        public string Room { get; set; }

        public long Id { get; set; }

        public string EventTitle { get; set; }

        public string Presenter { get; set; }

        public Schedule() {}

        public Schedule(int id) {
            this.Id = Id;
        }

    }
}
