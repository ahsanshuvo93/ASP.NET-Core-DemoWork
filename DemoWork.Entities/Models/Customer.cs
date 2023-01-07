using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoWork.Entities.Models
{
    [Table("Customer")]
    public class Customer
    {
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "FullName is Required")]
        [StringLength(100, ErrorMessage = "FullName can't be longer than 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required")]
        [StringLength(100, ErrorMessage = "PhoneNumber can't be longer than 100 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(500, ErrorMessage = "Address can't be longer than 500 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(500, ErrorMessage = "Password can't be longer than 500 characters")]
        public string Password { get; set; }

        public ICollection<CustomerLog> CustomerLogs { get; set; }

        public DateTime CreatedAt { get; set; }

        [StringLength(10, ErrorMessage = "Status can't be longer than 10 characters")]
        public string Status { get; set; }
    }
}
