using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Entity_Framework_Players
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Surname { get; set; }
        
        public int Score { get; set; }

        public int GamesPlayed { get; set; }

        public int GamesWon { get; set; }


        public Player(string name, string surname )
        {
            Name = name;
            Surname = surname;
            Score = 0;
            GamesPlayed = 0;
            GamesWon = 0;
        }


        public override string ToString()
        {

            string stringa = $"Nome : {Name}, Cognome : {Surname}, Punteggio : {Score}, Partite giocate : {GamesPlayed}, Partite vinte : {GamesWon}";
            return stringa;
        }

    }
}
