using Application.DTOs.Respponces;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Jobs.Queries
{
    public class GetPartsNeededQuery : IRequest<IEnumerable<JobDTO>>
    {
    }

    public class GetPartsNeededQueryHendler : IRequestHandler<GetPartsNeededQuery, IEnumerable<JobDTO>>
    {
        private readonly IServiceStationDContext _context;
        private readonly IMapper _mapper;

        public GetPartsNeededQueryHendler(IServiceStationDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobDTO>> Handle(GetPartsNeededQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Job>,IEnumerable<JobDTO>>(await _context.Jobs.ToListAsync());
        }
    }



}
