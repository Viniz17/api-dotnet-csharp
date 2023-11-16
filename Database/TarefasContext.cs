using Microsoft.EntityFrameworkCore;

public class TarefasContext : DbContext
{
    public TarefasContext(DbContextOptions<TarefasContext> options) : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}

public class Tarefa
{
    public string? Title { get; internal set; }
    public string? Description { get; internal set; }
    public bool? Done { get; internal set; }
}