namespace ApiTarefas.Dto;

public record TarefaDto
{
    public string? Title {  get; set; } 

    public string? Description {  get; set; } 

    public bool Done {  get; set; } 

}