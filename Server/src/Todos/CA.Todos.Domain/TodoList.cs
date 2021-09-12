using CA.SharedKernel.Domain;
using CA.Todos.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace CA.Todos.Domain
{
    public class TodoList : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Color Color { get; set; } = Color.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
