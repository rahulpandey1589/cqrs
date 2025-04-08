namespace Cqrs.Api.Models.Request;

public class ChangeTodoRequest
{
    public Guid Id { get; set; }

    public string TodoName { get; set; } = default!;
    
    public bool IsCompleted { get; set; }
}