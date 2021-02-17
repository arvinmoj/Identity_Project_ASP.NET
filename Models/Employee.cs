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

        [MaxLength(25)]
        [DataType(DataType.Text)]
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "FirstName Is Required")]
        public string Firstname { get; set; }

        [MaxLength(25)]
        [DataType(DataType.Text)]
        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Lastname Is Required")]
        public string Lastname { get; set; }

        [MaxLength(25)]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [MaxLength(25)]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; }

    }
}