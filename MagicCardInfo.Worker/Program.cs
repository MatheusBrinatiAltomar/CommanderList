using Hangfire;
using MagicCardInfo.Application;
using MagicCardInfo.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddHangfireServer();

builder.Services.AddHttpClient();
builder.Services.AddApplicationServices(builder.Configuration);   

var host = builder.Build();

host.Run();
