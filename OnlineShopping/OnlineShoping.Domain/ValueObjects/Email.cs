using OnlineShoping.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Value { get; }


        public Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            Guard.ForNullOrWhiteSpace(email, nameof(email), "Email should not be empty");
            email = email.Trim();
            Guard.ForNameLength(email, 100, nameof(email), "Email name should not be empty");

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                throw new ArgumentException(nameof(email), "Email is invalid");

            return new Email(email);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}
