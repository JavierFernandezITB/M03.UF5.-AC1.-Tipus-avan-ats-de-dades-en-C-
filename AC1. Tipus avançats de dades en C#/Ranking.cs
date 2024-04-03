using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC1._Tipus_avançats_de_dades_en_C_
{
    internal class Ranking
    {
        public static List<Score> GenerateUniqueRanking(List<Score> scores)
        {
            var ranking = from score in scores
                          group score by new { score.Player, score.Mission } into g
                          select new Score(g.Key.Player, g.Key.Mission, g.Max(x => x.Scoring));
            return ranking.ToList();
        }
    }
}
