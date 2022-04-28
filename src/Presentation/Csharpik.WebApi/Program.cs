using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services;
using Csharpik.Core.Services.BookServices;
using Csharpik.Data;
using Csharpik.Data.Repositories;
using Csharpik.Data.Repositories.BookRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AuthorService>();

//DbSet
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CsharpikContext>(
    options => options.UseSqlServer(connectionString)
    );

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
