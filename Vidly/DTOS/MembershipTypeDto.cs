using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOS
{
    public class MembershipTypeDTO
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
    }
}