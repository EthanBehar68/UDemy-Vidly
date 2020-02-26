using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public short SignUpFee { get; set; }
        
        public byte DurationInMonths { get; set; }
        
        public byte DiscountRate { get; set; }


        // Based on migration values - See mirgration PopulateMembershipTypes
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        // Just to be wholesome I'll create them all
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Annually = 4;
    }
}