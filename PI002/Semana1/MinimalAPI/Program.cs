using Semana1.MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/franklin", () => Franklin.View());

app.Run();
