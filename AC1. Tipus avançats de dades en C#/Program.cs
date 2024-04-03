#define RELEASE

using System;

namespace AC1._Tipus_avançats_de_dades_en_C_
{
    public class myClass
    { 
        public static void Main()
        {
            List<Score> scores = new List<Score>();

            const int       Players = 10;
            const string    InpùtPlayerName = "Introduce el nombre del jugador {0}: ";
            const string    InpùtPlayerMission = "Introduce la misión del jugador {0}: ";
            const string    InpùtPlayerScoring = "Introduce la puntuación del jugador {0}: ";

            #if RELEASE
                for (int i = 0; i < Players; i++)
                {
                    Score score = new Score();

                    string sinput;
                    do
                    {
                        Console.WriteLine(InpùtPlayerName, i+1);
                        sinput = Console.ReadLine();
                        score.SetPlayer(sinput);
                    } while (score.Player == "");
                    do
                    {
                        Console.WriteLine(InpùtPlayerMission, i+1);
                        sinput = Console.ReadLine();
                        score.SetMission(sinput);
                    } while (score.Mission == "");

                    int input;
                    do
                    {
                        Console.WriteLine(InpùtPlayerScoring, i+1);
                        input = int.Parse(Console.ReadLine());
                        score.SetScoring(input);
                    } while (score.Scoring == -1);
                    scores.Add(score);
                    Console.Clear();
                }
            #else
                scores.Add(new Score("a", "delta-001", 200));
                scores.Add(new Score("b", "alpha-020", 250));
                scores.Add(new Score("c", "alpha-020", 300));
                scores.Add(new Score("d", "alpha-120", 500));
                scores.Add(new Score("e", "teta-120", 400));
                scores.Add(new Score("f", "teta-020", 100));
                scores.Add(new Score("f", "teta-020", 260));
                scores.Add(new Score("h", "iota-213", 1));
                scores.Add(new Score("i", "zeta-213", 8));
                scores.Add(new Score("j", "zeta-213", 324));
            #endif

            List<Score> rankedScores = Ranking.GenerateUniqueRanking(scores);
            rankedScores.Sort();

            foreach (Score score in rankedScores)
            {
                Console.WriteLine("Player: {0}\t| Mission: {1}\t|Score: {2}", score.Player, score.Mission, score.Scoring);
            }
        }
    }
}