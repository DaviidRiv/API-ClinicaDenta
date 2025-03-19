using Clinica.Application.UseCase.Extensions;
using Clinica.Persistence.Extensions;
using Clinica.Api.Extensions.Middleware;
using Clinica.Infraestructure.Extensions;
using Clinica.Api.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar Servicios Persistence
builder.Services.AddInjectionPersistence();
//Inyectar Servicios Application
builder.Services.AddInjectionApplication();
//Inyectar Servicios File | Infraestructure
builder.Services.AddInjectionInfraestructure(builder.Configuration);
//Inyectar Servicios Authentication
builder.Services.AddAuthentication(builder.Configuration);
//Acceso a HttpContext (route)
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); //Files rendimiento y eficiencia

app.UseAuthentication();

app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

app.Run();
