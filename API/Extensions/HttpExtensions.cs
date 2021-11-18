using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddHeader<T>(this HttpResponse response,T data,string headerName){
            var options=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
            response.Headers.Add(headerName,JsonSerializer.Serialize(data,options));
            response.Headers.Add("Access-Control-Expose-Headers",headerName);//nazwa obowiazkowa Access-Control-Expose-Headers
        }
    }
}