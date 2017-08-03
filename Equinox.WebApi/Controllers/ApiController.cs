using Equinox.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Equinox.WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public ApiController(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
