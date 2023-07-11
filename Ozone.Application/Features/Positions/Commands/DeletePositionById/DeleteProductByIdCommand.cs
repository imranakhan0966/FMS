using MediatR;
using Ozone.Application.Exceptions;
//using Ozone.Application.Interfaces.Repositories;
using Ozone.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ozone.Application.Features.Positions.Commands.DeletePositionById
{
    public class DeletePositionByIdCommand : IRequest<Response<long>>
    {
        //public Guid Id { get; set; }
        //public class DeletePositionByIdCommandHandler : IRequestHandler<DeletePositionByIdCommand, Response<long>>
        //{
        //    private readonly IPositionRepositoryAsync _positionRepository;
        //    public DeletePositionByIdCommandHandler(IPositionRepositoryAsync positionRepository)
        //    {
        //        _positionRepository = positionRepository;
        //    }
        //    //public async Task<Response<long>> Handle(DeletePositionByIdCommand command, CancellationToken cancellationToken)
        //    //{
        //    //    var position = await _positionRepository.GetByIdAsync(command.Id);
        //    //    if (position == null) throw new ApiException($"Position Not Found.");
        //    //    await _positionRepository.DeleteAsync(position);
        //    //    return new Response<long>(position.Id);
        //    //}
        //}
    }
}
