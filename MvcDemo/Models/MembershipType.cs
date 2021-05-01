using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public short SignUpFee { get; set; }
        [Required]
        [Range(1, byte.MaxValue, ErrorMessage = "Membership duration must be greater than 0 and less than 255.")]
        public byte DurationInMonths { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "DiscountRate must be between 0 and 100")]
        public byte DiscountRate { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "MembershipType Name must not exceed 20 characters")]
        public string Name { get; set; }
    }
}