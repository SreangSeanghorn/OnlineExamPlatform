using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Domain.Core.Primitive
{
    public sealed class Error : ValueObject
    {
        public string Message { get; }
        public string Code { get; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Message;
            yield return Code;
        }
        public Error(string message, string code)
        {
            Message = message;
            Code = code;
        }
        public static implicit operator string(Error error) => error?.Code ?? string.Empty;
    }
}