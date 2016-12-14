using System.Collections.Generic;
using Equinox.Domain.Core.Events;

namespace Equinox.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}