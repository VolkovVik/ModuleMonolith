using ModuleMonolith.Common.Domain;

namespace ModuleMonolith.Modules.Codes.Domain.Codes;

public static class CodeErrors
{
    public static Error NotFound(Guid eventId) =>
        Error.NotFound("Codes.NotFound", $"The event with the identifier {eventId} was not found");

    public static readonly Error NullOrEmptyValue =
        Error.NotFound("Codes.NullOrEmptyValue", $"The code value is null or empty");

    public static readonly Error CodeIsValidated =
        Error.Failure("Codes.CodeIsValidated", $"The code is validated");

    public static readonly Error CodeIsDefected =
        Error.Failure("Codes.CodeIsDefected", $"The code is defected");

    public static readonly Error StartDateInPast = Error.Problem(
        "Codes.StartDateInPast",
        "The event start date is in the past");

    public static readonly Error EndDatePrecedesStartDate = Error.Problem(
        "Codes.EndDatePrecedesStartDate",
        "The event end date precedes the start date");

    public static readonly Error NoTicketsFound = Error.Problem(
        "Codes.NoTicketsFound",
        "The event does not have any ticket types defined");

    public static readonly Error NotDraft = Error.Problem("Codes.NotDraft", "The event is not in draft status");


    public static readonly Error AlreadyCanceled = Error.Problem(
        "Codes.AlreadyCanceled",
        "The event was already canceled");


    public static readonly Error AlreadyStarted = Error.Problem(
        "Codes.AlreadyStarted",
        "The event has already started");
}
