// DTOs — Dados que entram e saem da API 
//Exemplo: CreateTaskDto.cs recebe os dados necessários para criar uma tarefa.
//Quando  Angular cria task não precisa de enviar ID & CreatedAt, isso é gerado no Backend

namespace TaskFlow.Api.Dtos;

   public class CreateTaskDto {
    public string Title {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;

    public int Priority {get; set;} = 1;  
    // Criar ainda a seguir um Enum Priority com 4 prioridades 
    public DateTime? DueDate {get; set;}

        }
   

