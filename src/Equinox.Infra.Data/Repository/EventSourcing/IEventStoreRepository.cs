using System;
using System.Collections.Generic;
using Equinox.Domain.Core.Events;

namespace Equinox.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}