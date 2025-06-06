using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Application.Shared.Commands;
using OnlineExam.UserService.Application.Shared.Resolver;

namespace OnlineExam.UserService.Application.Commons.Resolver
{
    public class CommandResolver : ICommandResolver
    {
        private readonly IServiceProvider _serviceProvider;
        
        public CommandResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> ResolveHandler<TCommand, TResult>(TCommand command)
         where TCommand : ICommand<TResult>
        {
            var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResult>));
            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for {typeof(TCommand).Name} not found");
            }
            return await ((ICommandHandler<TCommand, TResult>)handler).Handle(command, default);
        }
        public async Task ResolveHandler<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for {typeof(TCommand).Name} not found");
            }
            await ((ICommandHandler<TCommand>)handler).Handle(command, default);
        }
    }
   
}