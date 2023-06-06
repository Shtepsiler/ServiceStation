using Application.Interfaces;
using Domain.Entities;
using Domain.Exeptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Operations.OrderParts.Commands
{
    public class DeleteOrderPartCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteOrderPartsHandler : IRequestHandler<DeleteOrderPartCommand>
        {
            private readonly IServiceStationDContext _context;

            public DeleteOrderPartsHandler(IServiceStationDContext context)
            {
                _context = context;
            }
            async Task IRequestHandler<DeleteOrderPartCommand>.Handle(DeleteOrderPartCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Jobs
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Job), request.Id);
                }

                _context.Jobs.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

            }
           

        }
    }
}
