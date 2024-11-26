using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Application.Shared.Exception
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class HttpStatusCodeAttribute : Attribute
    {
        public int StatusCode { get; }

        public HttpStatusCodeAttribute(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}