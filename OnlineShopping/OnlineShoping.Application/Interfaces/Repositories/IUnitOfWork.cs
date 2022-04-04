using OnlineShoping.Domain.Common;
using OnlineShoping.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShoping.Application.Interfaces.Repositories
{
    public interface IUnitOfWork<TId> : IDisposable
    {
        IRepositoryAsync<T, TId> Repository<T>() where T : AuditableEntity<TId>, IAggregateRoot;
        Task<int> Commit(CancellationToken cancellationToken);
        Task Rollback();
    }
}
