using Microsoft.AspNetCore.Routing;

namespace ModuleMonolith.Common.Presentation.Endpoins;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
