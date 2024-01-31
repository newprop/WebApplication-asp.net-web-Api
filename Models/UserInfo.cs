using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserInfo
    {
        [Key]
        [Required]
        [StringLength(50,MinimumLength =5)]
        public string UserName { get; set;}
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set;}
        public string Role { get; set;}



    }
}