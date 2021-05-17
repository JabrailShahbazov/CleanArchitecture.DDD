using System.Threading;
using System.Threading.Tasks;
using AppDomain.Common.Interfaces;
using AppDomain.Entities;
using Application.Common.Exceptions;
using MediatR;

namespace Application.ToDoItems.Commands.DeleteToDoItem
{
    public abstract class DeleteToDoItemCommand:IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand>
    {
        private readonly IRepository<ToDoItem, int> _toDoItemRepository;

        public DeleteToDoItemCommandHandler(IRepository<ToDoItem, int> toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<Unit> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _toDoItemRepository.GetFirst(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ToDoItem), request.Id);

            }

            await _toDoItemRepository.Delete(entity);
            await _toDoItemRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
