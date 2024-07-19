﻿using MediatR;
using TrueCodeTest.Application.Interfaces;

namespace TrueCodeTest.Application.Commands.ToDoItems
{
    public class UpdateToDoItemCommand : IRequest<Guid>, IWithId
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public DateTime? DueDate { get; init; }
        public int? Priority { get; init; }
    }
}
