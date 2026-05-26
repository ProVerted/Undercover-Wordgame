using Microsoft.AspNetCore.Mvc;
using UndercoverGame.Services;
using UndercoverGame.Models;

namespace UndercoverGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost("create")]
    public IActionResult CreateGame([FromBody] GameCreateRequest request)
    {
        if (request == null || request.PlayerNames == null || request.PlayerNames.Count < 3)
            return BadRequest($"Need at least 3 players!");

        int total = request.PlayerNames.Count;
        int civilians = total - request.UndercoverCount - request.MrWhiteCount;

        if (civilians < 1)
            return BadRequest("Must have at least 1 civilian!");

        var game = _gameService.CreateGame(request.PlayerNames, request.UndercoverCount, request.MrWhiteCount);
        return Ok(game);
    }

    [HttpGet("{id}")]
    public IActionResult GetGame(string id)
    {
        var game = _gameService.GetGame(id);
        if (game == null) return NotFound("Game not found!");
        return Ok(game);
    }
    [HttpPost("{id}/eliminate/{playerId}")]
    public IActionResult Eliminate(string id, string playerId)
    {
        var game = _gameService.GetGame(id);
        if (game == null) return NotFound("Game not found!");

        var updatedGame = _gameService.EliminatePlayer(id,playerId);
        return Ok(updatedGame);
    }

    [HttpPost("{id}/mrwhite-guess")]
    public IActionResult MrWhiteGuess(string id, [FromBody] string guess)
    {
        bool correct = _gameService.MrWhiteGuess(id, guess);
        return Ok(new{correct});
    }
}