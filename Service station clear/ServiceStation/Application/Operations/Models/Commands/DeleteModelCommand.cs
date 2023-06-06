using Application.Interfaces;
using Domain.Entities;
using Domain.Exeptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Operations.Models.Commands
{
    public class DeleteModelCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteModelHandler : IRequestHandler<DeleteModelCommand>
        {
            private readonly IServiceStationDContext _context;

            public DeleteModelHandler(IServiceStationDContext context)
            {
                _context = context;
            }
            async Task IRequestHandler<DeleteModelCommand>.Handle(DeleteModelCommand request, CancellationToken cancellationToken)
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
