using AutoMapper;
using exam_back.DB;
using exam_back.Mapping;
using exam_back.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
services.AddDbContext<DentistDbContext>(o => o.UseSqlServer(configuration["ConnectionString"]));
services.AddScoped<IPatientService, PatientsService>();
services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
services.AddSingleton<IMapper>(Mapping.Create());


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

app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
