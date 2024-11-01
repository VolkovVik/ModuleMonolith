using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;
using ModuleMonolith.Modules.Users.Application.Abstractions.Data;
using ModuleMonolith.Modules.Users.Domain.Users;
using ModuleMonolith.Modules.Users.Application.Users.RegisterUser;

namespace ModuleMonolith.Modules.Users.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Email, request.FirstName, request.LastName);

        userRepository.Insert(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
