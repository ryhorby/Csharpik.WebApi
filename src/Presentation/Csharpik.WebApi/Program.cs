using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services;
using Csharpik.Core.Services.BookServices;
using Csharpik.Core.Services.CryptoService;
using Csharpik.Core.Services.Interfaces.BookServices;
using Csharpik.Core.Services.Interfaces.CryptoService;
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

//BookProject
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<AuthorDto>, AuthorRepository>();
builder.Services.AddScoped<IBookService<Book>, BookService>();
builder.Services.AddScoped<IBookService<AuthorDto>, AuthorService >();

//CryptoProject
builder.Services.AddScoped<IEncryptorService, EncryptorService>();
builder.Services.AddScoped<IDecryptorService, DecryptorService>();

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
