
namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player player1 = new();
        private readonly Player player2 = new();

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1.ScorePoint();
            else
                player2.ScorePoint();
        }

        public string GetScore()
        {
            if (player1.GetScore() == player2.GetScore())
                return GetDrawScore();

            if (player1.IsOverDeuce() || player2.IsOverDeuce())
                return GetAdvantageScore();

            return GetNormalScore();
        }

        private string GetNormalScore()
        {
            return $"{player1.GetScoreName()}-{player2.GetScoreName()}";
        }

        private string GetAdvantageScore()
        {
            return (player1.GetScore() - player2.GetScore()) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        }

        private string GetDrawScore()
        {
            return player1.GetScore() switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }

    internal class Player   
    {
        private int Score { get; set; }
        public void ScorePoint() => Score++;
        public int GetScore() => Score;
        public bool IsOverDeuce() => Score >= 4;
        public string GetScoreName() => scoreNames[Score];

        private readonly string[] scoreNames = { "Love", "Fifteen", "Thirty", "Forty" };
    }
}

