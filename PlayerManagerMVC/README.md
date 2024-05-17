classDiagram
    direction TB

    class Program {
        +Main(string[] args)
    }

    class PlayerController {
        -List~Player~ playerList
        -PlayerView view
        -IComparer~Player~ compareByName
        -IComparer~Player~ compareByNameReverse
        +Run()
        -InsertPlayer()
        -ListPlayers(IEnumerable~Player~ players)
        -ListPlayersWithScoreGreaterThan()
        -GetPlayersWithScoreGreaterThan(int minScore) IEnumerable~Player~
        -SortPlayerList()
    }

    class PlayerView {
        +ShowMenu()
        +DisplayPlayers(IEnumerable~Player~ players)
        +GetInput() string
        +GetPlayerDetails() Player
        +GetMinimumScore() int
        +GetPlayerOrder() PlayerOrder
        +ShowMessage(string message)
    }

    class Player {
        +string Name
        +int Score
        +Player(string name, int score)
        +CompareTo(Player other) int
    }

    class CompareByName {
        -bool ord
        +CompareByName(bool ord)
        +Compare(Player p1, Player p2) int
    }

    enum PlayerOrder {
        ByScore
        ByName
        ByNameReverse
    }

    Program --> PlayerController : uses
    PlayerController --> PlayerView : controls
    PlayerController --> Player : manages
    PlayerController --> CompareByName : uses
    PlayerView --> Player : displays
    CompareByName --> Player : compares

    class PlayerOrder {
        ByScore
        ByName
        ByNameReverse
    }
