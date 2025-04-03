using MagicCardInfo.Application;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Magic Card Info API",
        Version = "v1",
        Description = "API for fetching and managing Magic: The Gathering cards."
    });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Magic Card Info API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();

//to run database locally -> sqlcmd -S DESKTOP-GEK05PA\SQLEXPRESS -E

