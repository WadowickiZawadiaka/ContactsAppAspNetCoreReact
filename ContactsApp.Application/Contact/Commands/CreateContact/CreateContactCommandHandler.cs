using AutoMapper;
using ContactsApp.Domain.Interfaces;
using ContactsApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Domain.Models.Contact>(request);
            contact.EncodeName();

            await _contactRepository.Create(contact);
        }
    }
}
