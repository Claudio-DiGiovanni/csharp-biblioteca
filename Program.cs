
using System.ComponentModel.Design;
using static Biblioteca;
var utenti = new List<Utente>();
var utente1 = new Utente("Franco", "Peppone", "francopeppone@gmail.com", "qwerty", "3477418528");
var utente2 = new Utente("Giuseppe", "Rossi", "giusepperossi@gmail.com", "qwerty", "3477418528");
var utente3 = new Utente("Giulio", "Verdi", "giulioverdi@gmail.com", "qwerty", "3477418528");
var utente4 = new Utente("Marco", "Bianchi", "marcobianchi@gmail.com", "qwerty", "3477418528");
var utente5 = new Utente("Gianluca", "Blu", "gianlucablu@gmail.com", "qwerty", "3477418528");
utenti.Add(utente1);
utenti.Add(utente2);
utenti.Add(utente3);
utenti.Add(utente4);
utenti.Add(utente5);
var libri = new List<Libro>();
var libro1 = new Libro("La Bibbia", 200, "fantascienza", "F666", new[] { "Gesu", "Cristo" }, 2000);
var libro2 = new Libro("Il Corano", 300, "comico", "H1", new[] { "Maometto", "Marocco" }, 5000);
var libro3 = new Libro("La Torà", 100, "finanza", "S68", new[] { "Davide", "Giudeo" }, 2700);
libri.Add(libro1);
libri.Add(libro2);
libri.Add(libro3);
var DVDs = new List<DVD>();
var DVD1 = new DVD("Star Wars", 1974, "fantascienza", "D57", new[] {"Chris", "Nolan"}, 180);
var DVD2 = new DVD("Ritorno al Futuro", 1994, "drammatico", "F47", new[] {"John", "Johnny"}, 120);
var DVD3 = new DVD("Il Signore Degli Anelli", 2001, "fantasy", "C69", new[] {"Steven", "Spielberg"}, 150);
DVDs.Add(DVD1);
DVDs.Add(DVD2);
DVDs.Add(DVD3);
var prenotazioni = new List<Prenotazione>();
var prenotazione1 = new Prenotazione("12/13/14", "13/14/15", utente1, DVD1);
var prenotazione2 = new Prenotazione("12/13/14", "13/14/15", utente1, DVD2);
var prenotazione3 = new Prenotazione("12/13/14", "13/14/15", utente1, libro1);
prenotazioni.Add(prenotazione1);
prenotazioni.Add(prenotazione2);
prenotazioni.Add(prenotazione3);






Menu();












string ShowUsers(List<Utente> list)
{
    return string.Join(Environment.NewLine, list).ToString();
}
string ShowBooks(List<Libro> list)
{
    return string.Join(Environment.NewLine, list).ToString();
}
string ShowDVDs(List<DVD> list)
{
    return string.Join(Environment.NewLine, list).ToString();
}
string ShowPrenotazioni(List<Prenotazione> list)
{
    return string.Join(Environment.NewLine, list).ToString();
}

Libro? CercaLibro(string titolo, List<Libro> lista)
{
    Libro ricerca = null;
    foreach (var item in lista)
    {
        if (item.Titolo == titolo)
        {
            ricerca = item;
        }
    }
    return ricerca;

}

DVD? CercaDVD(string titolo, List<DVD> lista)
{
    DVD ricerca = null;
    foreach (var item in lista)
    {
        if (item.Titolo == titolo)
        {
            ricerca = item;
        }
    }
    return ricerca;

}
Utente? CercaUtente(string nome, List<Utente> lista)
{
    Utente ricerca = null;
    foreach (var item in lista)
    {
        if (item.Nome == nome || item.Cognome == nome)
        {
            ricerca = item;
        }
    }
    return ricerca;
}

