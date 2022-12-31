using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoWork.Entities.Models
{
    [Table("UserLog")]
    public class UserLog
    {
        public Guid UserLogId { get; set; }

        [Required(ErrorMessage = "MachineKey is Required")]
        [StringLength(100, ErrorMessage = "MachineKey can't be longer than 100 characters")]
        public string MachineKey { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }

        [StringLength(10, ErrorMessage = "Status can't be longer than 10 characters")]
        public string Status { get; set; }
    }
}
