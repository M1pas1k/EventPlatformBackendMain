using System.Linq.Expressions;
using WebApplication.Application.Common.Results;
using WebApplication.Domain.Common;

namespace WebApplication.Application.Interfaces
{
    public interface IActions
    {
        Task<Result<M>> Create<E, M>(object request, CancellationToken ct = default, Func<E, IDatabaseContext, Task>? entityAction = null) where E : BaseEntity;
        Task<Result> DeleteById<E>(Guid Id, CancellationToken ct = default, Action<E>? entityAction = null) where E : BaseEntity;
        Task<ICollection<M>> GetAll<E, M>(CancellationToken ct = default) where E : BaseEntity;
        Task<Result<T>> GetBy<T>(Expression<Func<T, object>> fieldSelector, object value, CancellationToken ct = default, Action<T>? entityAction = null) where T : BaseEntity;
        Task<Result<M>> GetBy<T, M>(Expression<Func<T, object>> fieldSelector, object value, CancellationToken ct = default, Action<T>? entityAction = null) where T : BaseEntity;
        Task<Result<M>> GetById<T, M>(Guid id, CancellationToken ct = default, Action<T>? entityAction = null) where T : BaseEntity;
        Task<Result<T>> GetById<T>(Guid id, CancellationToken ct = default, Action<T>? entityAction = null) where T : BaseEntity;
        Task<Result<M>> Update<E, M>(Guid id, object request, CancellationToken ct = default, Action<E>? entityAction = null) where E : BaseEntity;
    }
}
