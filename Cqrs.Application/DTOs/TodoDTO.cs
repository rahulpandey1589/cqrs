namespace Cqrs.Application.DTOs
{
    public class TodoDTO
    {
        public Guid Id { get; set; }

        public string TodoName { get; set; } = default!;

        public bool IsCompleted { get; set; } = false;
    }
}
