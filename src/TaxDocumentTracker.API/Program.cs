using Microsoft.EntityFrameworkCore;
using TaxDocumentTracker.API.Data;
using TaxDocumentTracker.API.Facades;
using TaxDocumentTracker.API.Interfaces;
using TaxDocumentTracker.API.Repositories;
using TaxDocumentTracker.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.AddScoped<ITaxFormRepository, TaxFormRepository>();
builder.Services.AddScoped<IFactRepository, FactRepository>();
builder.Services.AddScoped<ITaxFormService, TaxFormService>();
builder.Services.AddScoped<IFactService, FactService>();
builder.Services.AddScoped<ITaxFormFacade, TaxFormFacade>();
builder.Services.AddScoped<IFactFacade, FactFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

