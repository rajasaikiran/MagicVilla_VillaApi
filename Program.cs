using MagicVilla_VillaApi.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// creating the serail log config
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.
    File("log/VillaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddDbContext<ApplicatonDbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLconnection"));
});
//Register the service in the container
//builder.Services.AddTransient<ILogging, ILogging>();
builder.Services.AddControllers(options =>{
    //options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();
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
