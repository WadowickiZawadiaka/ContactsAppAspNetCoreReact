using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contacts.Commands.EditContact
{
    public class EditContactCommand : ContactDto, IRequest
    {

    }
}
