using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name.")] //override validation error message (52 Data Annontation)
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        // Called a Navigation Type for DBs
        public MembershipType MembershipType { get; set; }

        //Foreign Key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } // byte makes this implicity required b/c byte is not nullable (51 Styling Validation Errors)

        [Required]
        public bool Delinquent { get; set; }
    }
}

/* Types of Validation Attributes
 *  [Required] 
 *  [StringLength(255)] 
 *  [Range(1, 10)] 
 *  [Compare(“OtherProperty”)] 
 *  [Phone] • [EmailAddress] 
 *  [Url] 
 *  [RegularExpression(“…”)]
*/
