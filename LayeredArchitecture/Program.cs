using LayeredArchitecture.Repositories;
using LayeredArchitecture.Services;

using Microsoft.EntityFrameworkCore;

using Serilog;
using Serilog.Events;

using Refit;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IHistoryRepository, HistoryRepository>();

// Configure EntityFramework Core
builder.Services.AddDbContext<HistoryContext>(options =>
    options.UseInMemoryDatabase("HistoryContext"));

// Configure refit
builder.Services.AddRefitClient<IBookApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7247"));

// Configure Serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();