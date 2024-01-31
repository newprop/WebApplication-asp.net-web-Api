using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        public string Address { get; set; }
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        public int DesignationId { get; set; }
        public decimal Salary { get; set; }
        public bool Permanent { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual IList<Experience> Experiences { get; set; } = new List<Experience>();

    }
}