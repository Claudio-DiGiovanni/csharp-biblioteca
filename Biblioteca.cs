using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteca;

public class Biblioteca
{

    public string GenerateId()
    {
        var random = Convert.ToString(new Random().Next(1, 999999));
        while (random.Length < 6)
        {
            random = "0" + random;
        }
        return random;
    }

    public class Prenotazione : Biblioteca
    {
        string dataInizio;
        string dataFine;
        Utente utente;
        Prodotto prodotto;

        public Prenotazione(string dataInizio, string dataFine, Utente utente, Prodotto prodotto)
        {
            this.dataInizio = dataInizio;
            this.dataFine = dataFine;
            this.utente = utente;
            this.prodotto = prodotto;
        }
    }


    public class Utente : Biblioteca
    {
        private string nome;
        private string cognome;
        private string email;
        private string password;
        private string telefono;

        public Utente(string nome, string cognome, string email, string password, string telefono)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.email = email;
            this.password = password;
            this.telefono = telefono;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Telefono { get => telefono; set => telefono = value; }
  
        public override string ToString()
        {
            return $"Nome: {nome}" + Environment.NewLine +
                   $"Cognome:  { cognome }" + Environment.NewLine +
                   $"Email:  { email }" + Environment.NewLine +
                   $"Password:  { password }" + Environment.NewLine +
                   $"Telefono:  { telefono }";
        }
    }

    public class Prodotto : Biblioteca
    {
        
        private string codice;
        private string titolo;
        private int anno;
        private string settore;
        private string posizione;
        private string[] autore = new string[2];

        public Prodotto(string titolo, int anno, string settore, string posizione, string[] autore)
        {
            this.codice = GenerateCode();
            this.titolo = titolo;
            this.anno = anno;
            this.settore = settore;
            this.posizione = posizione;
            this.autore = autore;
        }

        public string Titolo { get => titolo; set => titolo = value; }
        public int Anno { get => anno; set => anno = value; }
        public string Settore { get => settore; set => settore = value; }
        public string Posizione { get => posizione; set => posizione = value; }
        public string[] Autore { get => autore; set => autore = value; }
        public string GenerateCode()
        {
            return base.GenerateId();
        }
        public override string ToString()
        {
            return $"Codice identificativo: {codice}" + Environment.NewLine +
                   $"Titolo:  {titolo}" + Environment.NewLine +
                   $"Anno:  {anno}" + Environment.NewLine +
                   $"Settore:  {settore}" + Environment.NewLine +
                   $"Posizione:  {posizione}" + Environment.NewLine +
                   $"autore:  {string.Join(" ", autore)}";
        }
    }

    public class DVD : Prodotto
    {
        int durata;
        public DVD(string titolo, int anno, string settore, string posizione, string[] autore, int durata) : base( titolo, anno, settore, posizione, autore)
        {
            this.durata = durata;
        }

        public int Durata { get => durata; set => durata = value; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Durata min: {durata}";
        }
    }

    public class Libro : Prodotto
    {
        int pagine;

        public Libro(string titolo, int anno, string settore, string posizione, string[] autore, int pagine) : base(titolo, anno, settore, posizione, autore)
        {
            this.pagine = pagine;
        }

        public int Pagine { get => pagine; set => pagine = value; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Pagine: {pagine}";
        }
    }
}

