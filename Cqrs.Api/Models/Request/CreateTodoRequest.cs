using System.ComponentModel.DataAnnotations;

namespace Cqrs.Api.Models.Request
{
    public class CreateTodoRequest
    {
        [Required]
        [StringLength(200)]
        public string TodoName { get; set; } = default!;
    }
}
