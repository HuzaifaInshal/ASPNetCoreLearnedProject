namespace GameStore.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }

    // define association or one-to-one relation ship between game and genre
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }

}
