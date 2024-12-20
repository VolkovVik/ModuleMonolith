﻿using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Modules.Codes.Presentation.Codes;

namespace ModuleMonolith.Modules.Codes.Presentation;

public static class CodesEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateCode.MapEndpoint(app);
        GetCode.MapEndpoint(app);
        GetCodes.MapEndpoint(app);
        PrintCode.MapEndpoint(app);
        ValidateCode.MapEndpoint(app);
        DefectCode.MapEndpoint(app);
    }
}
