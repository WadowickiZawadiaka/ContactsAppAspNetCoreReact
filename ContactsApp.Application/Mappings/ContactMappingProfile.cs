using AutoMapper;
using ContactsApp.Application.Contacts;
using ContactsApp.Application.Contacts.Commands.EditContact;
using ContactsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Mappings
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<ContactDto, Domain.Models.Contact>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new ContactDetails()
                {
                    Category = src.Category,
                    Subcategory = src.Subcategory,
                    Phone = src.Phone,
                    DateOfBirth = src.DateOfBirth
                }
                ));

            CreateMap<Domain.Models.Contact, ContactDto>()
                .ForMember(dto => dto.Category, opt => opt.MapFrom(src => src.ContactDetails.Category))
                .ForMember(dto => dto.Subcategory, opt => opt.MapFrom(src => src.ContactDetails.Subcategory))
                .ForMember(dto => dto.Phone, opt => opt.MapFrom(src => src.ContactDetails.Phone))
                .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.ContactDetails.DateOfBirth));

            CreateMap<ContactDto, EditContactCommand>();
        }
    }
}
