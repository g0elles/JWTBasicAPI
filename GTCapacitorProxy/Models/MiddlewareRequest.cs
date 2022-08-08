namespace GTCapacitorProxy.Models;

public class MiddlewareRequest
{
    public string Endpoint { get; set; }
    public string Method { get; set; }
    public  object body { get; set; }
}