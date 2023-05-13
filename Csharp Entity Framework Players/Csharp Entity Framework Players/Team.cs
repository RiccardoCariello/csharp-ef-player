using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Entity_Framework_Players
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        [MaxLength(10)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Coach { get; set; }
        [MaxLength(20)]
        public string Colours { get; set; }

        List<Player> PlayerList { get; set; }   //?

        public Team(string teamName, string city , string coach, string colours)
        {
            PlayerList = new List<Player>();
            TeamName = teamName;
            City = city;
            Coach = coach;
            Colours = colours;
        }

        public override string ToString()
        {
            string stringa = $"Nome della squadra : {TeamName}, Città : {City}, Allenatore : {Coach}, Colori: {Colours}\nGiocatori : \n";
            if (PlayerList != null)
            {
                foreach (Player player in PlayerList)
                {
                    stringa +=$"{player.Name} {player.Surname} + \n";
                }
            } 
            return stringa;
        }
    }
}
