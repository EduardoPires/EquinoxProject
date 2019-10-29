using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual Dictionary<string, string[]> GetNotificationsByKey()
        {
            var keys = _notifications.Select(s => s.Key).Distinct();
            var problemDetails = new Dictionary<string, string[]>();
            foreach (var key in keys)
            {
                problemDetails[key] = _notifications.Where(w => w.Key.Equals(key)).Select(s => s.Value).ToArray();
            }

            return problemDetails;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}