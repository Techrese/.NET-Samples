using Microsoft.EntityFrameworkCore;
using Commands;
using Commands.AddNewPart;
using Commands.DeletePart;
using Queries;
using Queries.GetPartById;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICommandHandler<AddNewPartCommand>, AddNewPartCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeletePartCommand>, DeletePartCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetPartByIdQuery>, GetPartByIdQueryHandler>();
builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

builder.Services.AddEntityFrameworkInMemoryDatabase().AddDbContext<ApplicationContextInMemory>(opt => opt.UseInMemoryDatabase(databaseName: "CQRS"), ServiceLifetime.Singleton);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
