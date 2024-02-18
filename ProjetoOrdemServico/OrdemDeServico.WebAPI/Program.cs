using Microsoft.EntityFrameworkCore;
using OrdemDeServico.Application.Services;
using OrdemDeServico.Application.Services.Interfaces;
using ResTIConnect.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPrestadorDeServicoService, PrestadorDeServicoService>();
builder.Services.AddScoped<IOrdemServicoService, OrdemServicoService>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<IServicoService, ServicoService>();

builder.Services.AddDbContext<OrdemDeServicoContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("OrdemDeServicoDb");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();
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
