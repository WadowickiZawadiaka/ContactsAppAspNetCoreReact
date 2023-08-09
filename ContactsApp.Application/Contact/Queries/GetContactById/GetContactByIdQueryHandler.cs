using AutoMapper;
using ContactsApp.Application.Contact.Queries.GetContactByEncodedName;
using ContactsApp.Application.Contacts;
using ContactsApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contact.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDto>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetById(request.ContactId);

            if (contact == null)
            {
                return null;
            }

            var dto = _mapper.Map<ContactDto>(contact);

            return dto;
        }
    }
}
