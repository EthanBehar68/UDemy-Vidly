using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
       
        public bool IsSubscribedToNewsletter { get; set; }
        
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        // Called a Navigation Type for DBs
        public MembershipType MembershipType { get; set; }

        //Foreign Key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}