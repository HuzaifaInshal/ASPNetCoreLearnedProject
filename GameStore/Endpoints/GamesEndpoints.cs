// these are extension methods

using GameStore.DTOs;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{
    private readonly static List<GameDTO> games = [
    new(
        1,"hello","action",19.99M,new DateOnly(1992,5,5)
    ),
    new(
        2,"hello2","action",19.99M,new DateOnly(2011,2,15)
    ),
    new(
        3,"hello3","romance",19.99M,new DateOnly(2002,7,25)
    ),
    ];

//  adding this in params will make it extension method
// webapplication when use app
    // public static WebApplication MapGamesEnpoint(this WebApplication app)
    // RouteGroupBuilder when using group
    public static RouteGroupBuilder MapGamesEnpoint(this WebApplication app)
    {

        var group = app.MapGroup("games").WithParameterValidation();

        // app.MapGet("/games", () => games);
        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
        {
            // This declares a variable named game of type GameDTO. The ? indicates that game can be null.
            GameDTO? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName("GetGameByID");

        // req body is implicitly being sett to CreateGameDTO newGame; newGame is the req body
        group.MapPost("/", (CreateGameDTO newGame) =>
        {

            // if(string.IsNullOrEmpty(newGame.Name)){
            //     return Results.BadRequest("Name is a required field");
            // }

            GameDTO game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute("GetGameByID", new { id = game.Id }, game);
        // }).WithParameterValidation();
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGmae) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            //  if a list  does not find the id in C# it returns -1
            if (index == -1) { return Results.NotFound(); }

            games[index] = new GameDTO(id, updatedGmae.Name, updatedGmae.Genre, updatedGmae.Price, updatedGmae.ReleaseDate);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });


        return group;
    }



}
