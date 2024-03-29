﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeReportingSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Firstname is required and needs to be between 2-25 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Firstname is required and needs to be between 2-25 characters")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        [Required]
        public string Role { get; set; }

        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public List<TimeReport> TimeReports { get; set; }
    }
}
