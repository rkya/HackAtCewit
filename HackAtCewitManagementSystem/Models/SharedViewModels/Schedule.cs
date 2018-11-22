using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HackAtCewitManagementSystem.Models
{
    public class Schedule
    {
        [RegularExpression("^([0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9])$", ErrorMessage = "Invalid DateTime Format.")]
        [Display(Description = "Date", Name = "Start DateTime")]
        [Required(ErrorMessage = "Please enter the event start date and time.")]
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string EventDescription { get; set; }

        public string Room { get; set; }

        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter the event title.")]
        public string EventTitle { get; set; }

        public string Presenter { get; set; }

        public Schedule() {}

        public Schedule(int id) {
            this.Id = Id;
        }

    }
}
