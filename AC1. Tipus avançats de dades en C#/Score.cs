using System.Text.RegularExpressions;

namespace AC1._Tipus_avançats_de_dades_en_C_
{
    internal class Score : IComparable<Score>
    {
        public string Player { get; set; }
        public string Mission { get; set; }
        public int Scoring { get; set; }

        public Score() { }

        public Score(string player, string mission, int scoring)
        {
            SetPlayer(player);
            SetMission(mission);
            SetScoring(scoring);
        }

        public void SetPlayer(string value)
        {
            Regex rgx = new Regex("^[a-zA-Z]+$");
            if (!rgx.IsMatch(value))
            {
                Console.WriteLine("The player's name must only contain letters.");
                Player = "";
                return;
            }
            Player = value;
        }

        public void SetMission(string value)
        {
            List<string> names = new List<string> { "alpha", "beta", "gamma", "delta", "épsilon", "zeta", "eta", "teta", "iota", "kappa", "lambda", "mi", "ni", "csi", "ómicron", "pi", "rho", "sigma", "tau", "ýpsilon", "fi", "ji", "psi", "omega" };
            Regex rgx = new Regex("^[a-zA-Z]+-[0-9]{3}$");
            string[] splittedString = value.Split("-");
            if ((names.Find(name => value.ToLower().StartsWith(name+"-"))) == null || !rgx.IsMatch(value))
            {
                Console.WriteLine("The mission's name must start with a greek alphabet letter name followed by 3 digits. Ex: \"Delta-001\"");
                Mission = "";
                return;
            }
            Mission = value;
        }

        public void SetScoring(int value)
        {
            const int MaxScore = 500;
            const int MinScore = 0;
            if ( !(value <= MaxScore && value >= MinScore) )
            {
                Console.WriteLine("The mission's score must be higher than 0 and lower than 500");
                Scoring = -1;
                return;
            }
            Scoring = value;
        }

        public int CompareTo(Score? other)
        {
            if (other == null) return 1;
            return -Scoring.CompareTo(other.Scoring);
        }
    }
}
