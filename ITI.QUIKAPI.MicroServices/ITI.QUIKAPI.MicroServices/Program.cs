using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using SpotBrlService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add QUIK qadmin BRL services
builder.Services.AddTransient<ISpotBrlService, SpotService>();
builder.Services.AddTransient<IQuikApiConnectionService, QuikApiConnectionService>();

builder.Services.Configure<QadminLogon>(
    builder.Configuration.GetSection("QadminLogon"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
