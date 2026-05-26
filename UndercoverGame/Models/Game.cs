namespace UndercoverGame.Models;

public class Game
{
    public string Id {get;set;} = Guid.NewGuid().ToString();
    public List<Player> Players {get;set;} = new();
    public string GameState {get;set;} = "Lobby";
    public string CivilianWord {get;set;} = "";
    public string UndercoverWord {get;set;} = "";
    public int Round {get;set;} = 1;

}