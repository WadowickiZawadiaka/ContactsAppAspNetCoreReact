using AutoMapper;
using ContactsApp.Application.Contacts;
using ContactsApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contact.Queries.GetContactByEncodedName
{
    public class GetContactByEncodedNameQueryHandler : IRequestHandler<GetContactByEncodedNameQuery, ContactDto>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetContactByEncodedNameQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactDto> Handle(GetContactByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<ContactDto>(contact);

            return dto;
        }
    }
}