List<Prenotazione> CercaPrenotazione(string nome, List<Prenotazione> listaPrenotazioni)
{
    List<Prenotazione> prenotazioniTrovate = new List<Prenotazione>();

    foreach (Prenotazione prenotazione in listaPrenotazioni)
    {
        if (prenotazione.utente.Nome == nome)
        {
            prenotazioniTrovate.Add(prenotazione);
        }
    }

    return prenotazioniTrovate;
}


void ShowLists()
{
    Console.WriteLine("Che lista vuoi vedere? ( utenti | libri | DVDs | prenotazioni )");
    var inputList = Console.ReadLine();

    switch (inputList)
    {
        case "utenti":
            Console.WriteLine("Lista Utenti: ");
            Console.WriteLine(ShowUsers(utenti));
            break;
        case "libri":
            Console.WriteLine("Lista Libri: ");
            Console.WriteLine(ShowBooks(libri));
            break;
        case "DVDs":
            Console.WriteLine("Lista DVDs: ");
            Console.WriteLine(ShowDVDs(DVDs));
            break;
        case "prenotazioni":
            Console.WriteLine("Lista prenotazioni: ");
            Console.WriteLine(ShowPrenotazioni(prenotazioni));
            break;
        default: break;
    }
}

Utente LogInUtente()
{
    Console.WriteLine("Per proseguire devi loggarti. Inserisci il tuo nome utente o la tua mail: ");
    var nomeUtente = Console.ReadLine();
    Console.WriteLine("inserisci la password: ");
    var password = Console.ReadLine();
        for (var i = 0; i < utenti.Count; i++)
        {
            if (nomeUtente == utenti[i].Nome || nomeUtente == utenti[i].Email && password == utenti[i].Password)
            {
                return utenti[i];
            }
        }
    return utenti[0];
}

