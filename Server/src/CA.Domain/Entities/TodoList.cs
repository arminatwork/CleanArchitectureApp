using CA.Domain.Common;
using CA.Domain.ValueObjects;
using System;

namespace CA.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Color Color { get; set; } = Color.White;
    }
}
