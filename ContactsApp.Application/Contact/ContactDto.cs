using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contacts
{
    public class ContactDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string? Category { get; set; }
        public string? Subcategory { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string EncodedName { get; set; } = default!;
    }
}
