using CA.SharedKernel.Infrastructure.Repositories.Interfaces;
using CA.Todos.Domain;
using CA.Todos.Domain.ValueObjects;

namespace CA.Todos.Infrastructure.Persistence;

public static class TodoDbContextSeed
{
    public static async Task SeedTodoData(IRepository<TodoList> repository, CancellationToken cancellationToken)
    {
        if (!await repository.IsExistsAsync(cancellationToken))
        {
            TodoList list = new()
            {
                Title = "Programming",
                Color = Color.Blue,
                Items =
                    {
                        new TodoItem{Title="CSharp",Done=true},
                        new TodoItem{Title="React",Done=true},
                        new TodoItem{Title="Python"},
                        new TodoItem{Title="Scrum"},
                        new TodoItem{Title="Agile"},
                        new TodoItem{Title="Clean Architecture"},
                    }
            };

            await repository.AddAsync(list, cancellationToken);
            await repository.SaveAsync(cancellationToken);
        }
    }
}
