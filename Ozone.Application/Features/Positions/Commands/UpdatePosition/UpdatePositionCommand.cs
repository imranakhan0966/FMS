using MediatR;
using Ozone.Application.Exceptions;
//using Ozone.Application.Interfaces.Repositories;
using Ozone.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ozone.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommand : IRequest<Response<long>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        //public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, Response<long>>
        //{
        //    private readonly IPositionRepositoryAsync _positionRepository;
        //    public UpdatePositionCommandHandler(IPositionRepositoryAsync positionRepository)
        //    {
        //        _positionRepository = positionRepository;
        //    }
        //    public async Task<Response<long>> Handle(UpdatePositionCommand command, CancellationToken cancellationToken)
        //    {
        //        var position = await _positionRepository.GetByIdAsync(command.Id);

        //        if (position == null)
        //        {
        //            throw new ApiException($"Position Not Found.");
        //        }
        //        else
        //        {
        //            position.PositionTitle = command.Title;
        //            position.PositionSalary = command.Salary;
        //            position.PositionDescription = command.Description;
        //            await _positionRepository.UpdateAsync(position);
        //            return new Response<long>(position.Id);
        //        }
        //    }
        //}
    }
}
