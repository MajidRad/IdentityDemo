using IdentityDemo.RequestHelpers;
using System.Text.Json;

namespace IdentityDemo.Extensions
{
    public static class PaginationHeader
    {
        public static void AddPaginationHeader(this HttpResponse response, MetaData metaData)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(metaData, options));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}
