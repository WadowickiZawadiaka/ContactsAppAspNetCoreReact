using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Domain.Models
{
    public class ContactDetails
    {
        public string? Category { get; set; }
        public string? Subcategory { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
