//Esta file pertence a Models, TaskItem.cs define as propriedas de uma tarefa

namespace TaskFlow.Api.Models;

public class TaskItem //classe que representa cada tarefa
{
    public int Id {get; set;} 

    public string Title { get; set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int Priority { get; set; } = 1;

    public bool IsCompleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

       public DateTime? DueDate {get; set;}
public void UpdateDescription(string newDescription)
{
    /*Uma regra de negócio através de encapsulamento: 
    A própria classe controla como a sua descrição pode ser alterada.*/
if (string.IsNullOrWhiteSpace(newDescription))
{
    throw new ArgumentException("Description cannot be empty.");
    }
Description = newDescription;
    }
}