using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UIKT.Models
{
    public enum StatusVloge
    {
        [Display(Name = "Oddana")]
        Oddana,
        [Display(Name = "V pripravi")]
        V_pripravi,
        [Display(Name = "Zavrnjena")]
        Zavrnjena,
        [Display(Name = "Potrjena")]
        Potrjena
    }

    public class Vloga
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public DateTime DatumOddaje { get; set; }

        [HiddenInput(DisplayValue = false)]
        public StatusVloge Status { get; set; }

        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Davcna  { get; set; }
       
        public string Telefon { get; set; }

        [Display(Name = "Občina")]
        public string Obcina { get; set; }
        public string Naslov { get; set; }
        public string Posta { get; set; }
        [Display(Name = "Poštna Številka")]
        public string PostnaSt { get; set; }
        [Display(Name = "Površina")]
        public double Poversina { get; set; }
        [Display(Name = "Naslov Vinograda")]
        public string NaslovVinograda { get; set; }
        [Display(Name = "Pošta Vinograda")]
        public string PostaVinograda { get; set; }
        [Display(Name = "Poštna Številka Vinograda")]
        public string PostnaStVinograda { get; set; }
        [Display(Name = "Vrsta vinske trte")]
        public string VrstaVinskeTrte { get; set; }
        [Display(Name = "Terase?")]
        public bool Terase { get; set; }

        public Vloga(int userId, string ime, string priimek, string davcna, string telefon, string obcina, string naslov, string posta, string postnaSt, double poversina, string naslovVinograda, string postaVinograda, string postnaStVinograda, string vrstaVinskeTrte, bool terase)
        {
            UserId = userId;
            Ime = ime;
            Priimek = priimek;
            Davcna = davcna;
            Telefon = telefon;
            Obcina = obcina;
            Naslov = naslov;
            Posta = posta;
            PostnaSt = postnaSt;
            Poversina = poversina;
            NaslovVinograda = naslovVinograda;
            PostaVinograda = postaVinograda;
            PostnaStVinograda = postnaStVinograda;
            VrstaVinskeTrte = vrstaVinskeTrte;
            Terase = terase;
        }

        public Vloga()
        {
        }

        public override string ToString()
        {
            return Id.ToString() + " " + Ime + " " + Priimek;
        }

    }
}
