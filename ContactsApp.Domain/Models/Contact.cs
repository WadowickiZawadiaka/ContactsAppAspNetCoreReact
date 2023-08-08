using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Domain.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        private string _password = default!;
        public string Password
        {
            get => _password;
            set => _password = HashPassword(value);
        }

        public ContactDetails ContactDetails { get; set; } = default!;

        public string EncodedName { get; private set; } = default!;

        public void EncodeName() => EncodedName = $"{RemovePolishCharacters(FirstName)}-{Id}".ToLower();

        private static string RemovePolishCharacters(string input)
        {
            return new string(input.Normalize(NormalizationForm.FormD)
                                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                    .ToArray())
                .Normalize(NormalizationForm.FormC);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Konwertowanie hasła na bajty
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Konwertowanie zahaszowanych bajtów na ciąg znaków w formacie szesnastkowym
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
