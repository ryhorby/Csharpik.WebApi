using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Models.User;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services;
using Csharpik.Core.Services.BookServices;
using Csharpik.Core.Services.CryptoService;
using Csharpik.Core.Services.Interfaces.BookServices;
using Csharpik.Core.Services.Interfaces.CryptoService;
using Csharpik.Core.Services.Interfaces.RegisterServices;
using Csharpik.Core.Services.RegistrationServices;
using Csharpik.Data;
using Csharpik.Data.Repositories;
using Csharpik.Data.Repositories.BookRepositories;
using Csharpik.Data.Repositories.UserRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;


//TODO: Create ExceptionHandlerFilter
//TODO: Create logger

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// For Authentication in Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}  \")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Authentication using jwt token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

//BookProject
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
builder.Services.AddScoped<IBookService<BookDto>, BookService>();
builder.Services.AddScoped<IBookService<AuthorDto>, AuthorService>();

//CryptoProject
builder.Services.AddSingleton<IEncryptorService, EncryptorService>();
builder.Services.AddSingleton<IDecryptorService, DecryptorService>();

//RegisterProject
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRegisterService, RegistrationService>();

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
