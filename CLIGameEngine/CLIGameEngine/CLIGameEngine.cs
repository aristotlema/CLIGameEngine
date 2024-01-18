/*
How to setup the Game Engine

1. Add game to program.cs:
    Game game = new Game();
2. Add Game base class to Game.cs:
public class Game
{
    GameEngine gameEngine;
    public Game()
    {
        gameEngine = new GameEngine();
        gameEngine.RunGame(Start,Update);
    }
    private void Start()
    {

    }
    //Place game loop here
    public void Update()
    {

    }
}
*/

namespace CLIGameEngine
{
    public class GameEngine
    {
        private bool _gameActive;
        private int _currentTurn;

        public GameEngine()
        {
            _currentTurn = 1;
            _gameActive = true;
        }

        public void RunGame(Action start, Action updateMethod)
        {
            start();

            while (_gameActive)
            {
                updateMethod();
                _currentTurn++;
            }
        }
        public string InputHandler(string question)
        {
            Console.Write(question);
            string? input = Console.ReadLine();
            if (input == null)
                return string.Empty;
            else
                return input;
        }

        public int GetCurrentTurn()
        {
            return _currentTurn;
        }
    }

    public interface IGame
    {
        public void Start() { }
        public void Update() { }
    }

    public class Game : IGame
    {
        public GameEngine gameEngine { get; set; }
        public Game()
        {
            Console.WriteLine("Starting Game Engine");
            gameEngine = new GameEngine();
            Console.WriteLine("Game Engine has been started");
            gameEngine.RunGame(Start, Update);
        }
        protected virtual void Start() { }
        protected virtual void Update() { }
    }
}
