using Csharp_Entity_Framework_Players;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;" +
    "Initial Catalog=MyPlayers;Integrated Security=True";
int input = 0;

/*
int elementiInTeams;
using(Context db = new Context())
{
    elementiInTeams = db.Teams.Count();
    if(elementiInTeams == 0) { InsertNewTeam(); }
}
*/



while (input != 9)
{
    Console.WriteLine("GESTORE Players");
    Console.WriteLine();
    Console.WriteLine("Seleziona un opzione: ");
    Console.WriteLine("1. Inserisci un giocatore");
    Console.WriteLine("2. Cerca un giocatore");
    Console.WriteLine("3. Cancella un giocatore");
    Console.WriteLine("4. Inserisci un team: ");
    Console.WriteLine("5. Cerca un team");
    //Console.WriteLine("4. Ricerca i videogame che hanno il titolo contenente una determinata stringa");
    //Console.WriteLine("5. Cancella un videogame");
    //Console.WriteLine("6. Esci");

    input = int.Parse(Console.ReadLine());

    switch (input)
    {
        case 9: Console.WriteLine("Ciao!"); break;
        case 1: InsertNewPlayer();
            break;
        case 2: SearchPlayer();
            break;
        case 3: RemovePlayer(); break;
        case 4: InsertNewTeam(); break;
        case 5: SearchTeam(); break;
    }

}

void InsertNewPlayer()
{
    Console.WriteLine("Inserisci il nome del player");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome");
    string surname = Console.ReadLine();
    Console.WriteLine("Inserisci quante partite ha giocato");
    int gamesPlayed = int.Parse(Console.ReadLine());
    Console.WriteLine("Quante di queste le ha vinte?");
    int gamesWon = int.Parse(Console.ReadLine());
    Console.WriteLine("In che squadra gioca?(Inserisci l'id)");
    //string teamName =Console.ReadLine();
    int teamId = int.Parse(Console.ReadLine());
    try
    {
        Player player = new Player(nome, surname, gamesPlayed, gamesWon, teamId);
        using (Context db = new Context())
        {
            db.Add(player);
            db.SaveChanges();
        }
        Console.WriteLine("Ecco i dettagli del nuovo giocatore : " + player.ToString());
    }
    catch(Exception ex) { Console.WriteLine(ex.Message); }
}

void InsertNewTeam()
{
    Console.WriteLine("Inserisci il nome della Squadra");
    string teamName = Console.ReadLine();
    Console.WriteLine("Inserisci la città");
    string city = Console.ReadLine();
    Console.WriteLine("Inserisci l'allenatore");
    string coach = Console.ReadLine();
    Console.WriteLine("Inserisci i colori");
    string colours = Console.ReadLine();
    try
    {
        Team team = new Team(teamName, city, coach,colours);
        using (Context db = new Context())
        {
            db.Add(team);
            db.SaveChanges();
           
        }
        Console.WriteLine("Ecco i dettagli della squadra : " + team.ToString());
    }
    catch (Exception ex) { Console.WriteLine(ex.Message); }
}

void SearchTeam()
{
    Console.WriteLine("Quale team vuoi vedere?");
    string stringa ="";
    stringa = Console.ReadLine();

    using (Context db = new Context())
    {
        Team teamFound = db.Teams.Where( Teamname => Teamname.TeamName == stringa).FirstOrDefault();
        if (teamFound != null)
        {
            Console.WriteLine(teamFound.ToString());
            
        }
        else { Console.WriteLine("Squadra non trovata :("); }
    }

}

void SearchPlayer()
{
    string surname = "";
    Console.Write("Inserisci il nome del player che vuoi cercare: ");
    string name = Console.ReadLine();
    Console.WriteLine("\nInserisci il cognome del player che vuoi cercare: ");
    surname = Console.ReadLine();

    using(Context db = new Context())
    {
        /*
        List<Player> giocatori = (
            from c in db.Players
            where c.Name == name && c.Surname == surname select c
            ).ToList<Player>();
        */
        
        //Player playerFound = db.Players.Where(players => players.Name == name).First();
        //Player playerFound = db.Players.Where(r => r.Name == name && r.Surname == surname).First();
        //List<Player> giocatori = db.Players.Where(r => r.Name == name && r.Surname == surname).Include(giocatore => giocatore.Team).ToList();
        /*
        foreach ( Player player in giocatori)
        {
            Console.WriteLine(player.ToString());
        }
        */
        Player player = db.Players.Where(r => r.Name == name && r.Surname == surname).Include(giocatore => giocatore.Team).First();
        Console.Write(player.ToString());
        Console.Write(player.Team.ToString());
    }
}


void ModifyPlayerIdentity()
{
    Console.WriteLine("Inserisci il nome del giocatore da modificare");
    string name = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome");
    string surname = Console.ReadLine();
    using (Context db = new Context())
    {

        //Come facci oa cercare tramite più parametri?
        Player playerFound = db.Players.Where(r => r.Name == name && r.Surname == surname).First();

        Console.WriteLine("Inserisci il suo nuovo Nome :D");
        playerFound.Name = Console.ReadLine();
        Console.WriteLine("Inserisci il nuovo cognome");
        playerFound.Surname = Console.ReadLine();
    }
}

void RemovePlayer()
{
    Console.WriteLine("Inserisci il nome del giocatore da rimuovere");
    string name = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome");
    string surname = Console.ReadLine();
    using (Context db = new Context())
    {

        //Come faccio a cercare tramite più parametri?
        Player playerFound = db.Players.Where(r => r.Name == name && r.Surname == surname).First();
        db.Remove(playerFound);
        db.SaveChanges();

        
    }
}