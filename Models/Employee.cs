using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("Employee")]
    public class Employee
    {
        public Employee() : base()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(25)]
        [DataType(DataType.Text)]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(25)]
        [DataType(DataType.Text)]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Gender")]
        [DataType(DataType.Custom)]
        public string Gender { get; set; }
    }
}