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

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
