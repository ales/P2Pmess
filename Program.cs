using Microsoft.EntityFrameworkCore;
using P2PChat;
using P2PChat.Services;
using P2PChat.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddScoped<MessageService>();

ConfigureDb(builder.Services);

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.Run();


static void ConfigureDb(IServiceCollection services)
{
    var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

    var connectionString = config.GetConnectionString("Default");
    services.AddDbContext<AppDbContext>(b => b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}