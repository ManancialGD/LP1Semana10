using System;
using System.Collections.Generic;
using PlayerManagerMVC.Models;
using PlayerManagerMVC.Views;

namespace PlayerManagerMVC.Controllers
{
    public class PlayerController
    {
        private readonly List<Player> playerList;
        private readonly PlayerView view;
        private readonly IComparer<Player> compareByName;
        private readonly IComparer<Player> compareByNameReverse;

        public PlayerController()
        {
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);

            playerList = new List<Player>
            {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };

            view = new PlayerView();
        }

        public void Run()
        {
            string option;
            do
            {
                view.ShowMenu();
                option = view.GetInput();

                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        view.ShowMessage("Bye!");
                        break;
                    default:
                        view.ShowMessage("\n>>> Unknown option! <<<\n");
                        break;
                }

                view.ShowMessage("\nPress any key to continue...");
                Console.ReadKey(true);
                view.ShowMessage("\n");
            } while (option != "0");
        }

        private void InsertPlayer()
        {
            Player newPlayer = view.GetPlayerDetails();
            playerList.Add(newPlayer);
        }

        private void ListPlayers(IEnumerable<Player> players)
        {
            view.DisplayPlayers(players);
        }

        private void ListPlayersWithScoreGreaterThan()
        {
            int minScore = view.GetMinimumScore();
            IEnumerable<Player> playersWithScoreGreaterThan = GetPlayersWithScoreGreaterThan(minScore);
            ListPlayers(playersWithScoreGreaterThan);
        }

        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player p in playerList)
            {
                if (p.Score > minScore)
                {
                    yield return p;
                }
            }
        }

        private void SortPlayerList()
        {
            PlayerOrder playerOrder = view.GetPlayerOrder();

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.Sort(compareByNameReverse);
                    break;
                default:
                    view.ShowMessage("\n>>> Unknown player order! <<<\n");
                    break;
            }
        }
    }
}
