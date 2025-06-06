using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Domain.Core.Primitive;

namespace OnlineExam.UserService.Domain.Emails
{
    public class Email : ValueObject
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email address cannot be empty");
            }

            if (!value.Contains("@"))
            {
                throw new ArgumentException("Email address is invalid");
            }

            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
         public static Email Create(string value)
        {
            return new Email(value);
        }
        public override string ToString()
        {
            return Value;
        }
    }
  
}