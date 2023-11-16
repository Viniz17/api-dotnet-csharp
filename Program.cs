using ApiTarefas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Use the appropriate connection string for SQL Server
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

builder.Services.AddDbContext<TarefasContext>(options => 
    options.UseSqlServer(connectionString, 
        sqlServerOptions => sqlServerOptions.MigrationsAssembly("ApiTarefas")));

builder.Services.AddScoped<ITarefaService, ITarefaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
