namespace UndercoverGame.Models;

public class GameCreateRequest
{
    public List<string> PlayerNames { get; set; } = new();
    public int UndercoverCount { get; set; } = 1;
    public int MrWhiteCount { get; set; } = 0;
}