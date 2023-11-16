using ApiTarefas.Dto;
using ApiTarefas.Errors;
using ApiTarefas.Services.Interfaces;

namespace ApiTarefas.Services;

public class TarefaService : ITarefaService
{
    public TarefaService(TarefasContext db)
    {
        _db = db;
    }

    private TarefasContext _db;

    public List<Tarefa> Lista()
    {
        return _db.Tarefas.ToList();
    }

    public Tarefa Incluir(TarefaDto taskDto)
    {
        if(string.IsNullOrEmpty(taskDto.Title))
            throw new TarefaError ("Title required.");

        var task = new Tarefa
        {
            Title = taskDto.Title,
            Description = taskDto.Description,
            Done = taskDto.Done,
        };
            
        _db.Tarefas.Add(task);
        _db.SaveChanges();

        return task;
    }

    public Tarefa Update(int id, TarefaDto taskDto)
    {
        if(string.IsNullOrEmpty(taskDto.Title))
            throw new TarefaError ("Title required.");

        var taskDb = _db.Tarefas.Find(id);

        if(taskDb == null)
           throw new TarefaError ("Task not found.");
   
        taskDb.Title = taskDto.Title;
        taskDb.Description = taskDto.Description;
        taskDb.Done = taskDto.Done;

        _db.Tarefas.Update(taskDb);
        _db.SaveChanges();

        return taskDb;
    }
    public Tarefa BuscaPorId(int id)
    { 
        var taskDb = _db.Tarefas.Find(id);

        if(taskDb == null)
            throw new TarefaError("Title cannot be null.");
        
            return taskDb;
    }

    public void Delete(int id)
    {
        var taskDb = _db.Tarefas.Find(id);

        if(taskDb == null)
            throw new TarefaError ("Task not found.");

        _db.Tarefas.Remove(taskDb);
        _db.SaveChanges();
    }
}