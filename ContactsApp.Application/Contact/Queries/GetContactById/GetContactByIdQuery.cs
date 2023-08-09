using ContactsApp.Application.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contact.Queries.GetContactById
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public int ContactId { get; set; }

        public GetContactByIdQuery(int contactId)
        {
            ContactId = contactId;
        }
    }
}
