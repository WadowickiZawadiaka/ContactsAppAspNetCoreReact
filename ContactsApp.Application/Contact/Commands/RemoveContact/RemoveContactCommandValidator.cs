using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contacts.Commands.RemoveContact
{
    public class RemoveContactCommandValidator : AbstractValidator<RemoveContactCommand>
    {
        public RemoveContactCommandValidator()
        {
            RuleFor(x => x.ContactId).GreaterThan(0).WithMessage("Invalid contact ID.");
        }
    }
}
