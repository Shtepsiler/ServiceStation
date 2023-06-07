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
    public class GetManagersQuery : IRequest<IEnumerable<JobDTO>>
    {
    }

    public class GetManagersQueryHendler : IRequestHandler<GetManagersQuery, IEnumerable<JobDTO>>
    {
        private readonly IServiceStationDContext _context;
        private readonly IMapper _mapper;

        public GetManagersQueryHendler(IServiceStationDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobDTO>> Handle(GetManagersQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Job>,IEnumerable<JobDTO>>(await _context.Jobs.ToListAsync());
        }
    }



}
