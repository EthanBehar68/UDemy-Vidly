using System.Collections.Generic;
using UDemyVidly.Models;

namespace UDemyVidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}