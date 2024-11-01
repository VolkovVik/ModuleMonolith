using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;
using ModuleMonolith.Modules.Users.Application.Abstractions.Data;
using ModuleMonolith.Modules.Users.Domain.Users;
using ModuleMonolith.Modules.Users.Application.Users.UpdateUser;

namespace ModuleMonolith.Modules.Users.Application.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound(request.UserId));
        }

        user.Update(request.FirstName, request.LastName);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
