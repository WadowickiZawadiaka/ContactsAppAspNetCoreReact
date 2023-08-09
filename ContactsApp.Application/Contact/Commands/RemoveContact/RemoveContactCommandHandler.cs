using AutoMapper;
using ContactsApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contacts.Commands.RemoveContact
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public RemoveContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var contactToRemove = await _contactRepository.GetById(request.ContactId);

            if (contactToRemove != null) 
            {
                await _contactRepository.Delete(contactToRemove.Id);
            }
            else
            {
                return;
            }
            
        }
    }
}
