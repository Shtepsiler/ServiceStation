using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Exeptions;
using Appilcaion.Interfaces;

namespace Appilcation2.GenericOperations
{
    /*
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand<TEntity>> 
    {
        private readonly ServiceStationDContext _context;
        protected readonly DbSet<TEntity> table;

        public DeleteCommandHandler(IServiceStationDContext context)
        {
            _context = context;
        }


                 public async Task<Unit> IRequestHandler<DeleteCommand<TEntity>>.Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
                 {
                     var entity = await table
                         .FindAsync(request.Id);

                     if (entity == null)
                     {
                         throw new NotFoundException(nameof(table), request.Id);
                     }

                     table.Remove(entity);

                     await _context.SaveChangesAsync();

                     return Unit.Value;
                 }
     
        public Task Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await table
       .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(table), request.Id);
            }

            table.Remove(entity);

            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }







    public class DeleteCommand<TEntity> : IRequest where TEntity : class
    {
        public int Id { get; set; }

        public class DeleteCommandHandler : IRequestHandler<DeleteCommand<TEntity>>
        {
            private readonly IServiceStationDContext _context;
            protected readonly DbSet<TEntity> table;

            public DeleteCommandHandler(IServiceStationDContext context)
            {
                _context = context;
            }


           public async Task<Unit> IRequestHandler<DeleteCommand<TEntity>>.Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
            {
                var entity = await table
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(table), request.Id);
                }

                table.Remove(entity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }

            public Task Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
            {
                var entity = await table
           .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(table), request.Id);
                }

                table.Remove(entity);

                await _context.SaveChangesAsync();

                return Task.CompletedTask;
            }
        }

*/
}
