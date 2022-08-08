using GTCapacitorProxy.Interfaces;
using GTCapacitorProxy.Models;

namespace GTCapacitorProxy.Services;

public class MiddleWareService : IMiddleWareService
{
    public async Task<object> MiddleRequest(MiddlewareRequest request)
    {
        HttpClient client = new();
        HttpRequestMessage finalRequest = new();
        finalRequest.RequestUri = new(request.Endpoint);
        Task<HttpResponseMessage> response = null;
        
        switch (request.Method)
        {
            case "GET":
                finalRequest.Method = HttpMethod.Get;
                response =  client.GetAsync(finalRequest.RequestUri.ToString());
                break;
            case "POST":
                finalRequest.Method = HttpMethod.Post;
                finalRequest.Content = (HttpContent?)request.body;
                response =  client.PostAsync(finalRequest.RequestUri.ToString(), finalRequest.Content);
                break;
            case "PUT":
                finalRequest.Method = HttpMethod.Put;
                finalRequest.Content = (HttpContent?)request.body;
                response =  client.PutAsync(finalRequest.RequestUri.ToString(), finalRequest.Content);
                break;
            case "PATCH":
                finalRequest.Method = HttpMethod.Patch;
                finalRequest.Content = (HttpContent?)request.body;
                response =  client.PatchAsync(finalRequest.RequestUri.ToString(), finalRequest.Content);
                break;
            case "DELETE":
                finalRequest.Method = HttpMethod.Delete;
                response =  client.DeleteAsync(finalRequest.RequestUri.ToString());
                break;
        }

       var result= response.WaitAsync(TimeSpan.FromMinutes(1));

       return await response.Result.Content.ReadAsStringAsync();
    }
}