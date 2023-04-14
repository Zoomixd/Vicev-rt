using Microsoft.EntityFrameworkCore;
using PedelApp.Application.Contract;
using PedelApp.Application.Contract.Dtos;
using PedelApp.Application.Implementation;
using PedelApp.Application.Infrastructure;
using PedelApp.Domain.DomainServices;
using PedelApp.Infrastructure.DomainServiceImpl;
using PedelApp.Infrastructure.Queries;
using PedelApp.Infrastructure.RepositoriesImpl;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Application.Implementation;
using Vicevært.Application.Infrastructure;
using Vicevært.Domain.DomainServices;
using Vicevært.Infrastructure.Database;
using Vicevært.Infrastructure.DomainServicesImpl;
using Vicevært.Infrastructure.Queries;
using Vicevært.Infrastructure.RepositoriesImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext"), x =>
    {
        x.MigrationsAssembly("Vicevært.Web");
    }));



builder.Services.AddScoped<IRekvisitionQuery, RekvisitionQuery>();
builder.Services.AddScoped<IRekvisitionCommand, RekvisitionCommand>();
builder.Services.AddScoped<IRekvisitionRepository, RekvisitionRepository>();
builder.Services.AddScoped<IRekvisitionRepository, RekvisitionRepository>();
builder.Services.AddScoped<IRekvisitionDomainServices, RekvisitionDomainService>();
builder.Services.AddScoped<ILejemaalQuery, LejemaalQuery>();
//builder.Services.AddScoped<ILejemaalCommand, LejemaalCommand>();
builder.Services.AddScoped<ILejemaalRepository, LejemaalRepository>();
builder.Services.AddScoped<ILejemaalRepository, LejemaalRepository>();
builder.Services.AddScoped<ILejemaalDomainService, LejemaalDomainService>();
builder.Services.AddScoped<IBookingQuery, BookingQuery>();
builder.Services.AddScoped<IBookingCommand, BookingCommand>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDomainServices, BookingDomainService>();

builder.Services.AddControllers();
builder.Services.AddScoped<ITidsRegistreringQuery, TidsRegistreringQuery>();
builder.Services.AddScoped<ITidsRegistreringCommand, TidsRegistreringCommand>();
builder.Services.AddScoped<ITidsRegistreringRepository, TidsRegistreringRepository>();
builder.Services.AddScoped<ITidsRegistreringDomainService, TidsRegistreringDomainService>();






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
