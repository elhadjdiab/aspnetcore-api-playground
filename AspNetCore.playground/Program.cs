using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Playground
{
    public record TodoItem(int Id, string Title, bool IsDone);

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Week 0 — ASP.NET Core Learning Playground");
            Console.WriteLine("Simple Todo demo: create, list, find, async save simulation.\n");

            var todos = new List<TodoItem>
            {
                new(1, "Learn .NET SDK & install tools", true),
                new(2, "Create first console app", true),
                new(3, "Start Todo API design", false)
            };

            Console.WriteLine("All Todos:");
            foreach (var t in todos)
                Console.WriteLine($"- [{(t.IsDone ? 'x' : ' ')}] {t.Id}: {t.Title}");

            var nextId = todos.Max(t => t.Id) + 1;
            var newTodo = new TodoItem(nextId, "Practice async/await", false);
            todos.Add(newTodo);
            Console.WriteLine($"\nAdded todo: {newTodo.Id} - {newTodo.Title}");

            var pending = todos.Where(t => !t.IsDone).ToList();
            Console.WriteLine("\nPending todos:");
            foreach (var t in pending)
                Console.WriteLine($"- {t.Id}: {t.Title}");

            await SaveAsync(newTodo);

            Console.WriteLine("\nDone. Edit the code to try more examples, then push to GitHub.");
        }

        private static async Task SaveAsync(TodoItem item)
        {
            Console.WriteLine($"\nSimulating async save for item {item.Id}...");
            await Task.Delay(600);
            Console.WriteLine($"Item {item.Id} saved.");
        }
    }
}