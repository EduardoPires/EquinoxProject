using System;
using Equinox.Domain.Core.Commands;

namespace Equinox.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
