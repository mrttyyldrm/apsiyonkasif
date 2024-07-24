using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Repository.Repositories
{
    public class AdvertRepository : GenericRepository<Advert>, IAdvertRepository
    {
        public AdvertRepository(AppDbContext context) : base(context)
        {
        }

        //public async Task<List<Advert>> AdvertFilter(AdvertFilterDto filter)
        //{
        //    var query = _context.Adverts
        //       .Include(x => x.AdvertType)
        //       .Include(x => x.Home)
        //       .AsQueryable();

        //    List<object> filters = [filter.MaxPrice, filter.MinPrice, filter.MaxApartmentAge, filter.MinApartmentAge, filter.Dues, filter.RoomCountId, filter.Floor, filter.MinNetArea, filter.MaxNetArea, filter.HasFurnished, filter.HeatingTypeId];

        //    List<object> notNullFilters = new List<object>();

        //    for (int i = 0; i < filters.Count; i++)
        //    {
        //        if (filters[i] != null)
        //        {
        //            notNullFilters.Add(filters[i]);
        //        }
        //    }

        //    filters.Clear();
        //    filters.AddRange(notNullFilters);

        //    if (!filters.Contains(filter))
        //    {
        //        return await query
        //            .Where(x => x.Price < filter.MaxPrice)
        //            .ToListAsync();
        //    }

        //    return await _context.Adverts
        //       .Include(x => x.AdvertType)
        //       .Include(x => x.Home)
        //       .ToListAsync();
        //}

        public async Task<List<Advert>> AdvertFilter(AdvertFilterDto filter)
        {
            var query = _context.Adverts
                .Include(x => x.AdvertType)
                .Include(x => x.Home)
                .AsQueryable();

            Expression<Func<Advert, bool>> predicate = x => true;

            if (filter.MaxPrice.HasValue)
                predicate = CombineExpressions(predicate, x => x.Price <= filter.MaxPrice.Value);

            if (filter.MinPrice.HasValue)
                predicate = CombineExpressions(predicate, x => x.Price >= filter.MinPrice.Value);

            if (filter.MaxApartmentAge.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.Apartment.Age <= filter.MaxApartmentAge.Value);

            if (filter.MinApartmentAge.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.Apartment.Age >= filter.MinApartmentAge.Value);

            if (filter.Dues.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.Apartment.Dues == filter.Dues.Value);

            if (filter.RoomCountId.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.RoomCountId == filter.RoomCountId.Value);

            if (filter.Floor.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.Floor == filter.Floor.Value);

            if (filter.MinNetArea.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.NetArea >= filter.MinNetArea.Value);

            if (filter.MaxNetArea.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.NetArea <= filter.MaxNetArea.Value);

            if (filter.HasFurnished.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.HasFurnished == filter.HasFurnished.Value);

            if (filter.HeatingTypeId.HasValue)
                predicate = CombineExpressions(predicate, x => x.Home.Apartment.HeatingTypeId == filter.HeatingTypeId.Value);

            return await query.Where(predicate).ToListAsync();
        }

        private Expression<Func<T, bool>> CombineExpressions<T>(
            Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(expr1.Body, invokedExpr),
                expr1.Parameters);
        }
    }
}
