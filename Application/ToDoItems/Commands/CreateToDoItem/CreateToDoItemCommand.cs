using System.Threading;
using System.Threading.Tasks;
using AppDomain.Common.Interfaces;
using AppDomain.Entities;
using Application.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.ToDoItems.Commands.CreateToDoItem
{
    public abstract class CreateToDoItemCommand : IRequest<int>
    {
        public int ListId { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; } = false;
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, int>
    {
        private readonly IRepository<ToDoItem, int> _toDoItemRepository;
        private readonly IMapper _mapper;

        public CreateTodoItemCommandHandler(IRepository<ToDoItem, int> toDoItemRepository, IMapper mapper)
        {
            _toDoItemRepository = toDoItemRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = _mapper.Map<ToDoItem>(request);

            if (toDoItem == null)
            {
                throw new NotFoundException(nameof(ToDoItem), request.ListId);

            }
            await _toDoItemRepository.Add(toDoItem);
            await _toDoItemRepository.Commit(cancellationToken);

            return toDoItem.Id;
        }
    }
}
