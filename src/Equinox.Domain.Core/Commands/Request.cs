using System;
using MediatR;

namespace Equinox.Domain.Core.Commands
{
    public class Request : IRequest
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Request()
        {
            MessageType = GetType().Name;
        }
    }
}
