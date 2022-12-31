using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoWork.Entities.Models
{
    [Table("User")]
    public class User
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(500, ErrorMessage = "Address can't be longer than 500 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(500, ErrorMessage = "Password can't be longer than 500 characters")]
        public string Password { get; set; }

        public ICollection<UserLog> Accounts { get; set; }

        public DateTime CreatedAt { get; set; }

        [StringLength(10, ErrorMessage = "Status can't be longer than 10 characters")]
        public string Status { get; set; }
    }
}
