using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Common;

namespace WebApplication.Application.Features.Common
{
    public class Actions(IMapper mapper, IDatabaseContext context) : IActions
    {
        public async Task<Result<T>> GetBy<T>(Expression<Func<T, object>> fieldSelector, object value, CancellationToken ct = default, Action<T>? entityAction = default) where T : BaseEntity
        {
            var set = GetDbSet<T>();
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    fieldSelector.Body,
                    Expression.Constant(value)
                ),
                fieldSelector.Parameters
            );

            var entity = await set.FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                return Result.Failure<T>(status: Status.NotFound);
            }

            return Result.Success(entity);
        }

        public async Task<Result<M>> GetBy<T, M>(Expression<Func<T, object>> fieldSelector, object value, CancellationToken ct = default, Action<T>? entityAction = default) where T : BaseEntity
        {
            var set = GetDbSet<T>();

            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    fieldSelector.Body,
                    Expression.Constant(value)
                ),
                fieldSelector.Parameters
            );

            var entity = await set
                .Where(predicate)
                .ProjectTo<M>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (entity == null)
            {
                return Result.Failure<M>(status: Status.NotFound);
            }

            return Result.Success(entity);
        }

        public async Task<Result<T>> GetById<T>(Guid id, CancellationToken ct = default, Action<T>? entityAction = default) where T : BaseEntity
        {
            var set = GetDbSet<T>();
            var entity = await set.Where(q => q.Id == id)
                .FirstOrDefaultAsync(ct);

            if (entity == null)
            {
                return Result.Failure<T>(status: Status.NotFound);
            }

            return Result.Success(entity);
        }

        public async Task<Result<M>> GetById<T, M>(Guid id, CancellationToken ct = default, Action<T>? entityAction = default) where T : BaseEntity
        {
            var set = GetDbSet<T>();
            var entity = await set.Where(q => q.Id == id)
                .ProjectTo<M>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (entity == null)
            {
                return Result.Failure<M>(status: Status.NotFound);
            }

            return Result.Success(entity);
        }

        public async Task<Result<M>> Create<E, M>(object request, CancellationToken ct = default, Func<E, IDatabaseContext, Task>? entityAction = null) where E : BaseEntity
        {
            var set = GetDbSet<E>();
            var entity = mapper.Map<E>(request);
            entityAction?.Invoke(entity, context).WaitAsync(ct);
            set!.Add(entity);
            var result = await context.SaveChangesAsync(ct);
            return result == 0 ? Result.Failure<M>() : Result.Success(mapper.Map<M>(entity));
        }

        public async Task<ICollection<M>> GetAll<E, M>(CancellationToken ct = default) where E : BaseEntity
        {
            var set = GetDbSet<E>();
            return await set.AsNoTracking().ProjectTo<M>(mapper.ConfigurationProvider).ToListAsync(ct);
        }

        public async Task<Result> DeleteById<E>(Guid Id, CancellationToken ct = default, Action<E>? entityAction = default) where E : BaseEntity
        {
            var set = GetDbSet<E>();
            var entity = await set.FindAsync(Id, ct);
            if (entity == null) return Result.Failure($"entity {Id} not found", Status.NotFound);
            set.Remove(entity);
            entityAction?.Invoke(entity);
            await context.SaveChangesAsync(ct);
            return Result.Success(status: Status.NoContent);
        }

        public async Task<Result<M>> Update<E, M>(Guid id, object request, CancellationToken ct = default, Action<E>? entityAction = default) where E : BaseEntity
        {
            var set = GetDbSet<E>();
            var entity = await set.FindAsync(id, ct);

            if (entity == null)
            {
                return Result.Failure<M>($"entity {id} not found");
            }
            mapper.Map(request, entity);
            entityAction?.Invoke(entity);

            await context.SaveChangesAsync(ct);
            return Result.Success(mapper.Map<M>(entity));
        }

        private DbSet<T> GetDbSet<T>() where T : BaseEntity
        {
            Type entityType = typeof(T);
            var propertyInfo = DbSetStorage.DbSets.GetOrAdd(
                entityType,
                t => context
                .GetType()
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(DbSet<T>))
             );

            return (DbSet<T>)propertyInfo.GetValue(context);
        }
    }
}
