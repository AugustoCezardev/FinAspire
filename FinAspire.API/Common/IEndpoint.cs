namespace FinAspire.API.Common;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder routeBuilder);
}