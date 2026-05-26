namespace UndercoverGame.Services;
using UndercoverGame.Models;

public class GameService
{
    private Dictionary<string, Game> _games = new();
    private Random _rng = new();

    public Game CreateGame(List<string> PlayerNames, int UndercoverCount, int MrWhiteCount)
    {
        var game = new Game();
        var wordPair = WordBank.GetRandom();

        game.CivilianWord = wordPair.CivilianWord;
        game.UndercoverWord = wordPair.UndercoverWord;

        var shuffled = PlayerNames.OrderBy(_ => _rng.Next()).ToList();

        for (int i = 0; i < shuffled.Count; i++)
        {
            var player = new Player { Name = shuffled[i]};

            if(i < UndercoverCount)
            {
                player.Role = "Undercover";
                player.Word = wordPair.UndercoverWord;
            }
            else if(i < UndercoverCount + MrWhiteCount)
            {
                player.Role = "Mr.White";
                player.Word = null;
            }
            else
            {
                player.Role = "Civilian";
                player.Word = wordPair.CivilianWord;
            }
            game.Players.Add(player);
        }
        game.GameState = "Playing";
        _games[game.Id] = game;
        return game;
    }

    public Game EliminatePlayer(string gameId, string playerId)
    {
        var game = _games[gameId];
        var player = game.Players.First(p => p.Id == playerId);
        player.isEliminated = true;
        game.Round++;
        CheckWinCondition(game);
        return game;
    }

    public bool MrWhiteGuess(string gameId, string guess)
    {
        var game = _games[gameId];
        return string.Equals(guess, game.CivilianWord, StringComparison.OrdinalIgnoreCase);
    }
    private void CheckWinCondition(Game game)
    {
        var alivePlayers = game.Players.Where(p=>!p.isEliminated).ToList();
        var aliveUndercovers = alivePlayers.Count(p=>p.Role =="Undercover");
        var aliveCivilians = alivePlayers.Count(p=>p.Role =="Civilian");
        var aliveMrWhite = alivePlayers.Count(p=>p.Role =="Mr.White");
    
        if(aliveUndercovers ==0 && aliveMrWhite == 0)
        {
            game.GameState = "CiviliansWin";
        }
        else if(aliveCivilians <= 1)
        {
            game.GameState = "UndercoverWin";
        }
    }
    public Game? GetGame(string gameId) => _games.TryGetValue(gameId, out var g) ? g :null;
}