void Menu()
{
    Console.WriteLine("Benvenuto in Biblioteca. Cosa vuoi fare? ( liste | prenota | aggiungi | cerca )");
    var input = Console.ReadLine();

    switch (input)
    {
        case "liste":
            ShowLists();
            Menu();
            break;



        case "prenota":
            Console.WriteLine("Cosa vorresti prenotare? ( libri | DVDs )");
            var inputPrenotazione = Console.ReadLine();
            switch (inputPrenotazione)
            {
                case "libri":
                    Console.WriteLine("inserisci il nome del libro che vuoi prenotare: ");
                    foreach (var o in libri)
                    {
                        Console.WriteLine(o.Titolo);
                    }
                    var obj = Console.ReadLine();
                    var libro = CercaLibro(obj, libri);
                    var utente = LogInUtente();
                    var dataInizio = Convert.ToString(DateTime.Today);
                    Console.WriteLine("Fino a quando vuoi prenotarlo?");
                    var dataFine = Console.ReadLine();
                    var prenotazione = new Prenotazione(dataInizio, dataFine, utente, libro);
                    prenotazioni.Add(prenotazione);
                    Menu();
                    return;

                case "DVDs":
                    Console.WriteLine("inserisci il nome del DVD che vuoi prenotare: ");
                    foreach (var o in DVDs)
                    {
                        Console.WriteLine(o.Titolo);
                    }
                    var obj2 = Console.ReadLine();
                    var DVD = CercaDVD(obj2, DVDs);
                    var utenteLoggato = LogInUtente();
                    var dataInizio1 = Convert.ToString(DateTime.Today);
                    Console.WriteLine("Fino a quando vuoi prenotarlo?");
                    var dataFine1 = Console.ReadLine();
                    var prenotazione1 = new Prenotazione(dataInizio1, dataFine1, utenteLoggato, DVD);
                    prenotazioni.Add(prenotazione1);
                    Menu();
                    return;
                default: Menu(); break;
            }
            break;
        case "aggiungi":
            Console.WriteLine("Cosa vuoi aggiungere? ( libro | DVD | utente )");
            var inputAdd = Console.ReadLine();
            switch (inputAdd)
            {
                case "libro":
                    Console.WriteLine("Titolo: ");
                    var titolo = Console.ReadLine();

                    Console.WriteLine("Anno: ");
                    var anno = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Settore: ");
                    var settore = Console.ReadLine();

                    Console.WriteLine("Posizione: ");
                    var posizione = Console.ReadLine();

                    Console.WriteLine("Autore: ");
                    string[] autore = { Console.ReadLine() , Console.ReadLine() };

                    Console.WriteLine("Pagine: ");
                    var pagine = Convert.ToInt32(Console.ReadLine());

                    Libro libro = new Libro(titolo, anno, settore, posizione, autore, pagine);

                    libri.Add(libro);
                    Menu();
                    break;
                case "DVD":
                    Console.WriteLine("Titolo: ");
                    var titolo1 = Console.ReadLine();

                    Console.WriteLine("Anno: ");
                    var anno1 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Settore: ");
                    var settore1 = Console.ReadLine();

                    Console.WriteLine("Posizione: ");
                    var posizione1 = Console.ReadLine();

                    Console.WriteLine("Autore: ");
                    string[] autore1 = { Console.ReadLine(), Console.ReadLine() };

                    Console.WriteLine("Pagine: ");
                    var durata = Convert.ToInt32(Console.ReadLine());

                    DVD DVD = new DVD(titolo1, anno1, settore1, posizione1, autore1, durata);
                    DVDs.Add(DVD);
                    Menu();
                    break;
                case "utente":
                    Console.WriteLine("Nome: ");
                    var nome = Console.ReadLine();

                    Console.WriteLine("Cognome: ");
                    var cognome = Console.ReadLine();

                    Console.WriteLine("Email: ");
                    var email = Console.ReadLine();

                    Console.WriteLine("Password: ");
                    var password = Console.ReadLine();

                    Console.WriteLine("Telefono: ");
                    var telefono = Console.ReadLine();

                    Utente utente = new Utente(nome, cognome, email, password, telefono);
                    utenti.Add(utente);
                    Menu();
                    break;
                default:
                    Menu();
                    break;
            }
            
            break;

        case "cerca":
            Console.WriteLine("cosa cerchi? ( utenti | libri | DVDs | prenotazioni )");
            var inputSearch = Console.ReadLine();
            switch (inputSearch)
            {
                case "utenti":
                    Console.WriteLine("inserisci il nome o il cognome dell'utente che stai cercando");
                    var user = Console.ReadLine();
                    Console.WriteLine(CercaUtente(user, utenti) != null ? CercaUtente(user, utenti).ToString() : "Non è presente nessuno utente con questo nome");
                    Menu();
                    break;

                case "libri":
                    Console.WriteLine("inserisci il titolo del libro che stai cercando");
                    var libro = Console.ReadLine();
                    Console.WriteLine(CercaLibro(libro, libri) != null ? CercaLibro(libro, libri).ToString() : "Non è presente nessuno libro con questo titolo");
                    Menu();
                    break;

                case "DVDs":
                    Console.WriteLine("inserisci il titolo del DVD che stai cercando");
                    var DVD = Console.ReadLine();
                    Console.WriteLine(CercaDVD(DVD, DVDs) != null ? CercaDVD(DVD, DVDs).ToString() : "Non è presente nessuno DVD con questo titolo");
                    Menu();
                    break;
                case "prenotazioni":
                    Console.WriteLine("inserisci il nome dell'utente della prenotazione che stai cercando");
                    var prenotazione = Console.ReadLine();
                    string results = "";
                    foreach (var item in CercaPrenotazione(prenotazione, prenotazioni)) {  results += item.ToString() + Environment.NewLine; };


                    Console.WriteLine(CercaPrenotazione(prenotazione, prenotazioni).Count != 0 ? results : "Non è presente nessuna prenotazione per questo utente");
                    Menu();
                    break;
                default:
                    Menu();
                    break;
            }
            Menu();
            break;

        default:
            Menu();
            break;
    };
}