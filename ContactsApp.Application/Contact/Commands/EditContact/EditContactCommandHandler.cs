using ContactsApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contacts.Commands.EditContact
{
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public EditContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByEncodedName(request.EncodedName);

            contact.FirstName = request.FirstName;
            contact.LastName = request.LastName;    
            contact.Email = request.Email;
            contact.Password = request.Password;

            contact.ContactDetails.Category = request.Category;
            contact.ContactDetails.Subcategory = request.Subcategory;
            contact.ContactDetails.Phone = request.Phone;
            contact.ContactDetails.DateOfBirth = request.DateOfBirth;

            await _contactRepository.Commit();
        }
    }
}
