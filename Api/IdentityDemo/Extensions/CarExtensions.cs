using IdentityDemo.DTOs;
using IdentityDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace IdentityDemo.Extensions
{
    public static class CarExtensions
    {
        public static IQueryable<Car> Sort(this IQueryable<Car> query, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy)) return query.OrderBy(q => q.Name);
            query = orderBy switch
            {
                "price" => query.OrderBy(q => q.Price),
                "priceDesc" => query.OrderByDescending(q => q.Price),
                _ => query.OrderBy(q => q.Name),
            };

            return query;
        }
        public static IQueryable<Car> Search(this IQueryable<Car> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return query.Where(q => q.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

    }
}
