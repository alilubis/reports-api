using APITest.Interfaces;
using APITest.Model;
using APITest.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductionDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionKPIConnection"));
});
builder.Services.AddDbContext<QualityDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QualityPQAConnection"));
});
builder.Services.AddScoped<IReportRepository, ReportRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.DefaultModelsExpandDepth(-1);
        }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
