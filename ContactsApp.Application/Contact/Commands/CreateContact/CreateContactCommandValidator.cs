﻿using ContactsApp.Application.Contacts;
using ContactsApp.Application.Contacts.Commands.CreateContact;
using ContactsApp.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Contact.Commands.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator(IContactRepository repository)
        {
            RuleFor(contact => contact.FirstName)
            .NotEmpty()
            .Length(3, 20);

            RuleFor(contact => contact.LastName)
                .NotEmpty()
                .Length(3, 30);

            RuleFor(contact => contact.Email)
                .NotEmpty()
                .EmailAddress()
                .Custom((value, context) =>
                {
                    var existingEmail = repository.GetByName(value).Result;
                    if (existingEmail != null)
                    {
                        context.AddFailure($"{value} email address is already in use.");
                    }
                });

            RuleFor(contact => contact.Password)
                .NotEmpty()
                .Length(5, 255)
                .WithName("Password")
                .WithMessage("Must be between {MinLength} and {MaxLength} characters");

            RuleFor(contact => contact.ConfirmPassword)
                .NotEmpty()
                .Equal(contact => contact.Password)
                .WithName("ConfirmPassword")
                .WithMessage("Passwords do not match");

            RuleFor(contact => contact.Phone)
                .Length(8, 12)
                .When(contact => !string.IsNullOrEmpty(contact.Phone));

            RuleFor(contact => contact.EncodedName)
                .NotNull();
        }
    }
}
