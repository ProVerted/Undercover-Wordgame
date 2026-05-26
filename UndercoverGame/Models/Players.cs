namespace UndercoverGame.Models;

public class Player
{
    public string Id {get;set;} = Guid.NewGuid().ToString();
    public string Name {get;set;} = "";
    public string Role {get;set;} = "";
    public string? Word {get;set;}
    public bool isEliminated {get;set;} = false;
}