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
        public string TeamName { get; set; }
        [MaxLength(10)]
        public string Citta { get; set; }
        [MaxLength(10)]
        public string Allenatore { get; set; }
        [MaxLength(20)]
        public string Colori { get; set; }

        //List<Player> PlayerList { get; set; }

        public Team(string name, string city , string coach, string colours)
        {
           // PlayerList = new List<Player>();
            TeamName = name;
            Citta = city;
            Allenatore = coach;
            Colori = colours;
        }

        public override string ToString()
        {
            string stringa = $"Nome della squadra : {TeamName}, Città : {Citta}, Allenatore : {Allenatore}, Colori: {Colori}";
            return stringa;
        }
    }
}
