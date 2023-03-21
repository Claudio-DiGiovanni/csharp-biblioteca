﻿
using static Biblioteca;


var utenti = new List<Utente>();
var utente1 = new Utente("Franco", "Peppone", "francopeppone@gmail.com", "qwerty", "3477418528");
var utente2 = new Utente("Giuseppe", "Rossi", "francopeppone@gmail.com", "qwerty", "3477418528");
var utente3 = new Utente("Giulio", "Verdi", "francopeppone@gmail.com", "qwerty", "3477418528");
var utente4 = new Utente("Marco", "Bianchi", "francopeppone@gmail.com", "qwerty", "3477418528");
var utente5 = new Utente("Gianluca", "Blu", "francopeppone@gmail.com", "qwerty", "3477418528");
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

Console.WriteLine("Lista Utenti: ");
Console.WriteLine(ShowUsers(utenti));

Console.WriteLine("Lista Libri: ");
Console.WriteLine(ShowBooks(libri));

Console.WriteLine("Lista DVDs: ");
Console.WriteLine(ShowDVDs(DVDs));

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