namespace ScoreBoard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            var scoreBoard = new ScoreBoard();
            while (inputLine != "End")
            {
                string result = scoreBoard.ProcessCommand(inputLine);
                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }

                inputLine = Console.ReadLine();
            }
        }
    }

    public class ScoreBoard
    {
        private Dictionary<string, User> users;
        private OrderedDictionary<string, Game> games;
        private Dictionary<string, OrderedBag<GameResult>> resultsByGame;

        public ScoreBoard()
        {
            this.users = new Dictionary<string, User>();
            this.games = new OrderedDictionary<string, Game>((game1, game2) => string.CompareOrdinal(game1, game2));
            this.resultsByGame = new Dictionary<string, OrderedBag<GameResult>>();
        }

        public string RegisterUser(string username, string password)
        {
            var user = new User(username, password);
            if (!this.users.ContainsKey(username))
            {
                this.users[username] = user;
                return "User registered";
            }

            return "Duplicated user";
        }

        public string RegisterGame(string name, string password)
        {
            var game = new Game(name, password);
            if (!this.games.ContainsKey(name))
            {
                this.games[name] = game;
                return "Game registered";
            }

            return "Duplicated game";
        }

        public string AddScore(string username, string userPassword, string gameName, string gamePassword, int score)
        {
            if (this.users.ContainsKey(username) && this.games.ContainsKey(gameName))
            {
                var game = this.games[gameName];
                var user = this.users[username];
                if (user.Password == userPassword && gamePassword == game.Password)
                {
                    var gameResult = new GameResult(gameName, username, score);
                    this.resultsByGame.EnsureKeyExists(gameName);
                    this.resultsByGame[gameName].Add(gameResult);
                    return "Score added";
                }

                return "Cannot add score";
            }

            return "Cannot add score";
        }

        public string ShowScoreboard(string game)
        {
            if (this.games.ContainsKey(game))
            {
                if (this.resultsByGame.ContainsKey(game))
                {
                    StringBuilder returnedResult = new StringBuilder();
                    var results = this.resultsByGame[game].Take(10);
                    int counter = 1;
                    foreach (var result in results)
                    {
                        string scoreResultString = string.Format("#{0} {1} {2}", counter, result.User, result.Score);
                        returnedResult.AppendLine(scoreResultString);
                        counter++;
                    }

                    return returnedResult.ToString().Trim();
                }
                else
                {
                    return "No score";
                }
            }

            return "Game not found";
        }

        public string ListGamesByPrefix(string namePrefix)
        {
            var games = this.GetGames(namePrefix);
            if (games.Any())
            {
                return string.Join(", ", games);
            }

            return "No matches";
        }

        public string DeleteGame(string gameName, string password)
        {
            if (this.games.ContainsKey(gameName))
            {
                var game = this.games[gameName];
                if (this.resultsByGame.ContainsKey(gameName))
                {
                    this.resultsByGame.Remove(gameName);
                }

                if (game.Password == password)
                {
                    this.games.Remove(gameName);
                    return "Game deleted";
                }
                else
                {
                    return "Cannot delete game";
                }
            }
            else
            {
                return "Cannot delete game";
            }
        }

        public string ProcessCommand(string inputLine)
        {
            string[] commandParts = inputLine.Split(' ');
            string commandName = commandParts[0];
            switch (commandName)
            {
                case "RegisterUser":
                    return this.RegisterUser(commandParts[1], commandParts[2]);
                case "RegisterGame":
                    return this.RegisterGame(commandParts[1], commandParts[2]);
                case "AddScore":
                    return this.AddScore(commandParts[1], commandParts[2], commandParts[3], commandParts[4], int.Parse(commandParts[5]));
                case "ShowScoreboard":
                    return this.ShowScoreboard(commandParts[1]);
                case "ListGamesByPrefix":
                    return this.ListGamesByPrefix(commandParts[1]);
                case "DeleteGame":
                    return this.DeleteGame(commandParts[1], commandParts[2]);
                default:
                    return string.Empty;
            }
        }

        private IEnumerable<string> GetGames(string namePrefix)
        {
            var games = this.games.RangeFrom(namePrefix, true).Keys;
            int maxGamesCount = 10;
            foreach (var game in games)
            {
                if (maxGamesCount > 0 && game.StartsWith(namePrefix))
                {
                    maxGamesCount--;
                    yield return game;
                }
                else
                {
                    yield break;
                }
            }
        }
    }

    public class Game
    {
        public Game(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public string Name { get; set; }

        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Game) || (obj == null))
            {
                return false;
            }

            Game user = (Game)obj;
            return (this.Password == user.Password) && (this.Name == user.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Password.GetHashCode();
        }
    }

    public class User : IComparable<User>
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public int CompareTo(User other)
        {
            return this.Username.CompareTo(other.Username);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User) || (obj == null))
            {
                return false;
            }

            User user = (User)obj;
            return (this.Password == user.Password) && (this.Username == user.Username);
        }

        public override int GetHashCode()
        {
            return this.Username.GetHashCode() ^ this.Password.GetHashCode();
        }
    }

    public class GameResult : IComparable<GameResult>
    {
        public GameResult(string game, string user, int score)
        {
            this.Game = game;
            this.User = user;
            this.Score = score;
        }

        public string Game { get; set; }

        public string User { get; set; }

        public int Score { get; set; }
        
        public int CompareTo(GameResult other)
        {
            int result = other.Score.CompareTo(this.Score);
            if (result == 0)
            {
                result = this.User.CompareTo(other.User);
            }

            return result;
        }
    }

    public static class DictionaryExtensions
    {
        /// <summary>
        /// Ensures the specified key exists in the dictionary.
        /// If the key does not exist, it is mapped to a new empty value.
        /// </summary>
        public static void EnsureKeyExists<TKey, TValue>(
            this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : new()
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new TValue());
            }
        }

        /// <summary>
        /// Appends a new value to the collection of values mapped to the specified
        /// dictionary key. If the collection does not exists for the specified key,
        /// a new empty collection is first created and mapped to this key.
        /// </summary>
        /// <param name="key">The key that holds a collection of values</param>
        /// <param name="value">The value to be added to the collection for this key</param>
        public static void AppendValueToKey<TKey, TCollection, TValue>(
            this IDictionary<TKey, TCollection> dict, TKey key, TValue value)
            where TCollection : ICollection<TValue>, new()
        {
            TCollection collection;
            if (!dict.TryGetValue(key, out collection))
            {
                collection = new TCollection();
                dict.Add(key, collection);
            }

            collection.Add(value);
        }

        /// <summary>
        /// Get a sequence of values assigned to the specified dictionary key.
        /// If the key is missng, an empty sequence is returned.
        /// </summary>
        public static IEnumerable<TValue> GetValuesForKey<TKey, TValue>(
            this IDictionary<TKey, SortedSet<TValue>> dict, TKey key)
        {
            SortedSet<TValue> collection;
            if (dict.TryGetValue(key, out collection))
            {
                return collection;
            }

            return Enumerable.Empty<TValue>();
        }
    }
}
