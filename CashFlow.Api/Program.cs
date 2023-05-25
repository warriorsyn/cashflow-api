using CashFlow.Infra.Data;
using CashFlow.Infra.Repositories;
using CashFlow.Services.Report;
using CashFlow.Services.Transaction;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add entity framework configs

builder.Services.AddDbContext<DataContext>(opt =>
          opt.UseInMemoryDatabase("CashFlow"));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependency injection

builder.Services.AddScoped<ITransactionRepository, TransactionEFRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IReportService, ReportService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
