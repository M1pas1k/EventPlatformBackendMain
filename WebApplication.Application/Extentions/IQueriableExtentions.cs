using AutoMapper;
using AutoMapper.QueryableExtensions;
using WebApplication.Application.Pagination;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Application.Extentions
{
    public static class IQueriableExtentions
    {
        public async static Task<Page<TEntity>> PaginateAsync<TEntity>(this IQueryable<TEntity> query, Pageable page, CancellationToken ct = default)
        {
            if (page.Index < 0)
                throw new ArgumentOutOfRangeException(nameof(page.Index), "Номер страницы должен быть >= 0");
            if (page.Size <= 0)
                throw new ArgumentOutOfRangeException(nameof(page.Size), "Размер страницы должен быть > 0");

            var total = query.Count();
            var items = await query.Skip(page.Index * page.Size).Take(page.Size).ToListAsync();
            return new Page<TEntity>(items, page.Index, total, items.Count);
        }

        public async static Task<Page<M>> PaginateAsync<T, M>(this IQueryable<T> query, Pageable page, IMapper mapper, CancellationToken ct = default)
        {
            if (page.Index < 0)
                throw new ArgumentOutOfRangeException(nameof(page.Index), "Номер страницы должен быть >= 0");
            if (page.Size <= 0)
                throw new ArgumentOutOfRangeException(nameof(page.Size), "Размер страницы должен быть > 0");

            var total = query.Count();
            var items = await query.Skip(page.Index * page.Size).Take(page.Size)
                .ProjectTo<M>(mapper.ConfigurationProvider).ToListAsync();

            return new Page<M>(items, page.Index, total, items.Count);
        }
    }
}
