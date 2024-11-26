using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Application.Shared.Commands;
using OnlineExam.UserService.Application.Shared.Responses;


namespace OnlineExam.UserService.Application.UserRegistered
{
    public class UserRegisterCommand : ICommand<BaseResponse<UserRegisteredResponse>>
    {
        public UserRegisterCommand(string userName, string email, string password)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;

        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }



}