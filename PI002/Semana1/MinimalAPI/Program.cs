using Semana1.MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => HomePage.View());
app.MapGet("/ezequiel", () => Ezequiel.View());
app.MapGet("/franklin", () => Franklin.View());
app.MapGet("/breno", () => Breno.View());
app.MapGet("/alancarlos", () => AlanCarlos.View());

app.Run();
