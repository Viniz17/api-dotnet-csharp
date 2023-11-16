namespace ApiTarefas.Errors;

public class TarefaError : Exception
{
    public TarefaError(string? message) : base(message)
    {
    }
}