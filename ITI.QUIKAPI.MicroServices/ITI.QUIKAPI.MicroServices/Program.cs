using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Connections;
using QuikAPIBrlService;
using QuikApiQMonitorService;
using QuikDataBaseRepository;
using QuikSftpService;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add QUIK qadmin BRL services
builder.Services.AddTransient<IEdpBrlService, EDPService>();
builder.Services.AddTransient<ISpotBrlService, SpotService>();
builder.Services.AddTransient<IFortsBrlService, FortsService>();
builder.Services.AddTransient<IQuikApiConnectionService, QuikApiConnectionService>();
builder.Services.Configure<QadminLogon>(
    builder.Configuration.GetSection("QadminLogon"));

//add QUIK SFTP Server services
builder.Services.AddTransient<ISFTPService, SFTPService>();
builder.Services.Configure<SftpConnectionConfiguration>(
    builder.Configuration.GetSection("SftpConfig"));

//add QUIK MsSql Data Base connection
builder.Services.AddTransient<IQuikDataBaseRepository, QuikDBRepository>();
builder.Services.Configure<DataBaseConnectionConfiguration>(
    builder.Configuration.GetSection("DataBaseConfig"));

//add QUIK API QMonitor services
builder.Services.AddTransient<IQMonitorService, QMonitorService>();
DealerLibrarys.DealerLibrary = builder.Configuration.GetSection("DealerLibrarys").Get<List<string>>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
