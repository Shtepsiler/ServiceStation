using Application.Interfaces;
using Domain.Entities;
using Domain.Exeptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Operations.Parts.Commands
{
    public class DeletePartCommand : IRequest
    {
        public int Id { get; set; }

        public class DeletePartHandler : IRequestHandler<DeletePartCommand>
        {
            private readonly IServiceStationDContext _context;

            public DeletePartHandler(IServiceStationDContext context)
            {
                _context = context;
            }
            async Task IRequestHandler<DeletePartCommand>.Handle(DeletePartCommand request, CancellationToken cancellationToken)
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
