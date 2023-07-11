using AutoMapper;
using MediatR;
//using Ozone.Application.Interfaces.Repositories;
using Ozone.Application.Wrappers;
//using Ozone.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ozone.Application.Features.Positions.Commands.CreatePosition
{
    public partial class CreatePositionCommand : IRequest<Response<long>>
    {
        public string PositionTitle { get; set; }
        public string PositionNumber { get; set; }
        public string PositionDescription { get; set; }
        public decimal PositionSalary { get; set; }
    }
    //public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Response<long>>
    //{
    //    //private readonly IPositionRepositoryAsync _positionRepository;
    //    private readonly IMapper _mapper;
    //    //public CreatePositionCommandHandler(IPositionRepositoryAsync positionRepository, IMapper mapper)
    //    //{
    //    //    _positionRepository = positionRepository;
    //    //    _mapper = mapper;
    //    //}

    //    //public async Task<Response<long>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    //    //{
    //    //    var position = _mapper.Map<Position>(request);
    //    //    await _positionRepository.AddAsync(position);
    //    //    return new Response<long>(position.Id);
    //    //}
    //}
}
