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
        [RegularExpression("^([0-9][0-9][0-9][0-9]-[0-1][0-9]-[0-3][0-9] [0-2][0-9]:[0-5][0-9]:[0-5][0-9])$", ErrorMessage = "Invalid DateTime Format.")]
        [Display(Description = "Date", Name = "Start DateTime")]
        [Required(ErrorMessage = "Please enter the event start date and time.")]
        public string StartTime { get; set; }

        [RegularExpression("^([0-9][0-9][0-9][0-9]-[0-1][0-9]-[0-3][0-9] [0-2][0-9]:[0-5][0-9]:[0-5][0-9])$", ErrorMessage = "Invalid DateTime Format.")]
        [Display(Description = "Date", Name = "End DateTime")]
        public string EndTime { get; set; }

        [Display(Name = "Description")]
        public string EventDescription { get; set; }

        public string Room { get; set; }

        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter the event title.")]
        [Display(Name = "Title")]
        public string EventTitle { get; set; }

        public string Presenter { get; set; }

        public Schedule() {}

        public Schedule(int id) {
            this.Id = Id;
        }

    }
}
