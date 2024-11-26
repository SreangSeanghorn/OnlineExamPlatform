using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace OnlineExam.UserService.Application.Shared.Commands
{
    public interface ICommand : IRequest
    {
        
    }
    public interface ICommand<TResult> : IRequest<TResult>
    {
        
    } 

}