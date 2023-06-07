
using Application.Interfaces;
using Domain.Entities;
using Domain.Exeptions;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateOrderPartCommand : IRequest
{
    public int Id { get; set; }
    public int OrderId { get; set; }

    public int PartId { get; set; }
}

public class UpdateOrderPartCommandHandler : IRequestHandler<UpdateOrderPartCommand>
{
    private readonly IServiceStationDContext _context;

    public UpdateOrderPartCommandHandler(IServiceStationDContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateOrderPartCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.OrderParts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Job), request.Id);
        }

        entity.OrderId = request.OrderId;
        entity.PartId = request.PartId;


        await _context.SaveChangesAsync(cancellationToken);
    }
}
