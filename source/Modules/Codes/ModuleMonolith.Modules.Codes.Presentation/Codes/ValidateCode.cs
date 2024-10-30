﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Common.Presentation.Endpoins;
using ModuleMonolith.Modules.Codes.Application.Codes.ValidateCode;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

internal sealed class ValidateCode : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("codes/validate", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new ValidateCodeCommand(request.Id);
            var result = await sender.Send(command, cancellationToken);
            return result.Match(Results.NoContent, ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }

    internal sealed class Request
    {
        public Guid Id { get; set; }
    }
}
