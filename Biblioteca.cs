using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Pagine: {pagine}";
        }
    }
}

