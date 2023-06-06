using Application.Interfaces;
using Domain.Entities;
using Domain.Exeptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Operations.PartsNeeded.Commands
{
    public class DeletePartneededCommand : IRequest
    {
        public int Id { get; set; }

        public class DeletePartNeededHandler : IRequestHandler<DeletePartneededCommand>
        {
            private readonly IServiceStationDContext _context;

            public DeletePartNeededHandler(IServiceStationDContext context)
            {
                _context = context;
            }
            async Task IRequestHandler<DeletePartneededCommand>.Handle(DeletePartneededCommand request, CancellationToken cancellationToken)
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
            /*            public async Task Handle(DeleteJobCommand request, CancellationToken cancellationToken)
                        {
                            var entity = await _context.Jobs
                                .FindAsync(request.Id);

                            if (entity == null)
                            {
                                throw new NotFoundException(nameof(Job), request.Id);
                            }

                            _context.Jobs.Remove(entity);

                            await _context.SaveChangesAsync(cancellationToken);

                            return Unit.Value;
                        }*/


        }
    }
}
