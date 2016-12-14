using Equinox.Domain.Core.Commands;
using Equinox.Domain.Core.Events;

namespace Equinox.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}