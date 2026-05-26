# 🕵️ Undercover Word Party Game

A web-based multiplayer word party game built with **ASP.NET Core** and **vanilla JavaScript**. Players are secretly assigned roles and words — can the Civilians expose the Undercover agents before it's too late?

---

## 🎮 How to Play

1. Add player names (3 or more players required)
2. Configure how many Undercover and Mr. White players there are
3. Each player privately taps their name to see their secret word
4. Take turns giving one-word clues about your word without revealing it
5. Discuss and vote to eliminate who you think is the Undercover or Mr. White
6. Keep playing until one side wins!

### 🏆 Win Conditions

| Role | How to Win |
|------|-----------|
| 👥 Civilians | Eliminate all Undercover agents and Mr. White |
| 🕵️ Undercover | Survive until only 1 Civilian remains |
| ❓ Mr. White | Get voted out and correctly guess the Civilians' word |

---

## 👥 Roles Explained

- **Civilian** — Gets the real secret word. Try to expose the impostors without being too obvious.
- **Undercover** — Gets a similar but different word. Blend in with the Civilians without getting caught.
- **Mr. White** — Gets no word at all. Listen carefully and bluff your way through. If voted out, guess the Civilians' word to steal the win!

---

## 🛠️ Tech Stack

- **Backend** — ASP.NET Core Web API (.NET 8)
- **Frontend** — HTML, CSS, Vanilla JavaScript
- **Architecture** — REST API + static file serving
- **Language** — C#

---

## 📁 Project Structure
UndercoverGame/
├── Controllers/
│   └── GameController.cs       # REST API endpoints
├── Models/
│   ├── Game.cs                 # Game session model
│   ├── GameCreateRequest.cs    # Request model for creating a game
│   ├── Player.cs               # Player model
│   └── WordPair.cs             # Word pair model
├── Services/
│   ├── GameService.cs          # Core game logic
│   └── WordBank.cs             # Word pairs database
├── wwwroot/
│   └── index.html              # Frontend (HTML + CSS + JS)
├── Program.cs                  # App setup and middleware
└── UndercoverGame.csproj       # Project configuration

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run Locally

1. Clone the repository
```bash
   git clone https://github.com/your-username/UndercoverGame.git
   cd UndercoverGame
```

2. Run the project
```bash
   dotnet run
```

3. Open your browser and go to
http://localhost:5071

---

## 🔌 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/game/create` | Create a new game with players and role config |
| `GET` | `/api/game/{id}` | Get current game state |
| `POST` | `/api/game/{id}/eliminate/{playerId}` | Vote to eliminate a player |
| `POST` | `/api/game/{id}/mrwhite-guess` | Mr. White submits his word guess |

### Create Game Request Body
```json
{
  "playerNames": ["Alice", "Bob", "Charlie", "Dave"],
  "undercoverCount": 1,
  "mrWhiteCount": 1
}
```

---

## ✨ Features

- ✅ Add and remove players before the game starts
- ✅ Duplicate player name prevention
- ✅ Configurable number of Undercover and Mr. White players
- ✅ Private word reveal — tap your name to see your word
- ✅ Live role count preview before starting
- ✅ Mr. White gets a last-chance word guess when eliminated
- ✅ Win screen reveals both secret words after the game ends
- ✅ Play Again with the same players or start completely fresh

---

## 🗺️ Roadmap / Future Ideas

- [ ] Real-time multiplayer using SignalR (each player on their own phone)
- [ ] Timer per round
- [ ] Custom word pairs
- [ ] Game history / scoreboard
- [ ] Mobile app version

---

## 🧑‍💻 Author

**Janarththan**
- GitHub: https://github.com/ProVerted

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).