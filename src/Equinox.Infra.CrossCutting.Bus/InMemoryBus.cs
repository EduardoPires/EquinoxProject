using System.Threading.Tasks;
using Equinox.Domain.Core.Events;
using FluentValidation.Results;
using NetDevPack.Mediator;
using NetDevPack.Messaging;
using NetDevPack.SimpleMediator.Core.Interfaces;

namespace Equinox.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus(IEventStore eventStore, IMediator mediator) : IMediatorHandler
    {
        private readonly IMediator _mediator = mediator;
        private readonly IEventStore _eventStore = eventStore;

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}