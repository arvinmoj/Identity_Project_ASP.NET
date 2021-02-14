using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("TestModels")]
    public class TestModel
    {
        public TestModel() : base()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [MaxLength(50)]
        [Display(Name = "PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
