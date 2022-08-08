using GTCapacitorProxy.Models;

namespace GTCapacitorProxy.Interfaces;

public interface IMiddleWareService
{
    Task<object> MiddleRequest(MiddlewareRequest request);
}