using ApiTarefas.Dto;
using ApiTarefas.Errors;

namespace ApiTarefas.Services.Interfaces;

public interface ITarefaService
{
    List<Tarefa> Lista();
    Tarefa Incluir(TarefaDto taskDto);
    Tarefa Update(int id, TarefaDto taskDto);
    Tarefa BuscaPorId(int id);
    void Delete(int id);
   
}