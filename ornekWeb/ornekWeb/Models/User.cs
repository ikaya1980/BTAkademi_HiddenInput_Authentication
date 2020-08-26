using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ornekWeb.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserAuthority { get; set; } = "User";

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string UserPhone { get; set; }
    }

}
