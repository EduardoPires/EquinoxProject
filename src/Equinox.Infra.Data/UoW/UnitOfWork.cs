using Equinox.Domain.Core.Commands;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Context;

namespace Equinox.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EquinoxContext _context;

        public UnitOfWork(EquinoxContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
