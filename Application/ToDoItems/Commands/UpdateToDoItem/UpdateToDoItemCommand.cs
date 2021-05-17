using System.Threading;
using System.Threading.Tasks;
using AppDomain.Common.Interfaces;
using AppDomain.Entities;
using Application.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.ToDoItems.Commands.UpdateToDoItem
{
    public abstract class UpdateToDoItemCommand:IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }
    }

    public class UpdateToDoItemCommandHandler:IRequestHandler<UpdateToDoItemCommand>
    {
        private readonly IRepository<ToDoItem, int> _toDoItemRepository;
        private readonly IMapper _mapper;

        public UpdateToDoItemCommandHandler( IRepository<ToDoItem, int> toDoItemRepository,IMapper mapper)
        {
            _toDoItemRepository = toDoItemRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var entity =await _toDoItemRepository.GetFirst(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ToDoItem), request.Id);
            }

            _mapper.Map(request, entity);
            await _toDoItemRepository.Commit(cancellationToken);
            return Unit.Value;
        }
    }
}
