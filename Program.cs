using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using WebApiPlantillas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Crear variable para la cadena de Conexion
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Registrar Servicio Para La Conexion 
builder.Services.AddDbContext<CartaSolicitudContext>(options => options.UseSqlServer(ConnectionString));

//PDF Generator
builder.Services.AddSingleton(typeof(IConverter),new SynchronizedConverter(new PdfTools()));

builder.Services.AddScoped<PdfGenerator>();

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

app.MapControllers();

app.Run();
