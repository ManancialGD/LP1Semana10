using System;

namespace PlayerManagerMVC.Models
{
 public class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int CompareTo(Player other)
        {
            if (other == null) return 1;
            return Score.CompareTo(other.Score);
        }
    }
}