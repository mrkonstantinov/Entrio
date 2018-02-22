using System;

namespace Entrio.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
         Guid UserId { get; set; }
    }
}