using ContactsApp.Application.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contact.Queries.GetContactByEncodedName
{
    public class GetContactByEncodedNameQuery : IRequest<ContactDto>
    {
        public string EncodedName { get; set; }

        public GetContactByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
