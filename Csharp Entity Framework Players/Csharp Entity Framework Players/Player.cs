using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //public string TeamName { get; set; }
        //public Team Team { get; set; }


        public Player(string name, string surname, int gamesPlayed, int gamesWon )
        {
            Name = name;
            Surname = surname;
            Score = 0;
            GamesPlayed = gamesPlayed;
            if( gamesWon >= gamesPlayed)
            {
                throw new Exception("Le partite vinte non possono essere più delle partite giocate"); 
            }else
            {
                GamesWon = gamesWon; ;
            }
            Score = GamesPlayed + (GamesWon * 2);
            //TeamName = teamName;
        }


        public override string ToString()
        {

            string stringa = $"Nome : {Name}, Cognome : {Surname}, Punteggio : {Score}, Partite giocate : {GamesPlayed}, Partite vinte : {GamesWon}, Nome della squadra :";
            return stringa;
        }

    }
}
