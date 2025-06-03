using ECommerceAPI.Application.Repositories;
using P = ECommerceAPI.Domain.Entities;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.Category.Create;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.WriteRepository<P.Category>().AddAsync(new P.Category{
            Name = request.Name,
            Description = request.Description,
        });
        await _unitOfWork.SaveChangesAsync();
        return new();
    }
}
