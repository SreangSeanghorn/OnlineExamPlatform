using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Application.Shared.Commands;
using OnlineExam.UserService.Application.Shared.Responses;

namespace OnlineExam.UserService.Application.UserLogin
{
    public class UserLoginCommand: ICommand<BaseResponse<UserLoginResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserLoginCommand(string username, string password){
            this.Username = username;
            this.Password = password;
        }
        
    }
}