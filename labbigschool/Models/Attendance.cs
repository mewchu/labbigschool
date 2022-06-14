using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace labbigschool.Models
{
    public class Attendance
    {
        public object Course { get; internal set; }
    }
    public Course Course { get; set; }
    [Key]
    [Column(Orer = 1)]
    public int CourseId { get; set; }
    public ApplicationUser Attendee { get; set; }
    [Key]
    [Column(Orer = 2)]
    public string AttendeeId { get; set; }
}