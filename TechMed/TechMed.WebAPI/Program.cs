using Microsoft.EntityFrameworkCore;
using TechMed.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TechMedDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("TechMedDb");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
      options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
