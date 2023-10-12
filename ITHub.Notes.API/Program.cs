using ITHub.Notes.DAL.DB.Context;
using ITHub.Notes.DAL.DB.Interfaces;
using ITHub.Notes.DAL.DB.Repositories;
using ITHub.Notes.DAL.DB.UnitOfWork;
using ITHub.Notes.Domain.Repositories.Interfaces;
using ITHub.Notes.Services.Interfaces;
using ITHub.Notes.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

//DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

//DI
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
