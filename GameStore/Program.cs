
using GameStore.Data;
using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// var connString = "Data Source=GameStore.db";
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGamesEnpoint();

app.Run();
