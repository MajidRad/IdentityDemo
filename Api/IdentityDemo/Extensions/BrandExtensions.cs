using IdentityDemo.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IdentityDemo.Extensions
{
    public static class BrandExtensions
    {
        public static IQueryable<Brand> IncludedSort(this IQueryable<Brand> query, string orderBy)
        {
            //.Include(x => x.Cars.OrderByDescending(x => x.Price))
            if (string.IsNullOrEmpty(orderBy)) return query.Include(q => q.Cars.OrderBy(q => q.Name));
            query = orderBy switch
            {
                "price" => query.Include(q => q.Cars.OrderBy(q => q.Price)),
                "priceDesc" => query.Include(q => q.Cars.OrderByDescending(q => q.Price)),
                _ => query.Include(q => q.Cars.OrderBy(q => q.Name))
            };
            return query.AsQueryable();
        }

        public static IQueryable<Brand> Search(this IQueryable<Brand> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;
            var lowerSearchTerm = searchTerm.ToLower().Trim();
            return query.Where(q => q.Name.Contains(lowerSearchTerm));
        }


    }
}
