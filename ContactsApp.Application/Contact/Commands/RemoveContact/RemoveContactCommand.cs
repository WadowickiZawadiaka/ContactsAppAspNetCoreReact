using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contacts.Commands.RemoveContact
{
    public class RemoveContactCommand : IRequest
    {
        public string EncodedName { get; set; } = default!;
    }
}
